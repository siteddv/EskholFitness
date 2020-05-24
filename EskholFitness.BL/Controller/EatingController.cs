using EskholFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EskholFitness.BL.Controller
{

    public class EatingController : BaseController
    {
        private readonly User user;
        public List<Food> Foods { get; set; }
        public Eating Eatings { get; set; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentException("Пользователь не может быть пустым", nameof(user));
            Foods = GetAllFoods();
            Eatings = GetEating();
        }

        private Eating GetEating()
        {
            return GetData<Eating>().FirstOrDefault() ?? new Eating(user);
        }


        public void AddFood(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food);
            }
            else
            {
                Eatings.Add(product, weight);
            }
            Save();
        }


        public List<Food> GetAllFoods()
        {
            return GetData<Food>() ?? new List<Food>();
        }
        public void Save()
        {
            SaveData(Foods);
            SaveData(new List<Eating>() { Eatings });
        }
    }
}
