using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Controller;
using Projek.Model;

namespace Projek.View
{
    public partial class UpdateProfile : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

 
        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(Request.QueryString["customerId"]);
            Customer customer = CustomerController.getCustomer(customerId);

            string name = NameTxt.Text.ToString();
            string email = EmailTxt.Text.ToString();
            string password = PasswordTxt.Text.ToString();
            string gender = GenderList.SelectedValue.ToString();

            string address = AddressTxt.Text.ToString();
            string role = customer.CustomerRole;


            List<string> msgs = CustomerController.UpdateCustomer(customerId, name, email, gender, address, password);
            if (msgs != null)
            {
                if (msgs[0] != "")
                {
                    NameLbl.Visible = true;
                    NameLbl.Text = msgs[0];
                }
                else
                {
                    NameLbl.Visible = false;
                }

                if (msgs[1] != "")
                {
                    EmailLbl.Visible = true;
                    EmailLbl.Text = msgs[1];
                }
                else
                {
                    EmailLbl.Visible = false;
                }

                if (msgs[2] != "")
                {
                    PasswordLbl.Visible = true;
                    PasswordLbl.Text = msgs[2];
                }
                else
                {
                    PasswordLbl.Visible = false;
                }

                if (msgs[3] != "")
                {
                    AddressLbl.Visible = true;
                    AddressLbl.Text = msgs[3];
                }
                else
                {
                    AddressLbl.Visible = false;
                }

                if (msgs[4] != "")
                {
                    GenderLbl.Visible = true;
                    GenderLbl.Text = msgs[4];
                }
                else
                {
                    GenderLbl.Visible = false;
                }
            }
            else
            {
                Response.Redirect("~/View/Login.aspx");
            }


        }

    }
}