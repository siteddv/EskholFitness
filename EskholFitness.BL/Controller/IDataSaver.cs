using System;
using System.Collections.Generic;

namespace EskholFitness.BL.Controller
{
    public interface IDataSaver
    {
        void SaveData<T>(List<T> items) where T:class;
        List<T> GetData<T>() where T : class;
    }
}
