using EskholFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EskholFitness.BL.Controller
{
    public class ExercizeController : BaseController
    {
        private readonly User User;
        public List<Exerсise> Exerсises { get; }
        public List<Activity> Activities { get; }

        public ExercizeController(User User)
        {
            this.User = User ?? throw new ArgumentException("Пользователь не может быть пустым.", nameof(User));
            Exerсises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void AddExercise(Activity activity, DateTime startTime, DateTime endTime)
        {
            Activity act = Activities.SingleOrDefault(a => a.ActivityName.Equals(activity.ActivityName));
            Exerсise exercise;
            if (act == null)
            {
                Activities.Add(activity);
                exercise = new Exerсise(startTime, endTime, activity, User);
                
            }
            else
            {
                exercise = new Exerсise(startTime, endTime, act, User);
            }
            Exerсises.Add(exercise);
            Save();
            
        }

        private List<Activity> GetAllActivities()
        {
            return GetData<Activity>() ?? new List<Activity>();
        }

        private List<Exerсise> GetAllExercises()
        {
            return GetData<Exerсise>() ?? new List<Exerсise>();
        }
        private void Save()
        {
            SaveData(Activities);
            SaveData(Exerсises);
        }

    }
}
