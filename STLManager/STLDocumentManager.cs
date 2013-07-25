using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLReader;

namespace STLManager
{
    public class STLDocumentManager
    {
        STLDocument _stl;

        List<Facet> _minZs;
        List<Facet> _maxZs;

        public STLDocumentManager(STLDocument stl)
        {
            _stl = stl;
        }

        public void InitForZCutter()
        {

        }

        private decimal minZ(Facet f)
        {
            return f.Vertices.Max(vert => vert.Z);
        }
    }
}
