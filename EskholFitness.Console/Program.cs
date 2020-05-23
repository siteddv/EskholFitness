using System;
using System.Linq;
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

            UserController userController = new UserController(name);

            if (userController.IsNewUser)
            {

                Console.WriteLine("Введитe свой пол:");
                string genderName = Console.ReadLine();
                Console.WriteLine("Введитe свою дату рождения:(вида dd/mm/yyyy рождения)");
                
                DateTime birthDate;
                while (!(DateTime.TryParse(Console.ReadLine(), out birthDate) && birthDate > DateTime.Parse("1/1/1900") && birthDate < DateTime.Now))
                {
                    Console.WriteLine($"Повторите ввод даты рождения:");
                }

                Console.WriteLine("Введитe свой вес:");
                double weight;
                while (!(double.TryParse(Console.ReadLine(), out weight) && weight > 0))
                {
                    Console.WriteLine("Повторите ввод веса:");
                }

                Console.WriteLine("Введитe свой рост:");
                double height;
                while (!(double.TryParse(Console.ReadLine(), out height) && height > 0))
                {
                    Console.WriteLine("Повторите ввод роста:");
                }

                userController.SetNewUserData(genderName, birthDate, weight, height);

                Console.Write("Сохранено");

            }
            Console.WriteLine($"\nВы ввели пльзователя : {userController.CurrentUser}");
            Console.WriteLine("Что Вы хотите сделать?\ne - ввести новый прием пищи.");

            var key = Console.ReadKey();
            Console.WriteLine();
            EatingController ec = new EatingController(userController.CurrentUser);
            if(key.Key == ConsoleKey.E)
            {
                var foodInfo = EnterEating();
                EatingController eatingController = new EatingController(userController.CurrentUser);
                eatingController.AddFood(foodInfo.food, foodInfo.weight);
            }

            Console.ReadKey();

        }
        private static (Food food, double weight) EnterEating()
        {
            Console.Write("Введите наименование продукта: ");
            string foodName;
            while (true)
            {
                foodName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(foodName))
                {
                    break;
                }
                Console.WriteLine("Повторите ввод. Имя пользователя не может быть пустым.");
            }
            Console.ReadLine();
            Console.Write("Введите вес порции: ");
            double weight;
            while(!double.TryParse(Console.ReadLine(), out weight))
            {
                Console.WriteLine("Повторите ввод. Не получилось преобразовать в дробное число.");
            }
            Food product = new Food(foodName);
            
            return (product, weight);

        }
    }
}
