using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GearsMathSimulator
{
    public class DrawableGear
    {
        Graphics _g;
        Gear _gear;

        public DrawableGear(Graphics g, Gear gear)
        {
            _g = g;
            _gear = gear;
        }

        public void Draw(Point p, float radius)
        {
            var tooths = _gear.ToothsToVisualize();
            int n = tooths.Count;

            float dr = radius + 8 * radius * 2 * (float)Math.Sin(Math.PI / n) * (float)Math.Cos(30);
            float dr2 = radius + radius * (float)Math.Sin(Math.PI / n) * (float)Math.Cos(30);

            _g.TranslateTransform(p.X, p.Y);

            for (int j = 0; j < n; j++)
            {
                double ang1 = j * 2 * Math.PI / n;
                double ang2 = (j + 1) * 2 * Math.PI / n;
                double ang3 = (ang1 + ang2) / 2;


                Point p3 = new Point((int)(dr * Math.Cos(ang3)), (int)(dr * Math.Sin(ang3)));
                Point p2 = new Point((int)(radius * Math.Cos(ang2)), (int)(radius * Math.Sin(ang2)));
                Point p1 = new Point((int)(radius * Math.Cos(ang1)), (int)(radius * Math.Sin(ang1)));
                
                if(tooths[j])
                _g.DrawLines(new Pen(Color.Black), new Point[] { p1, p3, p2 });
                else
                    _g.DrawLines(new Pen(Color.Black), new Point[] { p1,  p2 });

                Point pr = new Point((int)(dr2 * Math.Cos(ang3)) - 5, (int)(dr2 * Math.Sin(ang3)) - 5);
                _g.DrawString((tooths[j] ? "0" : "1").ToString(), new Font("Arial", 8), new SolidBrush(Color.Red), pr);
            }

            _g.TranslateTransform(-p.X, -p.Y);
        }
    }
}
