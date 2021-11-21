using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Generator scanGenerator()
        {
            string txt;
            double a, b;
            txt = aInp.Text.Replace(".", ",");
            a = Convert.ToDouble(txt);

            txt = bInp.Text.Replace(".", ",");
            b = Convert.ToDouble(txt);

            return new Generator(a, b);
        }

        private Service scanService()
        {
            string txt;
            double p, mu, sig;

            txt = pInp.Text.Replace(".", ",");
            p = Convert.ToDouble(txt);

            txt = muInp.Text.Replace(".", ",");
            mu = Convert.ToDouble(txt);

            txt = sigInp.Text.Replace(".", ",");
            sig = Convert.ToDouble(txt);

            return new Service(mu, sig, p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DTButton.Enabled = false;

            Generator g = scanGenerator();
            Service s = scanService();
            DTModel d = new DTModel(g, s);

            int res = d.Run();
            if (d.IsOverflowed)
                lenOut.Text = "∞";
            else
                lenOut.Text = res.ToString();
            DTButton.Enabled = true;
        }

        private void EventButton_Click(object sender, EventArgs e)
        {
            EventButton.Enabled = false;

            Generator g = scanGenerator();
            Service s = scanService();
            EventModel d = new EventModel(g, s);

            int res = d.Run();
            if (d.IsOverflowed)
                lenOut.Text = "∞";
            else
                lenOut.Text = res.ToString();

            EventButton.Enabled = true;
        }
    }
}
