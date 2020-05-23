using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EskholFitness.BL.Model
{
    [Serializable]
    public class Exerсise
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Activity Activity { get; set; }
        public User User { get; set; }
        public Exerсise(DateTime StartTime, DateTime EndTime, Activity Activity, User User)
        {
            if (StartTime > DateTime.Now)
            {
                throw new ArgumentException("Время старта упражнения не может быть позже, чем сейчас.", nameof(StartTime));
            }
            if (EndTime < DateTime.Parse("1/1/1900") || EndTime > DateTime.Now)
            {
                throw new ArgumentException("Время окончания упражнения не может быть позже, чем сейчас.", nameof(EndTime));
            }
            if (EndTime <= StartTime)
            {
                throw new ArgumentException("Время окончания упражнения не должно совпадать или быть меньше, чем время его начало", nameof(EndTime));
            }
            this.Activity = Activity ?? throw new ArgumentException("Активность не может быть пустой.", nameof(Activity));
            this.User = User ?? throw new ArgumentException("Пользователь не может быть пустым.", nameof(User));
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }
    }
}
