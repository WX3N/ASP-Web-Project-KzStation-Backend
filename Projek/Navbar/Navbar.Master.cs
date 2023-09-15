using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Controller;
using Projek.Model;

namespace Projek.Navbar
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                int id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                Customer customer = CustomerController.getCustomer(id);
                Session["User"] = customer;
            }

            if (Session["User"] != null)
            {
                Customer customer = (Customer)Session["User"];
                if (Request.Cookies["user_cookie"] != null)
                {
                    int id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);

                    Session["User"] = CustomerController.getCustomer(id);
                }

                if (Session["User"] != null && customer.CustomerRole == "User")
                {
                    LoginBtn.Visible = false;
                    RegisterBtn.Visible = false;
                    CartBtn.Visible = true;
                    TransactionBtn.Visible = true;
                    TransactionReportBtn.Visible = false;
                    UpdateProfileBtn.Visible = true;
                    LogoutBtn.Visible = true;
                }
                else if (Session["User"] != null && customer.CustomerRole == "Admin")
                {
                    LoginBtn.Visible = false;
                    RegisterBtn.Visible = false;
                    CartBtn.Visible = false;
                    TransactionBtn.Visible = false;
                    TransactionReportBtn.Visible = true;
                    UpdateProfileBtn.Visible = true;
                    LogoutBtn.Visible = true;
                }
                
            }
            else
            {
                LoginBtn.Visible = true;
                RegisterBtn.Visible = true;
                CartBtn.Visible = false;
                TransactionBtn.Visible = false;
                TransactionReportBtn.Visible = false;
                UpdateProfileBtn.Visible = false;
                LogoutBtn.Visible = false;
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

        protected void CartBtn_Click(object sender, EventArgs e)
        {
            Customer customer = (Customer)Session["User"];
            int customerId = customer.CustomerId;
            Response.Redirect("~/View/Cart.aspx?customerId=" + customerId);
        }

        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            Customer customer = (Customer)Session["User"];
            int customerId = customer.CustomerId;
            Response.Redirect("~/View/UpdateProfile.aspx?customerId=" + customerId);
        }

        protected void TransactionBtn_Click(object sender, EventArgs e)
        {
            Customer customer = (Customer)Session["User"];
            int customerId = customer.CustomerId;
            Response.Redirect("~/View/TransactionHistory.aspx?customerId=" + customerId);
        }

        protected void TransactionReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionReport.aspx");
        }

        protected void InsertArtistBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertArtist.aspx");
        }
    }
}