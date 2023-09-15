using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Repository;

namespace Projek.Handler
{
    public class CustomerHandler
    {

        public static void Register(string name, string email, string gender, string address, string password, string role)
        {
            CustomerRepository.Register(name, email, gender, address, password, role);
        }  

        public static dynamic IsValidCredential(string email, string password)
        {      
            return CustomerRepository.IsValidCredential(email, password);
        }


        public static dynamic getCustomer(int id)
        {
            return CustomerRepository.getCustomer(id);
        }

        public static dynamic getEmail(string email)
        {
            return CustomerRepository.getEmail(email);
        }

        public static dynamic getRole(string role)
        {
            return CustomerRepository.getRole(role);

        }

        public static void UpdateCustomer(int id, string name, string email, string gender, string address, string password)
        {

            CustomerRepository.UpdateCustomer(id, name, email, gender, address, password);

        }

    }
}
