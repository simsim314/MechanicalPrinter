using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using STLReader;
using STLManager;

namespace STLManagerTest
{
     [TestFixture]
    public class PolygonTest
    {
         [Test]
         public void PolygonSimple()
         {
             Vertex v000 = new Vertex(0, 0, 0);
             Vertex v100 = new Vertex(1, 0, 0);
             Vertex v010 = new Vertex(0, 1, 0);
             Vertex v001 = new Vertex(0, 0, 1);

             List<Vertex> tr1 = new List<Vertex>(new Vertex[] {v000, v001, v010} );
             List<Vertex> tr2 = new List<Vertex>(new Vertex[] {v000, v001, v100} );
             List<Vertex> tr3 = new List<Vertex>(new Vertex[] {v000, v100, v010} );
             List<Vertex> tr4 = new List<Vertex>(new Vertex[] { v100, v001, v010 });
             
             Facet f1 = new Facet(tr1);
             Facet f2 = new Facet(tr2);
             Facet f3 = new Facet(tr3);
             Facet f4 = new Facet(tr4);

             List<Facet> fs = new List<Facet>(new Facet[] { f1, f2, f3, f4 });

             STLDocument stl = new STLDocument();
             stl.Facets = fs;

             STLDocumentManager stlMan = new STLDocumentManager(stl);
             var polygons = Polygon.ListPolygonaFromSegments(stlMan.IntersectWithZ(0.01m));
             
         }
    }
}
