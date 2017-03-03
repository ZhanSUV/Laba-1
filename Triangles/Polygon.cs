using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles
{
    class Polygon
    {
        public Point[] points;
        public Edge[] edges;
        public Triangle[] triangles;
        public Edge[] edgesOfTriangles = new Edge[3];
        public double area = 0;
        private bool[] takenPoints;
        public Polygon(Point[] points, Edge[] edges)
        {
            this.points = points;
            this.edges = edges;
        }
        public void Triangulation()
        {
            triangles = new Triangle[points.Length - 2];
            takenPoints = new bool[points.Length];
            int CountOfPoints = points.Length;
            int A = 0;
            int B = 1;
            int C = 2;
            int numberOfTriangle = 0;
            int count = 0;
            Point[] pointsOfTriangle = new Point[3];
            while (CountOfPoints > 3)
            {
                pointsOfTriangle[0] = points[A];
                pointsOfTriangle[1] = points[B];
                pointsOfTriangle[2] = points[C];
                edgesOfTriangles = AddEdges(edgesOfTriangles, pointsOfTriangle);
                triangles[numberOfTriangle] = new Triangle(pointsOfTriangle, edgesOfTriangles);
                area += triangles[numberOfTriangle].Area();
                takenPoints[B] = true;
                CountOfPoints--;
                A++;
                B++;
                C++;
                if (triangles != null) //если триангуляция была проведена успешно
                    triangles[numberOfTriangle] = new Triangle(pointsOfTriangle, edgesOfTriangles);
                count++;
            }

        }
        public Edge[] AddEdges(Edge[] edges, Point[] points)
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
        public double Perimeter()
        {
            double perimeter = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                perimeter += edges[i].Side();
            }
            return perimeter;
        }
    }
}
