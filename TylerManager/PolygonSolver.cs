using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLManager;

namespace TylorManager
{
    public class PolygonSolver
    {
        TylorGenerator _xsGenerator;
        TylorGenerator _ysGenerator;

        public List<TylorEstimator> xsSolve;
        public List<TylorEstimator> ysSolve;

        public PolygonSolver(Polygon poly, decimal epsilon)
        {
            List<decimal> xs = new List<decimal>();
            List<decimal> ys = new List<decimal>();
            List<decimal> ts = new List<decimal>();

            for (int i = 0; i < poly.NumVerts; i++)
            {
                xs.Add(poly.GetVert(i).X);
                ys.Add(poly.GetVert(i).Y);

                if (i > 0)
                {
                    ts[i] = ts[i - 1] + poly.GetVert(i).DistTo(poly.GetVert(i - 1));
                }
                else
                    ts[0] = 0;
            }

            _xsGenerator = new TylorGenerator(xs, ts, epsilon);
            _ysGenerator = new TylorGenerator(ys, ts, epsilon);
        }

        public void Solve()
        {
            xsSolve = _xsGenerator.Solve();
            ysSolve = _ysGenerator.Solve();
        }

    }
}
