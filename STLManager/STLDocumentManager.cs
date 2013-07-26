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

        public STLDocumentManager(STLDocument stl)
        {
            _stl = stl;
        }


        private decimal MinZ(Facet f)
        {
            return f.Vertices.Min(vert => vert.Z);
        }

        private decimal MaxZ(Facet f)
        {
            return f.Vertices.Max(vert => vert.Z);
        }

        private List<Facet> AllFacetsIntersectZ(decimal z)
        {
            return _stl.Facets.FindAll(f => MaxZ(f) >= z).FindAll(f => MinZ(f) <= z);
        }

        private List<LineSegment> IntersectWithZ(decimal z)
        {
            List<LineSegment> result = new List<LineSegment>();
            
            var zfacets = AllFacetsIntersectZ(z);
            zfacets.ForEach(f => result.Add(IntersectWithZ(f, z)));

            return result;
        }

        private LineSegment IntersectWithZ(Facet f, decimal z)
        {
            int numOnZ = f.Vertices.Count(v => v.Z == z);

            if (numOnZ > 1)
                throw new AddEpsilonException("Too many vertices on Z, add epsilon to z");

            List<Vertex2D> vertices = new List<Vertex2D>();

            for (int i = 0; i < f.Vertices.Count; i++)
            {
                var curVert = f.Vertices[i];
                var nextVert = f.Vertices[(i + 1) % f.Vertices.Count];

                if (z.CompareTo(curVert.Z) == z.CompareTo(nextVert.Z))
                    continue;

                decimal totalZ = Math.Abs(curVert.Z - nextVert.Z);
                decimal curVertFactor = 1 - (Math.Abs(curVert.Z - z) / totalZ);
                decimal nextVertFactor = 1 - (Math.Abs(nextVert.Z - z) / totalZ);

                Vertex2D v2 = new Vertex2D();
                v2.X = curVertFactor * curVert.X + nextVertFactor * nextVert.X;
                v2.Y = curVertFactor * curVert.Y + nextVertFactor * nextVert.Y;

                vertices.Add(v2);
            }

            if(vertices.Count != 2 && vertices.Count != 0)
                throw new AddEpsilonException("Too many vertices intersect Z, add epsilon to z");

            if (vertices.Count == 0)
                return null;

            return new LineSegment(vertices[0], vertices[1]);

        }
    }
}
