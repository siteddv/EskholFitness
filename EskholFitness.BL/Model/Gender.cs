using System;
using System.Collections.Generic;
using System.Globalization;

namespace EskholFitness.BL.Model
{
    [Serializable]
    public class Gender
    {
        public int ID { get; set; }
        public string genderName { get; set; }
        public virtual ICollection <User> Users { get; set; }
        public Gender() { }
        public Gender (string genderName)
        {
            if (string.IsNullOrWhiteSpace(genderName))
            {
                throw new ArgumentNullException("Название пола не можеть быть пустым или null", nameof(genderName));
            }
            this.genderName = genderName;
        }
        public override string ToString()
        {
            return genderName;
        }

    }
}
