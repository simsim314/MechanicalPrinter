using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatrixOperator;
using STLManager;

namespace TylorManager
{
    public class TylorSolver
    {
        List<decimal> _xs;
        List<decimal> _vals;

        public TylorSolver(List<decimal> xs, List<decimal> vals)
        {
            _xs = xs;
            _vals = vals;
        }

        private TylorEstimator SolveForN(int n)
        {
            Matrix m = new Matrix(_xs.Count, n + 1);

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j < _xs.Count; j++)
                {
                    m[j, i] = Math.Pow((double)_xs[j], i);
                }
            }

            Matrix vals = new Matrix(_vals.Count, 1);
            vals.SetCol(_vals, 0);

            Matrix solver = Matrix.Transpose(m) * m;
            Matrix solverVals = Matrix.Transpose(m) * vals;

            var result = solver.SolveWith(solverVals);

            return new TylorEstimator(result);
        }

        public TylorEstimator SolveWitErrorLessThen(decimal epsilon, int maxCoefs)
        {
            for(int i = 1; i <= maxCoefs; i++)
            {
                var curSol = SolveForN(i);

                if(MaxError(curSol) < epsilon)
                    return curSol;
            }

            return null;
        }

        public decimal MaxError(TylorEstimator estimator)
        {
            decimal maxEror = decimal.MaxValue;

           _xs.ForEachWithIndex((x, i) =>  {var curVal = Math.Abs(estimator.Eval(x) - _vals[i]); if(curVal > maxEror) maxEror = curVal;});

            return maxEror;
        }

    }
}
