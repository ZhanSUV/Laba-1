using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles;

namespace Лаба_1_треугольник_
{
    class Program
    {
        static void Main(string[] args)
        {
            Random Gen = new Random();
            Point[] points = new Point[3];
            Edge[] edges = new Edge[3];
            double sumOfRight = 0;
            double sumOfIsosceles = 0;
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] character = letters.ToCharArray();
            Triangle[] triangles = new Triangle[10];
            int count = triangles.Length;
            for (int i = 0; i < triangles.Length; i++)
            {
                triangles[i] = new Triangle(AddPoints(points, Gen), AddEdges(edges, points));
                Console.WriteLine("Triangle {0}", i + 1);
                PrintingPoints(points, character);
                PrintingSides(edges, character);
                double perimeter = triangles[i].Perimeter();
                double area = triangles[i].Area();
                Console.WriteLine("Perimeter = {0}", perimeter);
                Console.WriteLine("Area = {0}", area);
                if (triangles[i].Right())
                {
                    Console.WriteLine("This triangle is right");
                    sumOfRight += perimeter;
                }
                else
                {
                    Console.WriteLine("This triangle is not right");
                }
                if (triangles[i].Isosceles())
                {
                    Console.WriteLine("This triangle is isosceles");
                    sumOfIsosceles += area;
                }
                else
                {
                    Console.WriteLine("This triangle is not isosceles");
                }
                Console.WriteLine();
            }
            double avgSumOfPerimeters = sumOfRight / count;
            double avgSumOfArea = sumOfIsosceles / count;
            Console.WriteLine("Avg sum of right triangle's perimeters = {0}", avgSumOfPerimeters);
            Console.WriteLine("Avg sum of isoscele triangle's area = {0}", avgSumOfArea);
            Console.ReadLine();
        }
        public static Point[] AddPoints(Point[] points, Random Gen)
        {
            for (int j = 0; j < points.Length; j++)
            {
                points[j] = new Point(Gen.Next(1, 5), Gen.Next(1, 5));
            }
            while (points[0].X == points[1].X && points[0].Y == points[1].Y || points[1].X == points[2].X && points[1].Y == points[2].Y || points[0].X == points[2].X && points[0].Y == points[2].Y)
            {
                for (int b = 0; b < points.Length; b++)
                {
                    for (int c = 0; c < points.Length; c++)
                    {
                        if (points[b].X == points[c].X && points[b].Y == points[c].Y && b != c)
                        {
                            points[b].X = Gen.Next(1, 5);
                            points[b].Y = Gen.Next(1, 5);
                        }
                    }
                }
            }
            if (CheckPointsInTheOneStraight(points))
            {
                AddPoints(points, Gen);
            }
            return points;
        }
        public static bool CheckPointsInTheOneStraight(Point[] points)
        {
            if ((points[0].X - points[2].X) * (points[1].Y - points[2].Y) == (points[1].X - points[2].X) * (points[0].Y - points[2].Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Edge[] AddEdges(Edge[] edges, Point[] points)
        {
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
            return edges;
        }
        public static void PrintingSides(Edge[] edges, char[] character)
        {
            for (int b = 0; b < edges.Length; b++)
            {
                if (b == edges.Length - 1)
                {
                    Console.WriteLine("Side {0}{1} = {2}", character[b], character[0], edges[b].Side());
                }
                else
                {
                    Console.WriteLine("Side {0}{1} = {2}", character[b], character[b + 1], edges[b].Side());
                }
            }
        }
        public static void PrintingPoints(Point[] points, char[] character)
        {
            for (int b = 0; b < points.Length; b++)
            {
                Console.WriteLine("Point {0} ({1}, {2})", character[b], points[b].X, points[b].Y);
            }
        }
    }
}
