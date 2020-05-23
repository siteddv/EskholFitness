using System;
using System.Globalization;
using System.Resources;
using EskholFitness.BL.Controller;
using EskholFitness.BL.Model;


namespace EskholFitness.CMD
{
    class Program
    {
        public static ResourceManager resourceManager { get; set; }
        public static CultureInfo culture { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите язык приложения / Select the app language\n\nНажмите на одну из предложенных клавиш / Click on one of the suggested keys\n\nr - Русский \nany another key - English ");
            
            
            culture = CultureInfo.CreateSpecificCulture((Console.ReadKey().Key == ConsoleKey.R)?"ru-ru": "en-us");

            resourceManager = new ResourceManager("EskholFitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.Clear();
            Console.WriteLine(resourceManager.GetString("Welcoming_msg", culture));
            Console.WriteLine();
            Console.WriteLine(resourceManager.GetString("EnterName_msg", culture));

            string name;
            while (true)
            {

                name = Console.ReadLine();
                if (name.Length > 1)
                {
                    break;
                }
                Console.WriteLine(resourceManager.GetString("ReapeatNameEntering_msg", culture));

            }

            UserController userController = new UserController(name);

            if (userController.IsNewUser)
            {

                Console.WriteLine(resourceManager.GetString("EnterGender_msg", culture));
                string genderName;

                while (true)
                {

                    genderName = Console.ReadLine();
                    if (genderName.Length > 1)
                    {
                        break;
                    }
                    Console.WriteLine(resourceManager.GetString("ReapeatGengerEntering_msg", culture));

                }

                Console.WriteLine(resourceManager.GetString("EnterBirthDate_msg", culture));

                DateTime birthDate;
                while (!(DateTime.TryParse(Console.ReadLine(), out birthDate) && birthDate > DateTime.Parse("1/1/1900") && birthDate < DateTime.Now))
                {
                    Console.WriteLine(resourceManager.GetString("RepeatBirthDateEntering_msg", culture));
                }

                Console.WriteLine(resourceManager.GetString("EnterWeight_msg", culture));
                double weight;
                while (!(double.TryParse(Console.ReadLine(), out weight) && weight > 0))
                {
                    Console.WriteLine(resourceManager.GetString("RepeatProductWeight_msg", culture));
                }

                Console.WriteLine(resourceManager.GetString("EnterHeight_msg", culture));
                double height;
                while (!(double.TryParse(Console.ReadLine(), out height) && height > 0))
                {
                    Console.WriteLine(resourceManager.GetString("RepeatHeightEntering_msg", culture));
                }

                userController.SetNewUserData(genderName, birthDate, weight, height);

                Console.WriteLine(resourceManager.GetString("Saved_msg", culture));

            }
            Console.WriteLine($"{resourceManager.GetString("EnterdUser_msg", culture)} : \n{userController.CurrentUser}");
            Console.WriteLine(resourceManager.GetString("ActionChoice_msg1", culture));

            var key = Console.ReadKey();
            Console.WriteLine();
            EatingController ec = new EatingController(userController.CurrentUser);
            if (key.Key == ConsoleKey.E)
            {
                var foodInfo = EnterEating();
                EatingController eatingController = new EatingController(userController.CurrentUser);
                eatingController.AddFood(foodInfo.food, foodInfo.weight);
            }

            Console.ReadKey();

        }
        private static (Food food, double weight) EnterEating()
        {
            Console.Write(resourceManager.GetString("EnterProductName_msg", culture));
            string foodName;
            while (true)
            {
                foodName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(foodName))
                {
                    break;
                }
                Console.WriteLine(resourceManager.GetString("RepeatProductNameEntering_msg", culture));
            }
            Console.ReadLine();
            Console.Write(resourceManager.GetString("EnterProductWeight_msg", culture));
            double weight;
            while (!double.TryParse(Console.ReadLine(), out weight) || weight<=0)
            {
                Console.WriteLine(resourceManager.GetString("RepeatProductWeight_msg", culture));
            }
            Food product = new Food(foodName);

            return (product, weight);

        }
    }
}

