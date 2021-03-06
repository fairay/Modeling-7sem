using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Request
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

    class Generator
    {
        public double A { get; }
        public double B { get; }
        public Request r;
        private Random rnd = new Random();
        public Generator(double a, double b, double currentT=0.0)
        {
            A = a; B = b;
            New(currentT);
        }

        public double Aver()
        {
            return (A + B) / 2;
        }

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
            r = new Request(curT + A + (B - A) * rnd.NextDouble());
            return oldR;
        }
    }

    class Service
    {
        public double Mu { get; }
        public double Sig { get; }
        public double FeedBackP { get; }
        public Request r;
        private Random rnd;
        public Service(double mu, double sig, double fbP=0.0)
        {
            Mu = mu; Sig = sig;
            FeedBackP = fbP;
            rnd = new Random();
            r = null;
        }

        public double WhenReady()
        {
            return r.ServeT;
        }
        public bool IsEmpty()
        {
            return r == null;
        }
        public bool IsReady(double curT)
        {
            return r != null && curT >= r.ServeT - 1e-5;
        }

        public void Put(Request newR, double curT)
        {
            r = newR;
            double roll = Delay();
            r.ServeT = curT + roll;
            Console.WriteLine("\t\t\t\t\t\t\t\t{0}", r.ServeT);
        }

        public Request Get(double curT)
        {
            Request oldR = r;
            r = null;

            if (rnd.NextDouble() < FeedBackP)
                oldR = new Request(curT);
            return oldR;
        }

        private double Delay()
        {
            const int n = 12;
            double acc = 0;

            for (int i = 0; i < n; i++)
                acc += rnd.NextDouble();

            acc -= n / 2.0;
            acc *= Sig * Math.Sqrt(12.0 / n);
            acc += Mu;

            if (acc <= 0)
            {
                Console.WriteLine("$");
                acc = Delay();
            }

            return acc;
        }
    }

    class ReqQueue: Queue<Request>
    {
        public int PeakLen = 0;
        public double PeakTime = -1;
        public ReqQueue() {}
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

    class DTModel
    {
        public double CurT;
        private Generator Gen;
        private ReqQueue Que;
        private Service Serv;

        public int createdN = 0;
        public int servedN = 0;
        public int returnedN = 0;
        public bool IsOverflowed = false;

        public DTModel(Generator g, Service s)
        {
            CurT = 0;
            Gen = g;
            Que = new ReqQueue();
            Serv = s;
        }

        public int Run(double dT=0.01, double endT= 1e5)
        {
            while (CurT - Que.PeakTime < 1000.0 * Gen.Aver() && CurT < endT)
            {
                HandleGenerator();
                HandleService();
                CurT += dT;
            }
            Console.WriteLine("{0} {1}", CurT, Que.PeakTime);
            if (CurT > 1e5)
            {
                IsOverflowed = true;
                return -1;
            } else
                return Que.PeakLen;
        }

        private void HandleGenerator()
        {
            if (Gen.IsReady(CurT))
            {
                Request r = Gen.New(CurT);
                Que.Push(r, CurT);

                createdN++;
                Console.WriteLine("{0}:\t{1}\t =>", CurT, Que.Count);
            }
        }

        private void HandleService()
        {
            if (Serv.IsReady(CurT))
            {
                Request r = Serv.Get(CurT);
                if (!r.IsServed())
                {
                    Que.Push(r, CurT);
                    returnedN++;
                    Console.WriteLine("{0}:\t{1}\t <>", CurT, Que.Count);
                } else
                {
                    servedN++;
                    Console.WriteLine("{0}:\t{1}\t ->", CurT, Que.Count);
                }
            }

            if (Serv.IsEmpty() && Que.Count > 0)
            {
                Serv.Put(Que.Pop(), CurT);
                Console.WriteLine("{0}:\t{1}\t <=", CurT, Que.Count);
            }
        }
    }

    class EventModel
    {
        public double CurT;
        private Generator Gen;
        private ReqQueue Que;
        private Service Serv;

        public int createdN = 0;
        public int servedN = 0;
        public int returnedN = 0;
        public bool IsOverflowed = false;

        private List<double> Events;

        public EventModel(Generator g, Service s)
        {
            CurT = 0;
            Gen = g;
            Que = new ReqQueue();
            Serv = s;

            Events = new List<double> { g.WhenReady() };
        }

        public int Run(double endT = 1e5)
        {
            while (CurT - Que.PeakTime < 1000.0 * Gen.Aver() && CurT < endT)
            {
                HandleGenerator();
                HandleService();

                CurT = Events.Min();
                Events.Remove(CurT);
            }

            Console.WriteLine("{0} {1}", CurT, Que.PeakTime);
            if (CurT > 1e5)
            {
                IsOverflowed = true;
                return -1;
            }
            else
                return Que.PeakLen;
        }

        private void HandleGenerator()
        {
            if (Gen.IsReady(CurT))
            {
                Request r = Gen.New(CurT);
                Que.Push(r, CurT);

                createdN++;
                Events.Add(Gen.WhenReady());
                Console.WriteLine("{0}:\t{1}\t =>", CurT, Que.Count);
            }
        }

        private void HandleService()
        {
            if (Serv.IsReady(CurT))
            {
                Request r = Serv.Get(CurT);
                if (!r.IsServed())
                {
                    Que.Push(r, CurT);
                    returnedN++;
                    Console.WriteLine("{0}:\t{1}\t <>", CurT, Que.Count);
                }
                else
                {
                    servedN++;
                    Console.WriteLine("{0}:\t{1}\t ->", CurT, Que.Count);
                }
            }

            if (Serv.IsEmpty() && Que.Count > 0)
            {
                Serv.Put(Que.Pop(), CurT);
                Events.Add(Serv.WhenReady());
                Console.WriteLine("{0}:\t{1}\t <=", CurT, Que.Count);
            }
        }
    }
}
