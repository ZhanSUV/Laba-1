using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles
{
    class Triangle
    {
        public Point[] points;
        private Edge[] edges;
        public Triangle(Point[] points, Edge[] edges)
        {
            this.points = points;
            this.edges = edges;
        }
        public bool Isosceles()
        {
            if (edges[0].Side() == edges[1].Side() || edges[1].Side() == edges[2].Side() || edges[0].Side() == edges[2].Side())
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Right()
        {
            if (Math.Pow(edges[0].Side(), 2) + Math.Pow(edges[1].Side(), 2) == Math.Round(Math.Pow(edges[2].Side(), 2), 0))
            {
                return true;
            }
            else if (Math.Pow(edges[1].Side(), 2) + Math.Pow(edges[2].Side(), 2) == Math.Round(Math.Pow(edges[0].Side(), 2), 0))
            {
                return true;
            }
            else if (Math.Pow(edges[2].Side(), 2) + Math.Pow(edges[0].Side(), 2) == Math.Round(Math.Pow(edges[1].Side(), 2), 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double Perimeter()
        {
            double perimeter = edges[0].Side() + edges[1].Side() + edges[2].Side();
            return perimeter;
        }

        public double Area()
        {
            double p = (edges[0].Side() + edges[1].Side() + edges[2].Side()) / 2;
            double area = Math.Round(Math.Sqrt(p * (p - edges[0].Side()) * (p - edges[1].Side()) * (p - edges[2].Side())), 2);
            return area;
        }
    }
}
