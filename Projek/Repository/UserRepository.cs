using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;
using Projek.Factory;

namespace Projek.Repository
{
    public class UserRepository
    {
        Database1Entities1 db = new Database1Entities1();
        public void Register(string name, string email, string gender, string address, string password, string role)
        {
            Customer customer = UserFactory.createUser(name, email, gender, address, password, role);

            db.Customers.Add(customer);

            db.SaveChanges();
        }

        public User Login(string email, string password)
        {
            User user = db.Users.Where(x => x.UserEmail == email && x.Password == password).FirstOrDefault();
            return user;
        }

        public User getUser(int id)
        {
            User user = db.Users.Where(x => x.Id == id).FirstOrDefault();
            return user;
        }
    }
}