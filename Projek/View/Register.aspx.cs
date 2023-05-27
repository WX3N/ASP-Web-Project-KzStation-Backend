using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Model;
using Projek.Repository;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml.Linq;

namespace Projek.View
{
    public partial class Register : System.Web.UI.Page
    {
        CustomerRepository customerRepository = new CustomerRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool IsAlphaNumeric(string password)
        {
            string pattern = "^[a-zA-Z0-9]+$";
            return Regex.IsMatch(password, pattern);
        }

        protected bool registerValidation(string name, string email, string password, string address, string gender)

        {
            Customer emailChecker = customerRepository.getEmail(email);
            int count = 0;
            if (name.Length < 5 || name.Length >= 50)
            {
                NameLbl.Text = "Name must between 5 and 50 characters";
                NameLbl.Visible = true;
                count++;
            }
            else
            {
                NameLbl.Visible = false;
            }

            if (email.Length == 0)
            {
                EmailLbl.Text = "Email must be filled";
                EmailLbl.Visible = true;
                count++;
            }
            else if (email.Length == 0)
            {
                EmailLbl.Text = "Email must be filled";
                EmailLbl.Visible = true;
                count++;
            }
            else if (emailChecker != null)
            {
                EmailLbl.Text = "Email already used";
                EmailLbl.Visible = true;
                count++;
            }
            else
            {
                EmailLbl.Visible = false;
            }

            if (password.Length == 0)
            {
                PasswordLbl.Text = "Password must be filled";
                PasswordLbl.Visible = true;
                count++;
            }
            else if (!IsAlphaNumeric(password))
            {
                PasswordLbl.Text = "Password must be alphanumeric";
                PasswordLbl.Visible = true;
                count++;
            }
            else
            {
                PasswordLbl.Visible = false;
            }

            if (address.Length == 0)
            {
                AddressLbl.Text = "Address must be filled";
                AddressLbl.Visible = true;
                count++;
            }
            else if (!address.EndsWith("Street", StringComparison.OrdinalIgnoreCase))
            {
                AddressLbl.Text = "Address must be end with street";
                AddressLbl.Visible = true;
                count++;
            }
            else
            {
                AddressLbl.Visible = false;
            }

            if (gender.Length == 0)
            {
                GenderLbl.Text = "You must choose gender!";
                GenderLbl.Visible = true;
                count++;
            }
            else
            {
                GenderLbl.Visible = false;
            }

            if(count > 0)
            {
                return false;
            }

            return true;
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string name = NameTxt.Text.ToString();
            string email = EmailTxt.Text.ToString();
            string password = PasswordTxt.Text.ToString();
            string gender = GenderList.SelectedValue.ToString();

            string address = AddressTxt.Text.ToString();
            string role;
            if (name.Equals("Admin"))
            {
                role = "Admin";
            }
            else
            {
                role = "User";
            }

            if (registerValidation(name, email, password, address, gender))
            {
                customerRepository.Register(name, email, gender, address, password, role);
                Response.Redirect("~/View/Login.aspx");
            }
        }
    }
}