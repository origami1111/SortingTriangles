using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingTriangles
{
    class Triangle : IComparable<Triangle>
    {
        private string name;
        private double a;
        private double b;
        private double c;

        public Triangle() { }
        public Triangle(string name, double a, double b, double c)
        {
            this.name = name;
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public int CompareTo(Triangle other)
        {
            if (this.getArea() > other.getArea())
                return -1;
            if (this.getArea() < other.getArea())
                return 1;
            else
                return 0;
        }

        public double getArea()
        {
            double p = 0.5 * (a + b + c);

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public override string ToString()
        {
            return $"[Triangle {name}]: {Math.Round(getArea(), 2)} cm";
        }

    }
}
