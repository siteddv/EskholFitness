using EskholFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EskholFitness.BL.Controller
{
    public class UserController : BaseController
    {
        private const string USER_FILE_NAME = "user.dat";
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
                    SaveUsersData();
                    IsNewUser = true;
                }
            }

        }
        public UserController()
        {
            GetUsersData();

        }
        public void SaveUsersData()
        {
            SaveData(USER_FILE_NAME, users);
        }
        public List <User> GetUsersData()
        {
            return GetData<List<User>>(USER_FILE_NAME) ?? new List<User>();
        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.gender = new Gender(genderName);
            CurrentUser.birthDate = birthDate;
            CurrentUser.weight = weight;
            CurrentUser.height = height;
            SaveUsersData();
        }
    }
}
