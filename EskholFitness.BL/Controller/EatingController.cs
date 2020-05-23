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
        private const string EATING_FILE_NAME = "eating.dat";
        private readonly User user;
        public List<Food> Foods { get; set; }
        public FoodEating Eating { get; set; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentException("Пользователь не может быть пустым", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        private FoodEating GetEating()
        {
            return GetData<FoodEating>(EATING_FILE_NAME) ?? new FoodEating(user);
        }


        public void AddFood(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food);
            }
            Eating.Add(food, weight);
            Save();
        }


        public List<Food> GetAllFoods()
        {
            return GetData<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }
        public void Save()
        {
            SaveData(FOOD_FILE_NAME, Foods);
            SaveData(EATING_FILE_NAME, Eating);
        }
    }
}
