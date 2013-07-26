using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLManager
{
    internal class SegmentEdge : IComparer<SegmentEdge>, IEqualityComparer<SegmentEdge>
    {
        private LineSegment _seg;
        private bool _isLeft;
        public int Idx;

        private SegmentEdge(LineSegment seg, bool IsLeft, int idx)
        {
            _seg = seg;
            _isLeft = IsLeft;
            Idx = idx;
        }

        public static SegmentEdge[] EdgesFromsegment(LineSegment segment, int idx)
        {
            SegmentEdge[] result = new SegmentEdge[2];

            result[0] = new SegmentEdge(segment, true, idx);
            result[1] = new SegmentEdge(segment, false, idx);

            return result;
        }

        public decimal X
        {
            get
            {
                if (_isLeft)
                    return _seg.LeftX;
                else
                    return _seg.RightX;
            }
        }

        public decimal Y
        {
            get
            {
                if (_isLeft)
                    return _seg.LeftY;
                else
                    return _seg.RightY;
            }
        }

        public int Compare(SegmentEdge x, SegmentEdge y)
        {
            var xcomp = x.X.CompareTo(y.X);
            if (xcomp != 0)
                return xcomp;
            else
                return x.Y.CompareTo(y.Y);
        }

        public bool Equals(SegmentEdge x, SegmentEdge y)
        {
            return (Math.Abs(x.X - y.X) < Consts.epsilon) && (Math.Abs(x.Y - y.Y) < Consts.epsilon);
        }

        public int GetHashCode(SegmentEdge obj)
        {
            return (int)(obj.X * 10000 + obj.Y * 100);
        }

        public SegmentEdge OtherSide
        {
            get
            {
                return new SegmentEdge(_seg, !_isLeft, Idx);
            }
        }
    }
}
