using System;

namespace EskholFitness.BL.Model
{
    [Serializable]
    public class Gender
    {
        public string genderName { get; }
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
