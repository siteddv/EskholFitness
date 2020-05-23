using System;

namespace EskholFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string ActivityName { get; set; }
        public double CaloriesPerMinute { get; set; }

        public Activity(string ActivityName, double CaloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(ActivityName))
            {
                throw new ArgumentNullException("Наименование активности не может быть пустым или равным null.", nameof(this.ActivityName));

            }

            this.ActivityName = ActivityName;
        }
        public override string ToString()
        {
            return $"Название активности: {ActivityName} Калорий на минуту: {CaloriesPerMinute}";
        }
    }
}
