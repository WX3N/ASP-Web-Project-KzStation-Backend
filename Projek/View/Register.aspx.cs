using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Model;
using Projek.Model;
using Projek.Repository;
using System.Text.RegularExpressions;

namespace Projek.View
{
    public partial class Register : System.Web.UI.Page
    {
        CustomerRepository customerRepository = new CustomerRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool IsAlphaNumeric(string input)
        {
            string pattern = "^[a-zA-Z0-9]+$";
            return Regex.IsMatch(input, pattern);
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

            Customer emailChecker = customerRepository.getEmail(email);

            if (name.Length > 5 && 
                name.Length <= 50 &&
                email.Length != 0 &&
                emailChecker != null &&
                password.Length != 0 && 
                address.Length != 0 && 
                address.EndsWith("Street",StringComparison.OrdinalIgnoreCase)&&
                IsAlphaNumeric(password) 
                )
            {
                customerRepository.Register(name, email, gender, address, password, role);
                Response.Redirect("~/View/Login.aspx");
            }
        }
    }
}