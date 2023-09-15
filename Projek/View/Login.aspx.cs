using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Controller;
using Projek.Model;

namespace Projek.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
                {
                    Response.Redirect("~/View/Home.aspx");
                }
            }
            
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text.ToString();
            string password = PasswordTxt.Text.ToString();
            bool rememberMe = RememberCheckBox.Checked;

            List<string> msgs = CustomerController.Login(email, password, rememberMe);
            if (msgs != null)
            {
                if (msgs[0] != "")
                {
                    EmailLbl.Visible = true;
                    EmailLbl.Text = msgs[0];
                }
                else
                {
                    EmailLbl.Visible = false;
                }

                if (msgs[1] != "")
                {
                    PasswordLbl.Visible = true;
                    PasswordLbl.Text = msgs[1];
                }
                else
                {
                    PasswordLbl.Visible = false;
                }

                if (msgs[2] != "")
                {
                    ErrorLbl.Visible = true;
                    ErrorLbl.Text = msgs[2];
                }
                else
                {
                    ErrorLbl.Visible = false;
                }

            }
            else
            {
                Customer customer = CustomerController.getEmail(email);
                Session["User"] = customer;
                Response.Redirect("~/View/Home.aspx");
            }
        }
    }
}