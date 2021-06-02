using System;

namespace SortingTriangles
{
    class Triangle
    {
        public string nameTriangle;
        public double sideA;
        public double sideB;
        public double sideC;

        public Triangle() { }
        public Triangle(string nameTriangle, double sideA, double sideB, double sideC)
        {
            this.nameTriangle = nameTriangle;
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public void TriangleExists() // проверка на существование треугольника
        {
            if (!(sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA))
            {
                throw new Exception("Треугольник не может существовать!");
            }
        }

        public double GetArea()
        {
            double p = 0.5 * (sideA + sideB + sideC);

            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }

        public override string ToString()
        {
            return $"[Triangle {nameTriangle}]: {Math.Round(GetArea(), 2)} cm^2";
        }

    }
}
