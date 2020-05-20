using EskholFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EskholFitness.BL.Controller
{
    public class UserController
    {
        public User user { get; set; }

        public UserController(string userName, string gender, DateTime birthDate, double weight, double height)
        {
            Gender gen = new Gender(gender);
            user = new User(userName, gen, birthDate, weight, height);

        }
        public UserController()
        {
            using (FileStream fs = new FileStream("file.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                if(bf.Deserialize(fs) is User user)
                {
                    this.user = user;
                }
            }

        }
        public void Save()
        {
            using (FileStream fs = new FileStream("file.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, user);
            }
        }
        public User Load()
        {
            using (FileStream fs = new FileStream("file.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                if (bf.Deserialize(fs) is User user)
                {
                    this.user = user;
                }
            }
            return user;
        }
    }
}
