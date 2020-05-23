using EskholFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace EskholFitness.BL.Controller
{

    public class EatingController : BaseController
    {
        private const string FOOD_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        private readonly User user;
        public List<Food> Foods { get; set; }
        public List <FoodEating> Eatings { get; set; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentException("Пользователь не может быть пустым", nameof(user));
            Foods = GetAllFoods();
            Eatings = GetAllEatings();
        }

        private List<FoodEating> GetAllEatings()
        {
            return GetData<List<FoodEating>>(EATINGS_FILE_NAME) ?? new List<FoodEating>();
        }

        public void AddFood(string foodName, double weight)
        {
            var food = Foods.SingleOrDefault(f => f.Name.Equals(foodName));
            if (food == null)
            {
                Foods.Add(food);
            }
            else
            {
                food.Calories += weight
            }
        }

        public List<Food> GetAllFoods()
        {
            return GetData<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }
        public void Save()
        {
            SaveData(FOOD_FILE_NAME, Foods);
            SaveData(EATINGS_FILE_NAME, Eatings);
        }
    }
}
