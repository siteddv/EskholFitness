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
                Console.WriteLine("Повторите ввод имени:");
            }
            UserController uc = new UserController(name);
            if (uc.IsNewUser)
            {
                Console.WriteLine("Введитe свой пол:");
                string genderName = Console.ReadLine();
                Console.WriteLine("Введитe свою дату рождения:(вида dd/mm/yyyy рождения)");
                DateTime birthDate;
                while (true)
                {
                    if (DateTime.TryParse(Console.ReadLine(), out birthDate) && birthDate > DateTime.Parse("1/1/1900") && birthDate < DateTime.Now)
                    {
                        break;
                    }
                    Console.WriteLine($"Повторите ввод даты рождения:");
                }
                Console.WriteLine("Введитe свой вес:");
                double weight;
                while (true)
                {
                    if (double.TryParse(Console.ReadLine(), out weight) && weight > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Повторите ввод веса:");
                }
                Console.WriteLine("Введитe свой рост:");
                double height;
                while (true)
                {
                    if (double.TryParse(Console.ReadLine(), out height) && height > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Повторите ввод роста:");
                }
                uc.SetNewUserData(genderName, birthDate, weight, height);
                Console.Write("Сохранено");
            }
            Console.WriteLine($"\nВы ввели пльзователя : {uc.CurrentUser}");
            Console.ReadKey();
        }
    }
}
