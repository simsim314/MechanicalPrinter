﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace STLReader
{
    public class Vertex : IEquatable<Vertex>
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }

        public Vertex() { }

        public Vertex(decimal x, decimal y, decimal z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Vertex Read(StreamReader reader)
        {
            const string regex = @"\s*(facet normal|vertex)\s+(?<X>[^\s]+)\s+(?<Y>[^\s]+)\s+(?<Z>[^\s]+)";

            string data = null;
            decimal x, y, z;
            Match match = null;
            NumberStyles numberStyle = (NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

            if (reader == null)
                return null;

            data = reader.ReadLine();

            if (data == null)
                return null;

            match = Regex.Match(data, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
                return null;

            if (!decimal.TryParse(match.Groups["X"].Value, numberStyle, CultureInfo.CurrentCulture, out x))
                throw new Exception();

            if (!decimal.TryParse(match.Groups["Y"].Value, numberStyle, CultureInfo.CurrentCulture, out y))
                throw new Exception();

            if (!decimal.TryParse(match.Groups["Z"].Value, numberStyle, CultureInfo.CurrentCulture, out z))
                throw new Exception();

            return new Vertex()
            {
                X = x,
                Y = y,
                Z = z
            };
        }

        public static Vertex Read(BinaryReader reader)
        {
            if (reader == null)
                return null;

            byte[] data = new byte[sizeof(float) * 3];
            int bytesRead = reader.Read(data, 0, data.Length);

            //If no bytes are read then we're at the end of the stream.
            if (bytesRead == 0)
                return null;
            else if (bytesRead != data.Length)
                throw new Exception();

            return new Vertex()
            {
                X = (decimal)BitConverter.ToSingle(data, 0),
                Y = (decimal)BitConverter.ToSingle(data, 4),
                Z = (decimal)BitConverter.ToSingle(data, 8)
            };
        }

        public void Write(StreamWriter writer)
        {
            writer.WriteLine(String.Format("\t\t\t{0}", this.ToString()));
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.X);
            writer.Write(this.Y);
            writer.Write(this.Z);
        }

        public override string ToString()
        {
            return String.Format("vertex {0} {1} {2}",this.X, this.Y, this.Z);
        }

        public bool Equals(Vertex other)
        {
            return (this.X.Equals(other.X)
                    && this.Y.Equals(other.Y)
                    && this.Z.Equals(other.Z));
        }
    }
}
