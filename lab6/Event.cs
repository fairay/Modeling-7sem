using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public enum EventTypes
    {
        NewStudent,
        Lab1Done,
        Lab2Done,
        ExamDone,
        End
    }

    public abstract class Event : IComparable<Event>
    {
        public static Random rnd = new Random();
        public EventTypes type;
        public double time;
        public Event(EventTypes type_, double t_)
        {
            this.type = type_;
            this.time = t_;
        }

        public int CompareTo(Event other)
        {
            if (this.time > other.time)
                return 1;
            else
                return -1;
        }

        abstract public void Handle(EventModel model);
    }

    public class EGenerated : Event
    {
        public EGenerated(double t_) : base(EventTypes.NewStudent, t_) { }
        public override void Handle(EventModel model)
        {
            Request req = model.Gen.New(model.CurT);
            model.createdN++;
            if (model.createdN < model.maxCreatedN)
                model.AddEvent(new EGenerated(model.Gen.WhenReady()));

            var switchOption = rnd.Next() % 3;
            switch (switchOption)
            {
                case 0:
                    // Student goes to lab 1
                    // Console.WriteLine("Student goes to lab 1");
                    model.Queues[0].Push(req, model.CurT);
                    if (model.Masters[0].IsFree())
                        model.AddEvent(new ELab1Done(model.CurT));
                    break;

                case 1:
                    // Student goes to lab 2
                    // Console.WriteLine("Student goes to lab 2");
                    model.Queues[1].Push(req, model.CurT);
                    if (model.Masters[1].IsFree() && model.Masters[2].IsFree())
                        model.AddEvent(new ELab2Done(model.CurT, 1 + rnd.Next() % 2));
                    else if (model.Masters[1].IsFree())
                        model.AddEvent(new ELab2Done(model.CurT, 1));
                    else if (model.Masters[2].IsFree())
                        model.AddEvent(new ELab2Done(model.CurT, 2));
                    break;

                case 2:
                    // Student goes to exam
                    // Console.WriteLine("Student goes to exam");
                    model.Queues[2].Push(req, model.CurT);
                    if (model.Lecturer.IsFree())
                        model.AddEvent(new EExamDone(model.CurT));
                    break;

                default:
                    break;
            }
        }
    }

    public class ELab1Done : Event
    {
        public ELab1Done(double t_) : base(EventTypes.Lab1Done, t_) {}

        public override void Handle(EventModel model)
        {
            Request req = model.Masters[0].Get();
            if (req != null)
            {
                if (rnd.NextDouble() < model.Masters[0].ReturnP)
                    model.Queues[0].Push(req, model.CurT);
                else
                {
                    model.Queues[1].Push(req, model.CurT);
                    if (model.Masters[1].IsFree() && model.Masters[2].IsFree())
                        model.AddEvent(new ELab2Done(model.CurT, 1 + rnd.Next() % 2));
                    else if (model.Masters[1].IsFree())
                        model.AddEvent(new ELab2Done(model.CurT, 1));
                    else if (model.Masters[2].IsFree())
                        model.AddEvent(new ELab2Done(model.CurT, 2));
                }
            }

            if (model.Queues[0].Count == 0)
                return;
            req = model.Queues[0].Pop();
            if (req != null)
            {
                model.Masters[0].Put(req, model.CurT);
                model.AddEvent(new ELab1Done(model.Masters[0].WhenReady()));
            }
        }
    }

    public class ELab2Done : Event
    {
        private int Num;
        public ELab2Done(double t_, int num) : base(EventTypes.Lab2Done, t_)
        {
            Num = num;
        }

        public override void Handle(EventModel model)
        {
            Request req = model.Masters[Num].Get();
            if (req != null)
            {
                if (rnd.NextDouble() < model.Masters[Num].ReturnP)
                    model.Queues[1].Push(req, model.CurT);
                else
                {
                    model.Queues[2].Push(req, model.CurT);
                    if (model.Lecturer.IsFree())
                        model.AddEvent(new EExamDone(model.CurT));
                }
            }

            if (model.Queues[1].Count == 0)
                return;
            req = model.Queues[1].Pop();
            if (req != null)
            {
                model.Masters[Num].Put(req, model.CurT);
                model.AddEvent(new ELab2Done(model.Masters[Num].WhenReady(), Num));
            }
        }
    }

    public class EExamDone : Event
    {
        public EExamDone(double t_) : base(EventTypes.ExamDone, t_) { }
        public override void Handle(EventModel model)
        {
            Request req = model.Lecturer.Get();
            if (req != null)
            {
                if (rnd.NextDouble() < model.Lecturer.ReturnP)
                    model.denyedN++;
                else
                    model.servedN++;
            }

            if (model.Queues[2].Count == 0)
                return;

            req = model.Queues[2].Pop();
            if (req != null)
            {
                model.Lecturer.Put(req, model.CurT);
                model.AddEvent(new EExamDone(model.Lecturer.WhenReady()));
            }
        }
    }
}
