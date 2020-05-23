using System;
using System.Collections.Generic;
using System.Linq;

namespace EskholFitness.BL.Model
{
    public class FoodEating
    {
        public DateTime EatingMoment { get; }
        public Dictionary<Food, double> Foods {get;}
        public User user { get; }
        public FoodEating(User user)
        {
            this.user = user ?? throw new ArgumentException("Пользователь не может быть пустым", nameof(user));
            EatingMoment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        public void Add(Food food, double weight)
        {
            var attemptForFindingTheSameFood = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (attemptForFindingTheSameFood == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[attemptForFindingTheSameFood] += weight;
            }
        }
    }
}
