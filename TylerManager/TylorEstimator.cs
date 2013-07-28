using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TylorManager
{
    public class TylorEstimator
    {
        private List<decimal> coofs;

        public TylorEstimator(MatrixOperator.Matrix vals)
        {
            coofs = new List<decimal>();

            for (int i = 0; i < vals.rows; i++)
                coofs.Add((decimal)vals[i, 0]);
        }

        public decimal Eval(decimal t)
        {
            decimal result = 0;

            for (int i = coofs.Count - 1; i >= 0; i--)
            {
                result += t * result + coofs[i];
            }

            return result;
        }

    }
}
