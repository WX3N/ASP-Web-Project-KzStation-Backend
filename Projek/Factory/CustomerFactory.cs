using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Factory;
using Projek.Model;

namespace Projek.Factory
{
    public class CustomerFactory
    {
        public static Customer createUser(string name, string email, string gender, 
            string address, string password, string role)
        {
            return new Customer
            {
                CustomerEmail = email,
                CustomerName = name,
                CustomerGender = gender,
                CustomerAddress = address,
                CustomerPassword = password,
                CustomerRole = role
            };
        }
    }
}



