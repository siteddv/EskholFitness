using EskholFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EskholFitness.BL.Controller
{
    public class UserController : BaseController
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
                    IsNewUser = true;
                }
            }

        }
        public List <User> GetUsersData()
        {
            return GetData<User>() ?? new List<User>();
        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
        }
    }
}
