using System;
using System.Collections.Generic;
using System.Globalization;

namespace SortingTriangles
{
    class View
    {
        private void PrintTask()
        {
            Console.WriteLine("==============================================================================");
            Console.WriteLine("Разработать консольную программу, выполняющую вывод треугольников в порядке убывания их площади. " +
                "После добавления каждого нового треугольника программа спрашивает, хочет ли пользователь добавить ещё один. " +
                "Если пользователь ответит “y” или “yes” (без учёта регистра), программа попросит ввести данные для ещё одного " +
                "треугольника, в противном случае – выводит результат в консоль." +
                "\n - Расчёт площади треугольника должен производится по формуле Герона." +
                "\n - Каждый треугольник определяется именем и длинами его сторон." +
                "\n Формат ввода(разделитель - запятая): " +
                "\n <имя>, <длина стороны>, <длина стороны>, <длина стороны>" +
                "\n - Приложение должно обрабатывать ввод чисел с плавающей точкой." +
                "\n - Ввод должен быть нечувствителен к регистру, пробелам, табам." +
                "\n - Вывод данных должен быть следующем примере:" +
                "\n============= Triangles list: ===============" +
                "\n1. [Triangle first]: 17.23 сm" +
                "\n2. [Triangle 22]: 13 cm" +
                "\n3. [Triangle 1]: 1.5 cm");
            Console.WriteLine("==============================================================================");
        }
        private void PrintHelp()
        {
            Console.WriteLine("==============================================================================");
            Console.WriteLine("Возможные аргументы: " +
                              "\n-help - информация о возможных аргументах" +
                              "\n-task - информация о задачу");
            Console.WriteLine("==============================================================================");
        }
        public void CheckArguments(string[] args)
        {
            if (args.Length == 0)
            {
                PrintHelp();
            }
            else
            {
                foreach (var arg in args)
                {
                    switch (arg)
                    {
                        case "-help":
                            PrintHelp();
                            break;
                        case "-task":
                            PrintTask();
                            break;
                        default:
                            Console.WriteLine("Указанного аргумента не существует. Чтобы посмотреть список аргументов, укажите '-help'");
                            break;
                    }
                }
            }
        }

        private List<Triangle> SetTriangles()
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            string answer;
            bool flag;

            string inputString;
            string[] parameters;

            string name;
            double a, b, c;

            Triangle triangle = new Triangle();
            List<Triangle> triangles = new List<Triangle>();

            do
            {
                flag = true;
                while (flag)
                {
                    Console.Write("Формат ввода (разделитель - запятая): " +
                        "<имя>, <длина стороны>, <длина стороны>, <длина стороны> \n > ");
                    inputString = Console.ReadLine();

                    parameters = inputString.Split(',');

                    name = parameters[0].Trim();
                    try
                    {
                        a = double.Parse(parameters[1], formatter);
                        b = double.Parse(parameters[2], formatter);
                        c = double.Parse(parameters[3], formatter);

                        triangle = new Triangle(name, a, b, c);
                        triangle.TriangleExists();

                        flag = false;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Было введено слишком мало или слишком много параметров!");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Параметры введены неверно!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                triangles.Add(triangle);

                Console.Write("Продолжить ввод(y/yes)? > ");
                answer = Console.ReadLine().ToLower();

            } while (answer == "y" || answer == "yes");

            return triangles;
        }

        private void PrintTriangles(List<Triangle> triangles)
        {
            Console.WriteLine("============= Triangles list: ===============");
            SortTriangles(triangles);
            for (int i = 0; i < triangles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {triangles[i]}");
            }
        }

        private void SortTriangles(List<Triangle> triangles)
        {
            for (int i = 0; i < triangles.Count; i++)
            {
                for (int j = i + 1; j < triangles.Count; j++)
                {
                    if (triangles[i].GetArea() < triangles[j].GetArea())
                    {
                        Triangle temp = triangles[i];
                        triangles[i] = triangles[j];
                        triangles[j] = temp;
                    }
                }
            }
        }

        public void GetTriangles()
        {
            List<Triangle> triangles = SetTriangles();
            PrintTriangles(triangles);
        }
    }
}
