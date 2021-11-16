using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        const int N = 10;
        TextBox[,] inputMat;
        public Form1()
        {
            InitializeComponent();

            inputMat = new TextBox[N, N];
            const int w = 35, h = 20, wm = 5, hm = 5;
            for (int i = 1; i <= N; i++)
            {
                var labH = new Label
                {
                    Text = i.ToString(),
                    Location = new Point(0, (h + hm) * i),
                    Width = w, Height = h,
                    TextAlign = ContentAlignment.MiddleLeft
                };
                this.panel1.Controls.Add(labH);

                var labV = new Label
                {
                    Text = i.ToString(),
                    Location = new Point((w + wm) * i, 0),
                    Width = w, Height = h,
                    TextAlign = ContentAlignment.TopCenter
                };
                this.panel1.Controls.Add(labV);

                for (int j = 1; j <= N; j++)
                {
                    var a = new TextBox
                    {
                        // Text = "0.0";
                        Name = i.ToString() + j.ToString() + "inp",
                        Width = w,
                        Height = h,
                        Location = new Point((w + wm) * j, (h + hm) * i),
                        ReadOnly = (i == j)
                    };
                    this.panel1.Controls.Add(a);
                    inputMat[i - 1, j - 1] = a;
                }
            }

            //txt = new TextBox();
            //txt.Name = name + i.ToString() + j.ToString();
            //txt.Location = new Point(10 + j * 120, 5 * (i * 5));
            //            txt.Text = i.ToString();
            //            matrix[i, j] = Convert.ToInt32(txt.Text);

            // this.components.Add(a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int n = 3;
            Model m = new Model(n);
            //m.tMatrix[0, 1] = 0.1;
            //m.tMatrix[1, 2] = 0.1;
            //m.tMatrix[2, 3] = 0.1;
            //m.tMatrix[3, 4] = 0.1;
            //m.tMatrix[4, 5] = 0.1;

            //m.tMatrix[1, 0] = 0.1;
            //m.tMatrix[2, 1] = 0.2;
            //m.tMatrix[3, 2] = 0.3;
            //m.tMatrix[4, 3] = 0.4;
            //m.tMatrix[5, 4] = 0.5;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var txt = inputMat[i, j].Text;
                    txt = txt.Replace(".", ",");
                    Console.WriteLine("[{0}]", txt);
                    if (txt != "")
                        m.tMatrix[i, j] = Convert.ToDouble(inputMat[i, j].Text);
                }
            }

            chart1.Series.Clear();
            for (int i = 0; i < n; i++)
            {
                chart1.Series.Add(i.ToString());
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }

            while (!m.Step(0.01))
                for (int i = 0; i < n; i++)
                    chart1.Series[i].Points.AddXY(m.T, m.pArr[i]);

            chart1.Series.Add("P");
            chart1.Series[n].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[n].Color = Color.Red;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} {1} {2}", i, m.tArr[i], m.pArr[i]);
                chart1.Series[n].Points.AddXY(m.tArr[i], m.pArr[i]);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
