﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLManager
{
    public  class Vertex2D
    {
        public decimal X;
        public decimal Y;
        public Vertex2D() { }
        public Vertex2D(decimal x1, decimal y1)
        {
            X = x1;
            Y = y1;
        }

        public decimal DistTo(Vertex2D other)
        {
            return (decimal)Math.Sqrt((double)((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y)));
        }
    }
}
