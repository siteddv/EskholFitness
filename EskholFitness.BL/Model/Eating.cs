using System;
using System.Collections.Generic;
using System.Linq;

namespace EskholFitness.BL.Model
{
    [Serializable]
    public class Eating
    {
        public int ID { get; set; }
        public DateTime EatingMoment { get; set; }
        public int UserID { get; set; }
        public Dictionary<Food, double> Foods {get;}
        public virtual User user { get; }
        public Eating() { }
        public Eating(User user)
        {
            this.user = user ?? throw new ArgumentException("Пользователь не может быть пустым", nameof(user));
            EatingMoment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
