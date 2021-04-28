using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            bool flag = true;

            string input;
            string[] parameters;

            string name = "";
            double a = 0.0, b = 0.0, c = 0.0;

            Triangle triangle;
            List<Triangle> triangles = new List<Triangle>();

            do
            {
                while (flag)
                {
                    Console.Write("Формат ввода (разделитель - запятая): <имя>, <длина стороны>, <длина стороны>, <длина стороны> \n > ");
                    input = Console.ReadLine();

                    parameters = input.Split(',');

                    name = parameters[0].Trim();
                    try
                    {
                        a = double.Parse(parameters[1], CultureInfo.InvariantCulture);
                        b = double.Parse(parameters[2], CultureInfo.InvariantCulture);
                        c = double.Parse(parameters[3], CultureInfo.InvariantCulture);

                        flag = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }


                triangle = new Triangle(name, a, b, c);
                triangles.Add(triangle);

                Console.Write("Продолжить ввод(y/yes)? > ");
                answer = Console.ReadLine().ToLower();
            } while (answer == "y" || answer == "yes");

            Console.WriteLine("============= Triangles list: ===============");
            triangles.Sort();
            for (int i = 0; i < triangles.Count; i++)
                Console.WriteLine($"{i + 1}. {triangles[i]}");

            Console.WriteLine("Программа завершена");
            Console.ReadLine();
        }
    }
}
