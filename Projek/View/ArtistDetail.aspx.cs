using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Model;
using Projek.Controller;

namespace Projek.View
{
    public partial class ArtistDetail : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["artistId"] != null)
                {
                    int artistId = Convert.ToInt32(Request.QueryString["artistId"]);
                    LoadArtistDetails(artistId);
                    LoadArtistAlbums(artistId);
                }
                else
                {
                     Response.Redirect("~/View/Home.aspx");
                }
            }

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
                    InsertBtn.Visible = false;
                }
                else if (Session["User"] != null && customer.CustomerRole == "Admin")
                {
                    InsertBtn.Visible = true;
                }

            }
            else
            {
                InsertBtn.Visible = false;
            }
        }

        private void LoadArtistDetails(int artistId)
        {
            Artist artist = ArtistController.getArtist(artistId);
            if (artist != null)
            {
                ArtistImage.ImageUrl = "../Assets/Artist/" + artist.ArtistImage;
                ArtistName.Text = artist.ArtistName;
            }
        }

        private void LoadArtistAlbums(int artistId)
        {
            List<Album> albums = AlbumController.GetArtistAlbums(artistId);
            if (albums != null)
            {
                AlbumRepeater.DataSource = albums;
                AlbumRepeater.DataBind();
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
                        UpdateBtn.Visible = false;
                        DeleteBtn.Visible = false;
                    }
                    else if (Session["User"] != null && customer.CustomerRole == "Admin")
                    {
                        UpdateBtn.Visible = true;
                        DeleteBtn.Visible = true;
                    }
                }
                else
                {
                    UpdateBtn.Visible = false;
                    DeleteBtn.Visible = false;
                }
            }
        }

        protected void OpenDetail_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            int id = Convert.ToInt32(linkbtn.CommandArgument);
            Response.Redirect("~/View/AlbumDetail.aspx?albumId=" + id);
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["artistId"], out int artistId))
            {
                Response.Redirect("~/View/InsertAlbum.aspx?artistId=" + artistId);
            }
            else
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int albumId = Convert.ToInt32(linkButton.CommandArgument);
            Response.Redirect("~/View/UpdateAlbum.aspx?albumId=" + albumId);
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int albumId = Convert.ToInt32(linkButton.CommandArgument);

            AlbumController.DeleteAlbum(albumId);

            if (int.TryParse(Request.QueryString["artistId"], out int artistId))
            {
                AlbumRepeater.DataSource = AlbumController.GetArtistAlbums(artistId);
                AlbumRepeater.DataBind();
            }
        }

     
    }
}
