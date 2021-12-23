using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            EventModel model = new EventModel(
                new Generator(10, 2), 
                new List<Service> {
                        new Service(20, 5),
                        new Service(40, 10),
                        new Service(40, 20)
                    },
                new List<Service> {
                    new Service(15, 0),
                    new Service(30, 0)
                }
            );

            for (int i = 0; i < 10; i++)
            {
                ModelingResult res = model.Run();
                Console.WriteLine(res);
            }

            Console.ReadKey();
        }
    }
}
