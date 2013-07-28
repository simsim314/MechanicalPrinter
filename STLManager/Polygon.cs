using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLManager
{
    public class Polygon
    {

        List<SegmentEdge> _vertices;

        private Polygon()
        { }

        public static List<Polygon> ListPolygonaFromSegments(List<LineSegment> segments)
        {
            List<SegmentEdge> edges = CreateListEdge(segments);

            List<Polygon> polys = new List<Polygon>();

            while (true)
            {
                Polygon result = new Polygon();
                result._vertices = ExtractPoly(edges);

                if (result._vertices.Count == 0)
                    break;

                polys.Add(result);

            }

            return polys;
        }

        private static List<SegmentEdge> ExtractPoly(List<SegmentEdge> edges)
       {
           List<SegmentEdge>  vertices = new List<SegmentEdge>();

           if (edges.Count == 0)
               return vertices;
             
           SegmentEdge curEdge = edges[0];

           while (true)
           {
               vertices.Add(curEdge);
               edges.Remove(curEdge);

               var otherSide = curEdge.OtherSide;

               var nextEdges = edges.FindAll(seg => seg.EqualsEdge(otherSide) && seg.Idx != otherSide.Idx);


               if (nextEdges.Count == 0)
               {
                   if (otherSide.EqualsEdge(vertices[0]))
                   {
                       edges.FindAll(seg => seg.EqualsEdge(otherSide) && seg.Idx == otherSide.Idx).ForEach(seg => edges.Remove(seg));
                       break;
                   }
                   
                   throw new AddEpsilonException("The loop is not closed");

                   break;
               }
               else if (nextEdges.Count != 1)
                   throw new AddEpsilonException("Few or none edges in the loop, please increase z by epsilon");
               else
                   curEdge = nextEdges[0];

               edges.FindAll(seg => seg.EqualsEdge(otherSide) && seg.Idx == otherSide.Idx).ForEach(seg => edges.Remove(seg));
           }

           return vertices;
       }

        private static List<SegmentEdge> CreateListEdge(List<LineSegment> segments)
        {
            List<SegmentEdge> edges = new List<SegmentEdge>();
            segments.ForEachWithIndex((item, idx) => edges.AddRange(SegmentEdge.EdgesFromsegment(item, idx)));
            edges.Sort();
            return edges;
        }

        public Vertex2D GetVert(int idx)
        {
            return new Vertex2D(_vertices[idx].X, _vertices[idx].Y);
        }

        public int NumVerts
        {
            get
            {
                return _vertices.Count;
            }
        }
    }
}
