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
    }
    class Edge
    {
        public Point start = new Point();
        public Point end = new Point();
    }
    class Triangle
    {
        public Edge ab = new Edge();
        public Edge bc = new Edge();
        public Edge ac = new Edge();
        //public int a;
        //public int b;
        //public int c;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random Gen = new Random();
            double sumOfRight = 0;
            double sumOfIsosceles = 0;
            Triangle[] triangles = new Triangle[10];
            int count = triangles.Length;
            for (int i = 0; i < triangles.Length; i++)
            {
                triangles[i] = new Triangle();
                triangles[i].ab.start.X = Gen.Next(1, 3);
                triangles[i].ab.end.X = Gen.Next(4, 10);
                triangles[i].ab.start.Y = Gen.Next(1, 3);
                triangles[i].ab.end.Y = Gen.Next(4, 10);
                double ab = Side(triangles[i].ab.start.X, triangles[i].ab.end.X, triangles[i].ab.start.Y, triangles[i].ab.end.Y);
                triangles[i].bc.start.X = triangles[i].ab.end.X;
                triangles[i].bc.end.X = Gen.Next(4, 6);
                triangles[i].bc.start.Y = triangles[i].ab.end.Y;
                triangles[i].bc.end.Y = Gen.Next(5, 10);
                double bc = Side(triangles[i].bc.start.X, triangles[i].bc.end.X, triangles[i].bc.start.Y, triangles[i].bc.end.Y);
                triangles[i].ac.start.X = triangles[i].ab.start.X;
                triangles[i].ac.end.X = triangles[i].bc.end.X;
                triangles[i].ac.start.Y = triangles[i].ab.start.Y;
                triangles[i].ac.end.Y = triangles[i].bc.end.Y;
                double ac = Side(triangles[i].ac.start.X, triangles[i].ac.end.X, triangles[i].ac.start.Y, triangles[i].ac.end.Y);
                Console.WriteLine("Triangle {0} with sides: AB = {1}, BC = {2}, AC = {3}", i + 1, ab, bc, ac);
                double perimeter = Perimeter(ab, bc, ac);
                double area = Area(ab, bc, ac);
                bool isoscelesTriangle = Isosceles(ab, bc, ac);
                bool rightTriangle = Right(ab, bc, ac);
                if (isoscelesTriangle == true)
                {
                    sumOfIsosceles += area;
                }
                if (rightTriangle == true)
                {
                    sumOfRight += perimeter;
                }
                Console.WriteLine();
            }
            double avgSumOfPerimeters = sumOfRight / count;
            double avgSumOfArea = sumOfIsosceles / count;
            Console.WriteLine("Avg sum of right triangle's perimeters = {0}", avgSumOfPerimeters);
            Console.WriteLine("Avg sum of isoscele triangle's area = {0}", avgSumOfArea);
            Console.ReadLine();
        }
        public static double Side(int x1, int x2, int y1, int y2)
        {
            double side = Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)), 0);
            return side;
        }
        public static double Perimeter(double ab, double bc, double ac)
        {
            double perimeter = ab + bc + ac;
            Console.WriteLine("Perimeter of triangle = " + perimeter);
            return perimeter;
        }
        public static double Area(double ab, double bc, double ac)
        {
            double p = (ab + bc + ac) / 2;
            double area = Math.Round(Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac)), 2);
            if (area == null)
            {
                Console.WriteLine("Area is doesn't exist or it has negative result");
                return 0;
            }
            else
            {
                Console.WriteLine("Area of triangle = " + area);
                return area;
            }
        }
        public static bool Isosceles(double ab, double bc, double ac)
        {
            if (ab == bc || bc == ac || ab == ac)
            {
                Console.WriteLine("This triangle is isosceles");
                return true;
            }
            else
            {
                Console.WriteLine("This triangle is not isosceles");
                return false;
            }
        }
        public static bool Right(double ab, double bc, double ac)
        {
            if (Math.Pow(ab, 2) + Math.Pow(bc, 2) == Math.Pow(ac, 2))
            {
                Console.WriteLine("This triangle is right");
                return true;
            }
            else if (Math.Pow(ab, 2) + Math.Pow(ac, 2) == Math.Pow(bc, 2))
            {
                Console.WriteLine("This triangle is right");
                return true;
            }
            else if (Math.Pow(ac, 2) + Math.Pow(bc, 2) == Math.Pow(ab, 2))
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

    }
}
