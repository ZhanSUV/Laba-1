using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles
{
    class Edge
    {
        public Point start;
        public Point end;
        public Edge(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }
        public double Side()
        {
            return Math.Round(Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2)), 0);
        }
    }
}
