using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GearsMathSimulator
{
    public class Gear
    {
        private List<bool> _tooths;
        public bool isLeft;
        private bool _shouldRotate;
        private bool _alwaysRotating;

        public Gear(List<bool> tooths)
        {
            _alwaysRotating = false;
            isLeft = true;
            _tooths = new List<bool>(tooths.ToArray());
            _shouldRotate = false;
        }
        
        public Gear(bool alwaysrotating, bool left, List<bool> tooths)
        {
            _alwaysRotating = alwaysrotating;
            isLeft = left;
            _tooths = new List<bool>(tooths.ToArray());
            _shouldRotate = false;
        }

        public bool ShouldRotate
        {
            get
            {
                return _shouldRotate;
            }
            set
            {
                _shouldRotate = value || _shouldRotate;
            }
        }

        

        private void PerformRotation()
        {
            bool first = _tooths.First();

            _tooths.RemoveAt(0);
            _tooths.Add(first);
        }

        public List<bool> ToothsToVisualize()
        {
            var result = new List<bool>(_tooths.ToArray());

            if (isLeft)
                result.Reverse();

            return result;
        }

        public void IterateNext()
        {
            if (_shouldRotate)
                PerformRotation();

            _shouldRotate = false;
        }

        public bool this[int idx]
        {
            get
            {
                return _tooths[idx % _tooths.Count];
            }
        }
      
    }
}
