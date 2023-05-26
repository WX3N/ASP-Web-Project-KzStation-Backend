using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Factory;

namespace Projek.Factory
{
    public class UserFactory
    {
        public static User createUser(string name, string email, string gender, string address, string password, string role)
        {
            return new User
            {
                Email = email,
                Name = name,
                Gender = gender,
                Address = address,
                Password = password,
                Role = "User"
            };
        }
    }
}