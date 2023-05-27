using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;
using Projek.Factory;

namespace Projek.Repository
{
    public class CustomerRepository
    {
        Database1Entities1 db = new Database1Entities1();
        public void Register(string name, string email, string gender, string address, string password, string role)
        {
            Customer customer = CustomerFactory.createUser(name, email, gender, address, password, role);

            db.Customers.Add(customer);

            db.SaveChanges();

        }

        public Customer Login(string email, string password)
        {
            Customer customer = db.Customers.Where(x => x.CustomerEmail == email && x.CustomerPassword == password).FirstOrDefault();
            return customer;
        }

        public Customer getCustomer(int id)
        {
            Customer customer = db.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            return customer;
        }

        public Customer getEmail(string email)
        {
            Customer customer = db.Customers.Where(x => x.CustomerEmail == email).FirstOrDefault();
            return customer;
        }

        public Customer getRole(string role)
        {
            Customer customer = db.Customers.Where(x => x.CustomerRole == "User").FirstOrDefault();
            return customer;
        }
    }
}