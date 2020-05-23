using EskholFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EskholFitness.BL.Controller
{
    public class ExercizeController : BaseController
    {
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        private readonly User User;
        public List<Exerсise> Exerсises;
        public List<Activity> Activities;

        public ExercizeController(User User)
        {
            this.User = User ?? throw new ArgumentException("Пользователь не может быть пустым.", nameof(User));
            Exerсises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void AddExercise(Activity activity, DateTime startTime, DateTime endTime)
        {
            Activity act = Activities.SingleOrDefault(a => a.ActivityName.Equals(activity.ActivityName));
            if (act == null)
            {
                Activities.Add(activity);

            }
            Exerсises.Add(new Exerсise(startTime, endTime, activity, User));
            Save();
            
        }

        private List<Activity> GetAllActivities()
        {
            return GetData<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        private List<Exerсise> GetAllExercises()
        {
            return GetData<List<Exerсise>>(EXERCISES_FILE_NAME) ?? new List<Exerсise>();
        }
        private void Save()
        {
            SaveData(ACTIVITIES_FILE_NAME, Activities);
            SaveData(EXERCISES_FILE_NAME, Exerсises);
        }

    }
}
