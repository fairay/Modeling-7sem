using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const double GraphStep = 1000;
        public Form1()
        {
            InitializeComponent();
            UpdGraphics();
        }

        private void ValidateABInput(object sender, EventArgs e)
        {
            double a = (double)this.numericUpDown1.Value;
            double b = (double)this.numericUpDown2.Value;
            if (a>=b)
            {
                this.numericUpDown1.Value = (decimal)(b - 1e-5);
            }
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e) { UpdGraphics(); }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { ValidateABInput(sender, e); UpdGraphics(); }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e) { ValidateABInput(sender, e); UpdGraphics(); }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e) { UpdGraphics(); }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e) { UpdGraphics(); }

        private void UpdGraphics()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    double a = (double)this.numericUpDown1.Value;
                    double b = (double)this.numericUpDown2.Value;
                    buildEval(a, b);
                    break;
                case 1:
                    double m = (double)this.numericUpDown4.Value;
                    double sig = (double)this.numericUpDown3.Value;
                    Console.WriteLine(sig);
                    buildNorm(m, sig);
                    break;
                default:
                    break;
            }
        }


        private void buildEval(double a, double b)
        {
            var range = (b - a) * 2;
            var begin = (a + b - range) / 2;
            var end = (a + b + range) / 2;
            IDist dist = new EvalDist(a, b);
            buildDist(ref dist, begin, end);
        }
        private void buildNorm(double m, double sig)
        {
            var range = 5;
            var begin = m - range / 2;
            var end = m + range / 2;
            IDist dist = new NormDist(m, sig);
            buildDist(ref dist, begin, end);
        }

        private void buildDist(ref IDist dist, double begin, double end)
        {
            chart3.Series[0].Points.Clear();
            chart1.Series[0].Points.Clear();

            var range = end - begin;
            var step = range / GraphStep;
            for (double x = begin; x <= end; x += step)
            {
                chart3.Series[0].Points.AddXY(x, dist.DensVal(x));
                chart1.Series[0].Points.AddXY(x, dist.DistVal(x));
            }
        }
    }

    public abstract class IDist
    {
        public abstract double DistVal(double x);
        public abstract double DensVal(double x);
    }

    public class EvalDist: IDist
    {
        private double a;
        private double b;
        private double p;

        public EvalDist(double a_, double b_)
        {
            a = a_;
            b = b_;
            p = 1 / (b - a);
        }

        public override double DistVal(double x)
        {
            return Math.Max(Math.Min((x - a)*p, 1), 0);
        }

        public override double DensVal(double x)
        {
            if (a <= x && x <= b) return p;
            else return 0;
        }
    }

    public class NormDist : IDist
    {
        private double m;
        private double sig;

        public NormDist(double m_, double sig_)
        {
            m = m_;
            sig = sig_;
        }

        public override double DistVal(double x)
        {
            return (1 + SpecialFunctions.Erf((x - m) / (sig * Math.Sqrt(2)))) / 2;
        }

        public override double DensVal(double x)
        {
            return (1 / (sig * Math.Sqrt(2 * Math.PI))) *
                Math.Exp(-(x-m) * (x-m) / 2 / sig / sig);
        }
    }
}
