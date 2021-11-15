using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    class Model
    {
        public const int maxN = 10;
        public double[] pArr;
        public double[] tArr;
        public double[,] tMatrix;
        public int n { get; }
        public double T = 0;
        public Model(int n_)
        {
            this.n = n_;
            this.tMatrix = new double[maxN, maxN];
            this.tArr = new double[maxN];
            this.pArr = new double[maxN];
            for (int i = 0; i < n; i++)
                pArr[i] = 1.0 / n;
        }

        // returns is stabilized
        public bool Step(double dt)
        {
            double[] newP = new double[maxN];
            for (int i=0; i < n; i++)
            {
                newP[i] = pArr[i];
                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue;
                    newP[i] += dt * (pArr[j] * tMatrix[j, i] - pArr[i] * tMatrix[i, j]);
                }
            }

            bool isSt = IsStable(pArr, newP);

            pArr = newP;
            T += dt;

            setStable();
            return isSt;
        }

        private bool IsStable(double[] oldP, double[] newP)
        {
            for (int i = 0; i < n; i++)
                if (Math.Abs(oldP[i] - newP[i]) / newP[i] > 1e-10)
                    return false;
            return true;
        }

        public double[] Kolmogorov()
        {
            double[] res = new double[maxN];

            for (int i = 0; i < n; i++)
            {
                res[i] = 0;
                for (int j = 0; j < n; j++)
                    res[i] += pArr[j] * tMatrix[j, i] - pArr[i] * tMatrix[i, j];
            }

            return res;
        }

        private void setStable()
        {
            double[] kArr = Kolmogorov();
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(kArr[i]) < 1e-5 && tArr[i] <= 1e-7)
                    tArr[i] = T;
                else if (Math.Abs(kArr[i]) > 1e-5 && tArr[i] > 1e-7)
                    tArr[i] = 0;
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Model m = new Model(6);

            m.tMatrix[0, 1] = 0.1;
            m.tMatrix[1, 2] = 0.1;
            m.tMatrix[2, 3] = 0.1;
            m.tMatrix[3, 4] = 0.1;
            m.tMatrix[4, 5] = 0.1;

            m.tMatrix[1, 0] = 0.1;
            m.tMatrix[2, 1] = 0.2;
            m.tMatrix[3, 2] = 0.3;
            m.tMatrix[4, 3] = 0.4;
            m.tMatrix[5, 4] = 0.5;

            Console.WriteLine("[{0}]", string.Join(", ", m.pArr));
            while (!m.Step(0.01))
                Console.WriteLine("{0}\t[{1}]\t[{2}]", m.T, string.Join(", ", m.pArr), string.Join(", ", m.Kolmogorov()));
            Console.WriteLine("Done: [{0}]", string.Join(", ", m.pArr));
            Console.WriteLine("Done: [{0}]", string.Join(", ", m.tArr));
            return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
