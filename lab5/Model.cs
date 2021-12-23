using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Request
    {
        public double CreationT;
        public double ServeT;
        public Request(double t)
        {
            CreationT = t;
            ServeT = -1;
        }

        public bool IsServed()
        {
            return ServeT >= 0;
        }
    }

    public class SAEven
    {
        public double A { get; }
        public double B { get; }
        public Request r;
        private Random rnd = new Random();
        public SAEven(double m, double d)
        {
            A = m - d;
            B = m + d;
        }

        public double Aver()
        {
            return (A + B) / 2;
        }

        public double Delay()
        {
            return A + (B - A) * rnd.NextDouble();
        }
    }

    public class Generator: SAEven
    {
        public Generator(double m, double d): base(m, d) { }

        public double WhenReady()
        {
            return r.CreationT;
        }
        public bool IsReady(double curT)
        {
            return r != null && curT >= r.CreationT - 1e-5;
        }

        public Request New(double curT)
        {
            Request oldR = r;
            r = new Request(curT + Delay());
            return oldR;
        }
    }

    public class Service: SAEven
    {
        public Service(double m, double d): base(m, d) {}

        public double WhenReady()
        {
            return r.ServeT;
        }
        public bool IsFree()
        {
            return r == null;
        }


        public void Put(Request newR, double curT)
        {
            r = newR;
            double roll = Delay();
            r.ServeT = curT + roll;
        }

        public Request Get()
        {
            Request oldR = r;
            r = null;
            return oldR;
        }
    }
    
    public class ReqQueue : Queue<Request>
    {
        public int PeakLen = 0;
        public double PeakTime = -1;
        public ReqQueue() { }
        public void Push(Request r, double curT)
        {
            Enqueue(r);
            if (Count > PeakLen)
            {
                PeakLen = Count;
                PeakTime = curT;
            }
        }
        public Request Pop()
        {
            return Dequeue();
        }
    }

    public class ModelingResult
    {
        public int served;
        public int denied;
        public double time;

        public ModelingResult(int s, int d, double t)
        {
            served = s;
            denied = d;
            time = t;
        }

        public double DeniedP()
        {
            return (double)denied / (served + denied);
        }

        override public string ToString()
        {
            return $"Обслужено: {this.served} \t Отказы: {this.denied} \t Pотк: {Math.Round(DeniedP(), 4)} \t Время моделирования: {this.time}";
        }
    }

    public class EventModel
    {
        public double CurT;
        public Generator Gen;
        public List<Service> Operators;
        public List<Service> Computers;
        public List<ReqQueue> CompQueue;

        public int createdN = 0;
        public int servedN = 0;
        public int denyedN = 0;
        public int maxCreatedN = 300;

        private List<Event> Events;

        public EventModel(Generator generator, List<Service> operators, List<Service> computers)
        {
            Gen = generator;
            Operators = operators;
            Computers = computers;
            CompQueue = new List<ReqQueue> { new ReqQueue(), new ReqQueue() };
        }

        private void Reset()
        {
            createdN = 0;
            servedN = 0;
            denyedN = 0;
            CurT = 0;

            Gen.New(CurT);
            Events = new List<Event> {
                new EGenerated(Gen.WhenReady())
            };
        }

        public ModelingResult Run()
        {
            Reset();
            while (Events.Count > 0)
            {
                Event e = this.Events[0];
                this.Events.RemoveAt(0);

                CurT = e.time;
                e.Handle(this);
            }

            return new ModelingResult(this.servedN, this.denyedN, this.CurT);
        }

        public void AddEvent(Event e)
        {
            Events.Add(e);
            Events.Sort();
        }
    }
}
