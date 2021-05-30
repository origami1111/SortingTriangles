using System;

namespace SortingTriangles
{
    class Triangle : IComparable<Triangle>
    {
        public string NameTriangle { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle() { }
        public Triangle(string nameTriangle, double sideA, double sideB, double sideC)
        {
            this.NameTriangle = nameTriangle;
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }

        public int CompareTo(Triangle other)
        {
            if (this.GetArea() > other.GetArea())
            {
                return -1;
            }   
            if (this.GetArea() < other.GetArea())
            {
                return 1;
            }
            else
            {
                return 0;
            }       
        }

        public void TriangleExists() // проверка на существование треугольника
        {
            if (!(SideA + SideB > SideC && SideA + SideC > SideB && SideB + SideC > SideA))
            {
                throw new Exception("Треугольник не может существовать!");
            }
        }

        public double GetArea()
        {
            double p = 0.5 * (SideA + SideB + SideC);

            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public override string ToString()
        {
            return $"[Triangle {NameTriangle}]: {Math.Round(GetArea(), 2)} cm";
        }

    }
}
