using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp23._1
{
    internal class Program
    {
        static int n1;
        static int n;
        static int[] number;
        public static void Main()
        {
            Start();
            Task.Run(() => FactorialMenu());
            
            Console.ReadKey();
        }
        public static void Start()
        {
        Start1:
            try
            {
                Console.Write("Задайте любое целочисленное значение для вычисления факториала: ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n == 0 || n == 1)
                {
                    Console.WriteLine("Факториал числа 0 и числа 1 всегда равен 1");
                    Console.WriteLine();
                    Program.Main();
                }
                else if (n < 0)
                {
                    Console.WriteLine("Факториал вычисляется только для целых натуральных чисел!");
                    Console.WriteLine();
                    Program.Main();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Входная строка имела неверный формат!");
                Console.WriteLine();
                goto Start1;
            }
        }

        public static void Factorial1()
        {
            Console.WriteLine("Factorial1 начал работу");
            n1 = n;
            number = new int[n];
            Console.WriteLine();
            Console.WriteLine("Получаем значения...");
            Console.WriteLine();
            for (int i = 1; i < n1; i++)
            {
                Thread.Sleep(100);
                Console.Write($"Число {i}");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Factorial1 окончил работу");
        }
        public static void Factorial2()
        {
            Console.WriteLine("Factorial2 начал работу");
            Thread.Sleep(100);
            List<int> factorial = new List<int>();
            for (int i = 1; i < number.Length; i++)
            {
                number[i] = i;
                int f = n *= i;
                factorial.Add(f);
                Console.Write(" = ");
                //Console.Write("{0, 2} ", i);
                Console.WriteLine("{0, 2} ", f);
                Thread.Sleep(1200);
            }
            Console.WriteLine();
            Console.WriteLine("Факториал числа {0} равен {1}", n1, factorial.Max());
            Console.WriteLine();
            Console.WriteLine("Factorial2 окончил работу");
        }
        public static async Task Factorial2Async()
        {
            
            Console.WriteLine("Factorial2Async начал работу");
            await Task.Run(() => Factorial2());
            Console.WriteLine("Factorial2Async окончил работу");
            
        }
        public static async Task Factorial1Async()
        {
            Console.WriteLine("Factorial1Async начал работу");
            await Task.Run(() => Factorial1());
            Console.WriteLine("Factorial1Async окончил работу");
        }
        public static async Task FactorialMenu()
        {
            await Task.WhenAll(Factorial1Async(), Factorial2Async());
            Console.WriteLine();
            Thread.Sleep(500);
            
        }
    }
    class Menu
    {
        public static Task ReturnMenu()
        {
            Console.WriteLine("Вычислить факториал другого числа?");
            Console.WriteLine("     1. Да");
            Console.WriteLine("     2. Нет");
            Console.WriteLine();

        Start2:
            Console.Write("Ваш выбор: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    Program.Main();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Такого параметра не существует!");
                    Console.WriteLine();
                    goto Start2;
            }
            return Task.CompletedTask;
        }
    }
}
