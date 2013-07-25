using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLManager
{
    internal class SegmentEdge
    {
        private LineSegment _seg;
        private bool _isLeft;

        private SegmentEdge(LineSegment seg, bool IsLeft) 
        {
            _seg = seg;
            _isLeft = IsLeft;
        }

        public SegmentEdge[] EdgesFromsegment(LineSegment segment)
        {
            SegmentEdge[] result = new SegmentEdge[2];

            result[0] = new SegmentEdge(segment, true);
            result[1] = new SegmentEdge(segment, false);

            return result;
        }
    }
}
