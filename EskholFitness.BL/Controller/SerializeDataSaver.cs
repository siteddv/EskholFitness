using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EskholFitness.BL.Controller
{
    public class SerializeDataSaver : IDataSaver
    {
        
        public List<T> GetData<T>() where T:class
        {
            BinaryFormatter bf = new BinaryFormatter();

            string filePath = typeof(T).Name;

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && bf.Deserialize(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public void SaveData<T>(List<T> items) where T:class
        {
            string filePath = typeof(T).Name;
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, items);
            }
        }
    }
}
