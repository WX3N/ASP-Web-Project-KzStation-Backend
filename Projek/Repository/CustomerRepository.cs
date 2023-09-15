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
        public static Database1Entities1 db = new Database1Entities1();
        public static void Register(string name, string email, string gender, string address, string password, string role)
        {
            db.Customers.Add(CustomerFactory.createUser(name, email, gender, address, password, role));
            db.SaveChanges();
        }

        public static dynamic IsValidCredential(string email, string password)
        {
            Customer customer = db.Customers.Where(x => x.CustomerEmail == email && x.CustomerPassword == password).FirstOrDefault();
            return customer;
        }

        public static dynamic getCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            return customer;
        }

        public static dynamic getEmail(string email)
        {
            Customer customer = db.Customers.Where(x => x.CustomerEmail == email).FirstOrDefault();
            return customer;
        }


        public static dynamic getRole(string role)
        {
            Customer customer = db.Customers.Where(x => x.CustomerRole == "User").FirstOrDefault();
            return customer;
        }

        public static void UpdateCustomer(int id, string name, string email, string gender, string address, string password)
        {

            Customer customer = db.Customers.Find(id);
            if (customer != null)
            {
                customer.CustomerName = name;
                customer.CustomerEmail = email;
                customer.CustomerPassword = password;
                customer.CustomerGender = gender;
                customer.CustomerAddress = address;

                db.SaveChanges();
            }

        }

    }
}