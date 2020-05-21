using EskholFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace EskholFitness.BL.Controller
{
    public class UserController
    {
        public List <User> users { get; set; }
        public User CurrentUser { get; set; }

        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым");
            }
            else
            {
                users = GetUsersData();
                CurrentUser = users.SingleOrDefault(u => u.userName == userName);
                if(CurrentUser == null)
                {
                    CurrentUser = new User(userName);
                    users.Add(CurrentUser);
                    Save();
                    IsNewUser = true;
                }
            }

        }
        public UserController()
        {
            GetUsersData();

        }
        public void Save()
        {
            using (FileStream fs = new FileStream("file.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, users);
                }
            }
        }
        public List <User> GetUsersData()
        {
            using (FileStream fs = new FileStream("file.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                if (fs.Length>0 && bf.Deserialize(fs) is List<User> users)
                {
                    this.users = users;
                }
                else
                {
                    return new List <User>();
                }
            }
            return users;
        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.gender = new Gender(genderName);
            CurrentUser.birthDate = birthDate;
            CurrentUser.weight = weight;
            CurrentUser.height = height;
            Save();
        }
    }
}
