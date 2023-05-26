using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Model;
using Projek.Repository;

namespace Projek.Navbar
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        CustomerRepository customerRepository = new CustomerRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                int id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                Customer customer = customerRepository.getCustomer(id);
                Session["User"] = customer;
            }
            if (Session["User"] != null)
            {
                LoginBtn.Visible = false;
                RegisterBtn.Visible = false;
                
                LogoutBtn.Visible = true;
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login.aspx");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Register.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("User");

            string[] cookies = Request.Cookies.AllKeys;

            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }

            Response.Redirect("~/View/Login.aspx");
        }
    }
}