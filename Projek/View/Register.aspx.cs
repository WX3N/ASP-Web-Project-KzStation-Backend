using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Model;
using Projek.Model;
using Projek.Repository;

namespace Projek.View
{
    public partial class Register : System.Web.UI.Page
    {
        CustomerRepository userRepository = new CustomerRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

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

            if (name.Length != 0 && email.Length != 0 && password.Length != 0 && address.Length != 0)
            {
                userRepository.Register(name, email, gender, address, password, role);
                Response.Redirect("~/View/Login.aspx");
            }
        }
    }
}