using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_1_треугольник_
{
    
    class Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
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
    class Triangle
    {
        public Point[] points;
        public Edge[] edges;
        public Triangle(Point[] points, Edge[] edges)
        {
            this.points = points;
            this.edges = edges;
        }
        public bool Isosceles()
        {
            if (edges[0].Side() == edges[1].Side() || edges[1].Side() == edges[2].Side() || edges[0].Side() == edges[2].Side())
            {
                Console.WriteLine("This triangle is isosceles");
                return true;
            }
            else
            {
                Console.WriteLine("This triangle is not isosceles");
                return true;
            }
        }
        public bool Right()
        {
            if (Math.Pow(edges[0].Side(), 2) + Math.Pow(edges[1].Side(), 2) == Math.Pow(edges[2].Side(), 2))
            {
                Console.WriteLine("This triangle is right");
                return true;
            }
            else if (Math.Pow(edges[1].Side(), 2) + Math.Pow(edges[2].Side(), 2) == Math.Pow(edges[0].Side(), 2))
            {
                Console.WriteLine("This triangle is right");
                return true;
            }
            else if (Math.Pow(edges[2].Side(), 2) + Math.Pow(edges[0].Side(), 2) == Math.Pow(edges[1].Side(), 2))
            {
                Console.WriteLine("This triangle is right");
                return true;
            }
            else
            {
                Console.WriteLine("This triangle is not right");
                return false;
            }
        }
        public double Perimeter()
        {
            double perimeter = edges[0].Side() + edges[1].Side() + edges[2].Side();
            Console.WriteLine("Perimeter of triangle = " + perimeter);
            return perimeter;
        }

        public double Area()
        {
            double p = (edges[0].Side() + edges[1].Side() + edges[2].Side()) / 2;
            double area = Math.Round(Math.Sqrt(p * (p - edges[0].Side()) * (p - edges[1].Side()) * (p - edges[2].Side())), 2);
            Console.WriteLine("Area of triangle = " + area);
            return area;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random Gen = new Random();
            Point[] points = new Point[3];
            Edge[] edges = new Edge[3];
            double sumOfRight = 0;
            double sumOfIsosceles = 0;
            Triangle[] triangles = new Triangle[10];
            int count = triangles.Length;
            for (int i = 0; i < triangles.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    points[j] = new Point(Gen.Next(1, 5), Gen.Next(1, 5));
                }
                if (points[0] == points[1])
                {
                    points[0].X++;
                    points[0].Y++;
                    if (points[0] == points[2])
                    {
                        points[0].X++;
                        points[0].Y++;
                    }
                }
                if (points[1] == points[2])
                {
                    points[2].X++;
                    points[2].Y++;
                    if (points[2] == points[0])
                    {
                        points[2].X++;
                        points[2].Y++;
                    }
                }
                for (int k = 0; k < edges.Length; k++)
                {
                    if (k == edges.Length - 1)
                    {
                        edges[k] = new Edge(points[k], points[0]);
                    }
                    else
                    {
                        edges[k] = new Edge(points[k], points[k + 1]);
                    }
                }
                triangles[i] = new Triangle(points, edges);
                Console.WriteLine("Triangele {0}", i + 1);
                for (int b = 0; b < points.Length; b++)
                {
                    Console.WriteLine(points[b].X + " " + points[b].Y);
                }
                double perimeter = triangles[i].Perimeter();
                double area = triangles[i].Area();
                if (triangles[i].Right())
                {
                    sumOfRight += area;
                }
                if (triangles[i].Isosceles())
                {
                    sumOfIsosceles += area;
                }
                Console.WriteLine();
            }
            double avgSumOfPerimeters = sumOfRight / count;
            double avgSumOfArea = sumOfIsosceles / count;
            Console.WriteLine("Avg sum of right triangle's perimeters = {0}", avgSumOfPerimeters);
            Console.WriteLine("Avg sum of isoscele triangle's area = {0}", avgSumOfArea);
            Console.ReadLine();
        }
    }
}
