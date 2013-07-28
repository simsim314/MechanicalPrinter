using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace STLReader
{
    public class Facet : IEquatable<Facet>
    {
        public Normal Normal { get; set; }
        public List<Vertex> Vertices { get; set; }
        public int AttributeByteCount { get; set; }

        public Facet()
        {
            this.Vertices = new List<Vertex>();
        }


        public Facet(List<Vertex> vertices)
            : this()
        {
            //this.Normal = normal;
            this.Vertices = vertices;
            //this.AttributeByteCount = attributeByteCount;
        }

        public static Facet Read(StreamReader reader)
        {
            if (reader == null)
                return null;

            //Create the facet.
            Facet facet = new Facet();

            //Read the normal.
            if ((facet.Normal = Normal.Read(reader)) == null)
                return null;

            //Skip the "outer loop".
            reader.ReadLine();

            //Read 3 vertices.
            facet.Vertices = Enumerable.Range(0, 3).Select(o => Vertex.Read(reader)).ToList();

            //Read the "endloop" and "endfacet".
            reader.ReadLine();
            reader.ReadLine();

            return facet;
        }

        public static Facet Read(BinaryReader reader)
        {
            if (reader == null)
                return null;

            //Create the facet.
            Facet facet = new Facet();

            //Read the normal.
            facet.Normal = Normal.Read(reader);

            //Read 3 vertices.
            facet.Vertices = Enumerable.Range(0, 3).Select(o => Vertex.Read(reader)).ToList();

            //Read the attribute byte count.
            facet.AttributeByteCount = reader.ReadInt16();

            return facet;
        }

        public void Write(StreamWriter writer)
        {
            writer.Write("\t");
            writer.WriteLine(this.ToString());
            writer.WriteLine("\t\touter loop");

            //Write each vertex.
            this.Vertices.ForEach(o => o.Write(writer));

            writer.WriteLine("\t\tendloop");
            writer.WriteLine("\tendfacet");
        }
        
        public void Write(BinaryWriter writer)
        {
            //Write the normal.
            this.Normal.Write(writer);

            //Write each vertex.
            this.Vertices.ForEach(o => o.Write(writer));
        }

        public override string ToString()
        {
            return String.Format("facet {0}",this.Normal);
        }

        public bool Equals(Facet other)
        {
            return false;
        }
    }
}
