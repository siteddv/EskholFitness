using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EskholFitness.BL.Controller
{
    public abstract class BaseController
    {
        protected T GetData<T>(string filePath) where T : class
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                if (fs.Length > 0 && bf.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
        protected void SaveData(string filePath, object item)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, item);
            }
        }
    }
}
