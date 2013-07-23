using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GearsMathSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GearSystem g = new GearSystem(10);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          
            
            //float a = 50;
            //int n = 3;
            //float r = (float)((a / (2* Math.Sin(Math.PI / n))) );


            //for (int j = 0; j < n; j++)
            //{
            //    //e.Graphics.TranslateTransform(3 * r + r * (float)Math.Cos(j * 2 * Math.PI  / n), 3 * r + r * (float)Math.Sin( j * 2 * Math.PI  / n));


            //    e.Graphics.TranslateTransform(200 + r * (float)Math.Cos(j * 2 * Math.PI / n), 200 + r * (float)Math.Sin(j * 2 * Math.PI / n));
            //    e.Graphics.RotateTransform(120 + j * 360 / n);
            //    for (int i = 0; i < 360; i += 120)
            //    {
            //        double ang1 = i * Math.PI / 180;
            //        double ang2 = (i + 120) * Math.PI / 180;


            //        Point p2 = new Point((int)(a * Math.Cos(ang2)), (int)(a * Math.Sin(ang2)));
            //        Point p1 = new Point((int)(a * Math.Cos(ang1)), (int)(a * Math.Sin(ang1)));
            //        e.Graphics.DrawLine(new Pen(Color.Black), p1, p2);


            //    }
            //    //e.Graphics.RotateTransform(-120);
            //    e.Graphics.RotateTransform(-(120 + j * 360 / n));
            //    e.Graphics.TranslateTransform(-(200 + r * (float)Math.Cos(j * 2 * Math.PI / n)), -(200 + r * (float)Math.Sin(j * 2 * Math.PI / n)));


            //    //e.Graphics.TranslateTransform(-(3 * r + r * (float)Math.Cos(2 * Math.PI * j / n)), -(3 * r + r * (float)Math.Sin(2 * Math.PI * j / n)));
            //    //e.Graphics.RotateTransform(-(120 + j * 360 / n));

            // }

        }

    
    }
}
