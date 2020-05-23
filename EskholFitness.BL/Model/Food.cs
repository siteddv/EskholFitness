using System;

namespace EskholFitness.BL.Model
{
    public class Food
    {
        /// <summary>
        /// Наименование продукта
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Белки на 1 гр продукта
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры на 1 гр продукта
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы на 1 гр продукта
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории на 1 гр продукта
        /// </summary>
        public double Calories { get; }

        public Food(string name) : this(name, 0, 0, 0, 0) { }
        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException("Наименование продукта не может быть пустым или равным null.", nameof(Name));
            }

            if(proteins <= 0)
            {
                throw new ArgumentException("Значение протеинов не должно быть меньше либо равно нулю", nameof(proteins));
            }

            if(fats <= 0)
            {
                throw new ArgumentException("Значение жиров не должно быть меньше либо равно нулю", nameof(proteins));
            }
            if (carbohydrates <= 0)
            {
                throw new ArgumentException("Значение углеводов не должно быть меньше либо равно нулю", nameof(proteins));
            }
            if (calories <= 0)
            {
                throw new ArgumentException("Значение калорий не должно быть меньше либо равно нулю", nameof(proteins));
            }

            Name = name;
            Proteins = proteins / 100;
            Fats = fats / 100;
            Carbohydrates = carbohydrates / 100;
            Calories = calories / 100;
        }
        public override string ToString()
        {
            return $"Наименование продукта: {Name}\n Далее все значения рассчитаны на 100 гр. продукта\nБелки: {Proteins*100} гр.\nЖиры: {Fats * 100} гр.\nУглеводы: {Carbohydrates * 100} гр.\nПищевая ценность: {Calories * 100} ККал";
        }

    }
}
