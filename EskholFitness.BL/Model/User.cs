using System;

namespace EskholFitness.BL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Serializable]
    public class User
    {
        #region свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string userName { get; private set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender gender { get; private set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime birthDate { get; private set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double weight { get; private set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double height { get; private set; }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="userName">Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="bithDate">Дата рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="height">Рост</param>
        #endregion
        public User(string userName, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или равным null.", nameof(userName));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Пол пользователя не может быть null.", nameof(gender));
            }
            if(birthDate < DateTime.Parse("1/1/1900") || birthDate > DateTime.Now)
            {
                throw new ArgumentException($"Пользователь не можеть быть старше {DateTime.Now.Year-1900} лет.", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вес пользователя не можеть быть меньше или равным нулю.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Рост пользователя не можеть быть меньше или равным нулю.", nameof(height));
            }
            #endregion
            this.userName = userName;
            this.gender = gender;
            this.birthDate = birthDate;
            this.weight = weight;
            this.height = height;
        }
        public override string ToString()
        {
            return $"Имя: {userName} Пол: {gender} Дата рождения: {birthDate} Вес: {weight} Рост: {height}";
        }
    }
}
