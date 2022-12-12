using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        Dictionary<double, double> coord = new Dictionary<double, double>();
        public Form1()
        {
            InitializeComponent();

        }

        public static double LagrangeInterpolation(double[] x, double[] y, double xval)
        {
            double yval = 0;
            double Products = y[0];
            for (int i = 0; i < x.Length; i++)
            {
                Products = y[i];
                for (int j = 0; j < x.Length; j++)
                {
                    if (i != j)
                    {
                        Products *= (xval - x[j]) / (x[i] - x[j]);
                    }
                }
                yval += Products;
            }
            return yval;
        }

        public static double[] LagrangeInterpolation(double[] x, double[] y, int[] xvals)
        {
            double[] yvals = new double[xvals.Length];
            for (int i = 0; i < xvals.Length; i++)
                yvals[i] = LagrangeInterpolation(x, y, xvals[i]);
            return yvals;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen pen1 = new Pen(Color.Black);
            g.DrawLine(pen1, Width / 2, 0, Width / 2, Height);
            g.DrawLine(pen1, 0, Height / 2, Width, Height / 2);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point[] points = new Point[Width];
            Point point = e.Location;
            Graphics g = CreateGraphics();
            g.Clear(Color.White);

            Pen pen1 = new Pen(Color.Black);
            Pen pen = new Pen(Color.Red);

            int radius = 5;

            g.DrawLine(pen1, Width / 2, 0, Width / 2, Height);
            g.DrawLine(pen1, 0, Height / 2, Width, Height / 2);

            coord.TryAdd(e.X, e.Y);

            double[] x = new double[coord.Count];
            double[] y = new double[coord.Count];
            int[] xvals = new int[Width];

            int count = 0;

            foreach (var item in coord)
            {
                g.DrawEllipse(pen1, Convert.ToInt32(item.Key) - radius, Convert.ToInt32(item.Value) - radius, 2 * radius, 2 * radius);

                x[count] = item.Key;
                y[count] = item.Value;
                count++;
            }
            for (int i = 0; i < Width; i++)
            {
                xvals[i] = i;
            }

            double[] yvals = LagrangeInterpolation(x, y, xvals);

            for (int i = 0; i <= points.Length - 1; i++)
            {
                points[i].X = xvals[i];
                points[i].Y = Convert.ToInt32(yvals[i]);
            }
            g.DrawLines(pen, points);
        }

        
    }
}
