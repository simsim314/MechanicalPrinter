using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLManager
{
    public class LineSegment
    {
        private Vertex2D _left;
        private Vertex2D _right;

        public LineSegment(Vertex2D left, Vertex2D right)
        {
            _left = left;
            _right = right;
        }
    }
}
