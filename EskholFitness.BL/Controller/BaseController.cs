using System.Collections.Generic;

namespace EskholFitness.BL.Controller
{
    public abstract class BaseController
    {
        private readonly IDataSaver manager = new SerializeDataSaver();//поменяв SerializeDataSaver на DatabaseDataSaver можно сохранять данные в базу данных
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
