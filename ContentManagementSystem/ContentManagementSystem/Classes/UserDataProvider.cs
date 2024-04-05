using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Classes
{
    public static class UserDataProvider
    {
        private static List<User> users;

        // Constructor to initialize the list of users by reading from the text file
        static UserDataProvider()
        {
            users = new List<User>();
            string[] lines = File.ReadAllLines("UserData.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    users.Add(new User
                    {
                        Username = parts[0],
                        Password = parts[1],
                        Role = (UserRole)Enum.Parse(typeof(UserRole), parts[2])
                    });
                }
            }
        }

        public static List<User> Users { get { return users; } }
    }
}