using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GearsMathSimulator
{
    public class GearsConstrain
    {
        private Gear firstGear;
        private Gear secondGear;
        private int _idxa;
        private int _idxb;

        public GearsConstrain(Gear a, Gear b, int idxa, int idxb)
        {
            firstGear = a;
            secondGear = b;
            _idxa = idxa;
            _idxb = idxb;
        }

        public void UpdateData()
        {
            if (firstGear.isLeft == secondGear.isLeft || firstGear[_idxa] == secondGear[_idxb])
                EqualizeGears();
        }

        private void EqualizeGears()
        {
            //should rotate never becomes false after it has been set to true
            firstGear.ShouldRotate = secondGear.ShouldRotate;
            secondGear.ShouldRotate = firstGear.ShouldRotate;
        }

    }
}
