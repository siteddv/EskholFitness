using EskholFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EskholFitness.BL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public List<T> GetData<T>() where T:class
        {
            using (FitnessContext db = new FitnessContext())
            {
                return db.Set<T>().Where(l => true).ToList();
            }
        }

        public void SaveData<T>(List<T> items) where T : class
        {
            using(FitnessContext db = new FitnessContext())
            {
                db.Set<T>().AddRange(items);
                db.SaveChanges();
            }
        }
    }
}
