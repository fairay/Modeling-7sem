using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
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
        private static Random rnd = new Random();
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

    public class Generator : SAEven
    {
        
        public Generator(double m, double d) : base(m, d) { }

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

    public class Service : SAEven
    {
        public double ReturnP;
        public Service(double m, double d, double p) : base(m, d) 
        {
            ReturnP = p;
        }

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
        public int AllLen = 0;
        public double PeakTime = -1;
        public ReqQueue() { }
        public void Push(Request r, double curT)
        {
            AllLen++;
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
        public List<ReqQueue> Queues;

        public ModelingResult(int s, int d, double t, List<ReqQueue> q)
        {
            served = s;
            denied = d;
            time = t;
            Queues = q;
        }

        public double DeniedP()
        {
            return (double)denied / (served + denied);
        }

        override public string ToString()
        {
            return $"ЗАЧ/НЗ: {this.served}/{this.denied} \t Время моделирования: {this.time} \t Макс. очереди: {Queues[0].PeakLen}, {Queues[1].PeakLen}, {Queues[2].PeakLen}";
        }
    }

    public class EventModel
    {
        public double CurT;
        public Generator Gen;

        public List<Service> Masters;
        public Service Lecturer;
        public List<ReqQueue> Queues;

        public int createdN = 0;
        public int servedN = 0;
        public int denyedN = 0;
        public int maxCreatedN = 300;

        private List<Event> Events;

        public EventModel(Generator generator, List<Service> masters, Service lecturer)
        {
            Gen = generator;
            Masters = masters;
            Lecturer = lecturer;
            Queues = new List<ReqQueue> { new ReqQueue(), new ReqQueue(), new ReqQueue() };
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

            Queues = new List<ReqQueue> { new ReqQueue(), new ReqQueue(), new ReqQueue() };
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

            return new ModelingResult(this.servedN, this.denyedN, this.CurT, this.Queues);
        }

        public void AddEvent(Event e)
        {
            Events.Add(e);
            Events.Sort();
        }
    }
}
