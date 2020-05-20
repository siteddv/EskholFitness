using System;
using EskholFitness.BL.Controller;
using EskholFitness.BL.Model;


namespace EskholFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует программа EskholFitness!");
            Console.WriteLine("Введитe свое имя:");
            string name;
            while (true)
            {
                name = Console.ReadLine();
                if (name.Length > 1)
                {
                    break;
                }
                Console.WriteLine("Повторите ввод. Имя не может быть короче двух символов.");
            }
            Console.WriteLine("Введитe свой пол:");
            string gender = Console.ReadLine();
            Console.WriteLine("Введитe свой день рождения:(вида день/месяц/год рождения)");
            DateTime birthDate;
            while (true)
            {
                birthDate = DateTime.Parse(Console.ReadLine());
                if (birthDate > DateTime.Parse("1/1/1900") && birthDate < DateTime.Now)
                {
                    break;
                }
                Console.WriteLine($"Повторите ввод. Пользователь не можеть быть старше {DateTime.Now.Year-1900} лет."); 
            }
            Console.WriteLine("Введитe свой вес:");
            double weight;
            while (true)
            {
                weight = double.Parse(Console.ReadLine());
                if (weight > 0)
                {
                    break;
                }
                Console.WriteLine("Повторите ввод. Вес пользователя не можеть быть меньше или равным нулю.");
            }
            Console.WriteLine("Введитe свой рост:");
            double height;
            while (true)
            {
                height = double.Parse(Console.ReadLine());
                if (height > 0)
                {
                    break;
                }
                Console.WriteLine("Повторите ввод. Рост пользователя не можеть быть меньше или равным нулю.");
            }
            UserController uc = new UserController(name, gender, birthDate, weight, height);
            uc.Save();
            Console.WriteLine($"Сохранено\nВы ввели пльзователя : {uc.Load()}");
            Console.ReadKey();

        }
    }
}
