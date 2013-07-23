using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GearsMathSimulator
{
    public class GearSystem
    {
       private Dictionary<string, Gear> _gears = new Dictionary<string,Gear>();
       private List<GearsConstrain> _contrains = new List<GearsConstrain>(); 

        public GearSystem(int numGearsOfFirst)
        {
            var tooths = new List<bool>();
            for (int i = 0; i < numGearsOfFirst; i++)
                tooths.Add(true);

            Gear first = new Gear(true, true, tooths);
            _gears.Add("A", first);
        }

        public bool AddGear(string gearName, List<bool> tooths)
        {
            if (_gears.ContainsKey(gearName) || tooths == null || tooths.Count < 2)
                return false;

            _gears.Add(gearName, new Gear( tooths));
            return true;
        }

        public bool AddConstrain(string a, string b)
        {
            if (!_gears.ContainsKey(a) || !_gears.ContainsKey(b) || a == b)
                return false;

            if (_gears[a].isLeft != _gears[b].isLeft)
                return false;

            _contrains.Add(new GearsConstrain(_gears[a], _gears[b], 0,0));
            return true;
        }

        public bool AddConstrain(string a, string b, int idxa, int idxb)
        {
            if (!_gears.ContainsKey(a) || !_gears.ContainsKey(b) || a == b)
                return false;

            _contrains.Add(new GearsConstrain(_gears[a], _gears[b], idxa, idxb));
            return true;
        }

        public void Iterate()
        {
            _contrains.ForEach(con1 => _contrains.ForEach(con2 => con2.UpdateData()));
            _gears.Keys.ToList().ForEach(key => _gears[key].IterateNext());
        }
    }
}
