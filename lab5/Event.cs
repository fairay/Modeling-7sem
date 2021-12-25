using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public enum EventTypes
    {
        NewClient,
        OperatorServed,
        ComputerServed,
        End
    }

    public abstract class Event: IComparable<Event>
    {
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
        public EGenerated(double t_) : base(EventTypes.NewClient, t_) {}
        public override void Handle(EventModel model)
        {
            Request req = model.Gen.New(model.CurT);
            model.createdN++;
            if (model.createdN < model.maxCreatedN)
                model.AddEvent(new EGenerated(model.Gen.WhenReady()));

            for (int i = 0; i < model.Operators.Count; i++)
            {
                var oper = model.Operators[i];
                if (oper.IsFree())
                {
                    oper.Put(req, model.CurT);
                    model.AddEvent(new EOperatorServed(oper.WhenReady(), i));
                    return;
                }
            }

            model.denyedN++;
        }
    }

    public class EOperatorServed: Event
    {
        private int num;
        public EOperatorServed(double t_, int num_) : base(EventTypes.OperatorServed, t_) 
        {
            this.num = num_;
        }

        public override void Handle(EventModel model)
        {
            Request req = model.Operators[num].Get();
            int targetQueue = (num == 2) ? 1 : 0;
            model.CompQueue[targetQueue].Push(req, model.CurT);
            if (model.Computers[targetQueue].IsFree())
                model.AddEvent(new EComputerServed(model.CurT, targetQueue));
        }
    }

    public class EComputerServed : Event
    {
        private int num;
        public EComputerServed(double t_, int num_) : base(EventTypes.ComputerServed, t_) 
        {
            this.num = num_;
        }
        public override void Handle(EventModel model)
        {
            Request req = model.Computers[num].Get();
            if (req != null)
                model.servedN++;

            if (model.CompQueue[num].Count == 0)
                return;

            req = model.CompQueue[num].Pop();
            if (req != null)
            {
                model.Computers[num].Put(req, model.CurT);
                model.AddEvent(new EComputerServed(model.Computers[num].WhenReady(), num));
            }
        }
    }
}
