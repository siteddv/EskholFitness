using System.Collections.Generic;

namespace EskholFitness.BL.Controller
{
    public abstract class BaseController
    {
        private readonly IDataSaver manager = new SerializeDataSaver();
        protected List<T> GetData<T>() where T:class
        {
            return manager.GetData<T>();
        }
        protected void SaveData<T>(List<T> items) where T : class
        {
            manager.SaveData(items);
        }
    }
}
