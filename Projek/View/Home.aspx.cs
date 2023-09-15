using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Controller;
using Projek.Model;

namespace Projek.View
{
    
    public partial class Home : System.Web.UI.Page
    {
        Database1Entities1 db = new Database1Entities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CardRepeater.DataSource = db.Artists.ToList();
                CardRepeater.DataBind();
            }

        }


        protected void CardRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RepeaterItem item = e.Item;

                LinkButton UpdateBtn = (LinkButton)item.FindControl("UpdateBtn");
                LinkButton DeleteBtn = (LinkButton)item.FindControl("DeleteBtn");


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
                        InsertBtn.Visible = false;
                        UpdateBtn.Visible = false;
                        DeleteBtn.Visible = false;
                    }
                    else if (Session["User"] != null && customer.CustomerRole == "Admin")
                    {
                        InsertBtn.Visible = true;
                        UpdateBtn.Visible = true;
                        DeleteBtn.Visible = true;
                    }
                }
                else
                {
                    InsertBtn.Visible = false;
                    UpdateBtn.Visible = false;
                    DeleteBtn.Visible = false;
                }
            }
        }


        protected void OpenDetail_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            int id = Convert.ToInt32(linkbtn.CommandArgument);
            Response.Redirect("~/View/ArtistDetail.aspx?artistId=" + id);
        }


        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            //RepeaterItem item = (RepeaterItem)linkbtn.NamingContainer;
            int id = Convert.ToInt32(linkbtn.CommandArgument);
            ArtistController.DeleteArtist(id);
            Response.Redirect("~/View/Home.aspx");
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            int id = Convert.ToInt32(linkbtn.CommandArgument);
            Response.Redirect("~/View/UpdateArtist.aspx?artistId=" + id);

        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertArtist.aspx");
        }
    }
}