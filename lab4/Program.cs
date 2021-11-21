using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DTModel d = new DTModel(new Generator(3, 6), new Service(4, 3, 0.0));
            //Console.WriteLine("RESULT: {0}", d.Run(0.01, 1000));
            //Console.WriteLine("=>{0} <>{1} ->{2}", d.createdN, d.returnedN, d.servedN);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
