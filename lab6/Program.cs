using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            EventModel model = new EventModel(
                new Generator(5, 2),
                new List<Service> {
                        new Service(10, 1, 0.1),
                        new Service(15, 5, 0.1),
                        new Service(10, 2, 0.2)
                    },
                new Service(5, 1, 0.05)
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
