﻿using System;
using System.Collections.Generic;

namespace EskholFitness.BL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Serializable]
    public class User
    {
        #region свойства
        public int ID { get; set; }
        /// <summary>
        /// Имя.
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public int? GenderID { get; set; }
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        public int Age {
            get
            {
                
                if(DateTime.Now.Month < BirthDate.Month)
                {
                    return DateTime.Now.Year - BirthDate.Year-1;
                }else if (DateTime.Now.Month > BirthDate.Month)
                {
                    return DateTime.Now.Year - BirthDate.Year;
                }
                else
                {
                    if (DateTime.Now.Day >= BirthDate.Day)
                    {
                        return DateTime.Now.Year - BirthDate.Year;
                    }
                    else
                    {
                        return DateTime.Now.Year - BirthDate.Year - 1;
                    }
                }
            }  
        } 
        public virtual ICollection <Eating> Eatings { get; set; }
        public virtual ICollection<Exerсise> Exerсises { get; set; }

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
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.Weight = weight;
            this.Height = height;
        }
        public User(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("ErrorNullUserName", nameof(userName));
            }
            this.userName = userName;
        }
        public User() { }
        public override string ToString()
        {
            return $"Имя: {userName} Пол: {Gender} Возрат: {Age} Вес: {Weight} Рост: {Height}";
        }
    }
}
