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

        public LineSegment(Vertex2D v1, Vertex2D v2)
        {
            if (v1.X < v2.X)
            {
                _left = v1;
                _right = v2;
            }
            else
            {
                _left = v2;
                _right = v1;

            }
        }
    }
}
