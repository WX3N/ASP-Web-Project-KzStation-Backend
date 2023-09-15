using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Handler;
using Projek.Model;
using System.Text.RegularExpressions;

namespace Projek.Controller
{
    public class CustomerController
    {

        public static bool IsAlphaNumeric(string password)
        {
            string pattern = "^[a-zA-Z0-9]+$";
            return Regex.IsMatch(password, pattern);
        }

        public static List<string> Register(string name, string email, string gender, string address, string password, string role)
        {
            List<string> messages = new List<string>();

            Customer emailChecker = CustomerHandler.getEmail(email);

            messages.Add("");
            messages.Add("");
            messages.Add("");
            messages.Add("");
            messages.Add("");
            if (name.Length < 5 || name.Length >= 50)
            {
                messages[0] = "Name must between 5 and 50 characters";
            }

            if (email.Length == 0)
            {
                messages[1] = "Email must be filled";
            }
            else if (email.Length == 0)
            {
                messages[1] = "Email must be filled";
            }
            else if (emailChecker != null)
            {
                messages[1] = "Email already used";
            }


            if (password.Length == 0)
            {
                messages[2] = "Password must be filled";
            }
            else if (!IsAlphaNumeric(password))
            {
                messages[2] = "Password must be alphanumeric";
            }

            if (address.Length == 0)
            {
                messages[3] = "Address must be filled";
            }
            else if (!address.EndsWith("Street", StringComparison.OrdinalIgnoreCase))
            {
                messages[3] = "Address must be end with street";
            }

            if (gender.Length == 0)
            {
                messages[4] = "You must choose gender!";
            }


            if (messages[0] == "" && messages[1] == "" && messages[2] == ""
                && messages[3] == "" && messages[4] == "")
            {
                CustomerHandler.Register(name, email, gender, address, password, role);
                return null;
            }

            return messages;
        }

        public static List<string> Login(string email, string password, bool remember)
        {
            List<string> messages = new List<string>();

            messages.Add("");
            messages.Add("");
            messages.Add("");

            if (email.Length == 0)
            {
                messages[0] = "Email Must be filled";
            }


            if (password.Length == 0)
            {
                messages[1] = "Password Must be filled !";
            }


            if (messages[0] != "" || messages[1] != "")
            {
                return messages;
            }
            var customer = IsValidCredential(email, password);

            if (customer == null)
            {
                messages[2] = "Email or Password is incorrect";
                return messages;
            }

            if (remember)
            {
                HttpCookie cookie = new HttpCookie("user_cookie");
                cookie.Value = customer.CustomerId.ToString();
                cookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            return null;

        }

        public static dynamic IsValidCredential(string email, string password)
        {
            return CustomerHandler.IsValidCredential(email, password);
        }

        public static dynamic getCustomer(int id)
        {
            return CustomerHandler.getCustomer(id);
        }

        public static dynamic getEmail(string email)
        {
            return CustomerHandler.getEmail(email);
        }

        public static dynamic getRole(string role)
        {
            return CustomerHandler.getRole(role);

        }

        public static List<string> UpdateCustomer(int id, string name, string email, string gender, string address, string password)
        {
            List<string> messages = new List<string>(); 

            Customer customerchecker = CustomerHandler.getEmail(email);
            bool emailchecker = true;

            messages.Add("");
            messages.Add("");
            messages.Add("");
            messages.Add("");
            messages.Add("");

            if (customerchecker == null)
            {
                emailchecker = false;
            }
            else if (customerchecker.CustomerId == id)
            {
                emailchecker = false;
            }
            


            if (name.Length < 5 || name.Length >= 50)
            {
                messages[0] = "Name must between 5 and 50 characters";
            }

            if (email.Length == 0)
            {
                messages[1] = "Email must be filled";
            }
            else if (email.Length == 0)
            {
                messages[1] = "Email must be filled";
            }
            else if (emailchecker)
            {
                messages[1] = "Email already used";
            }

            if (password.Length == 0)
            {
                messages[2] = "Password must be filled";
            }
            else if (!IsAlphaNumeric(password))
            {
                messages[2] = "Password must be alphanumeric";
            }

            if (address.Length == 0)
            {
                messages[3] = "Address must be filled";
            }
            else if (!address.EndsWith("Street", StringComparison.OrdinalIgnoreCase))
            {
                messages[3] = "Address must be end with street";
            }

            if (gender.Length == 0)
            {
                messages[4] = "You must choose gender!";
            }


            if (messages[0] == "" && messages[1] == "" && messages[2] == ""
                && messages[3] == "" && messages[4] == "")
            {
                CustomerHandler.UpdateCustomer(id, name, email, gender, address, password);
                return null;
            }

            return messages;


        }

    }
}
