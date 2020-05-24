using System;
using System.Collections;
using System.Collections.Generic;

namespace EskholFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int ID { get; set; }
        public string ActivityName { get; set; }
        public double CaloriesPerMinute { get; set; }
        public virtual ICollection <Exerсise> Exercises { get; set; }
        public Activity() { }

        public Activity(string ActivityName, double CaloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(ActivityName))
            {
                throw new ArgumentNullException("Наименование активности не может быть пустым или равным null.", nameof(this.ActivityName));

            }
            if (CaloriesPerMinute <= 0)
            {
                throw new ArgumentException("Энергозатраты на выполнение упражнения не могут быть меньше либо равным нулю", nameof(CaloriesPerMinute));
            }
            this.ActivityName = ActivityName;
            this.CaloriesPerMinute = CaloriesPerMinute;
        }
        public override string ToString()
        {
            return $"Название активности: {ActivityName} Калорий на минуту: {CaloriesPerMinute}";
        }
    }
}
