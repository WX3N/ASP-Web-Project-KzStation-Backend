using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Model;
using Projek.Repository;

namespace Projek.View
{
    public partial class Login : System.Web.UI.Page
    {
        CustomerRepository customerRepository = new CustomerRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected bool validation(string email, string password)
        {
            if (email.Length == 0 && password.Length == 0)
            {
                return false;
            }

            return true;
        }
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text.ToString();
            string password = PasswordTxt.Text.ToString();
            bool rememberMe = RememberCheckBox.Checked;

            if(validation(email, password))
            {
                Customer customer = customerRepository.Login(email, password);
                if (customer != null)
                {
                    if (rememberMe)
                    {
                        HttpCookie cookie = new HttpCookie("user_cookie");
                        cookie.Value = customer.CustomerId.ToString();
                        cookie.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(cookie);
                    }
                    Session["User"] = customer;
                    Response.Redirect("~/View/Home.aspx");
                }
            }
            
        }
    }
}