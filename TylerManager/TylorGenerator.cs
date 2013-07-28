using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLReader;
using STLManager;

namespace TylorManager
{
    public class TylorGenerator
    {
        private List<decimal> _verteces;
        private List<decimal> _distances; 
        private decimal _epsilon;
        public static int maxCoefs = 5;
        private int _curIdx; 

        public TylorGenerator(List<decimal> verteces, List<decimal> distances, decimal epsilon)
        {
            _verteces = verteces;
            _epsilon = epsilon;
            _distances = distances;
            _distances.Add(_distances[0]);
            _verteces.Add(_verteces[0]);
            _curIdx = 0;
        }

        public List<TylorEstimator> Solve()
        {
            List<TylorEstimator> result = new List<TylorEstimator>();

            while (_curIdx < _verteces.Count)
            {
                result.Add(Solve(_curIdx));
            }

            return result;
        }

        private TylorEstimator Solve(int idx)
        {
            TylorEstimator tylor = null;
            for (int i = idx + 1; i < _verteces.Count; i++)
            {
                var newTylor = Solve(idx, i - idx);

                if (newTylor == null)
                {
                    _curIdx = i;
                    return tylor;
                }
                tylor = newTylor;
            }
            
            _curIdx = _verteces.Count;
            return tylor;
        }

        private TylorEstimator Solve(int idx, int length)
        {
            TylorSolver solver = new TylorSolver(_distances.GetRange(idx, length), _verteces.GetRange(idx, length));
            return solver.SolveWitErrorLessThen(_epsilon, maxCoefs);
        }
    }
}
