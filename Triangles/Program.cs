﻿using System;
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