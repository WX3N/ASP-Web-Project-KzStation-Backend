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
    public partial class AlbumDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["albumId"] != null)
                {
                    int albumId = Convert.ToInt32(Request.QueryString["albumId"]);
                    LoadAlbumDetails(albumId);
                }
            }
            if(Session["User"] != null)
            {
                Customer customer = (Customer)Session["User"];
                if(customer.CustomerRole == "User")
                {
                    Quantity.Visible = true;
                    QuantityLbl.Visible = true;
                    QuantityTxt.Visible = true;
                    AddToCartBtn.Visible = true;
                }
            }
        }

        private void LoadAlbumDetails(int albumId)
        {
            Album album = AlbumController.GetAlbum(albumId);

            if (album != null)
            {
                AlbumImage.ImageUrl = "~/Assets/Album/" + album.AlbumImage;
                AlbumName.Text = album.AlbumName;
                AlbumPrice.Text = album.AlbumPrice.ToString();
                AlbumStock.Text = album.AlbumStock.ToString();
                AlbumDescription.Text = album.AlbumDescription;
            }
        }

        protected bool validateAddtoCart(int quantity, int albumstock)
        {
            int count = 0;
            if(quantity <= 0)
            {
                QuantityLbl.Text = "Quantity must be filled";
                count++;
                QuantityLbl.Visible = true;
            }
            else if(quantity > albumstock)
            {
                QuantityLbl.Text = "Quantity can not be more than album stock";
                count++;
                QuantityLbl.Visible = true;
            }
            else
            {
                QuantityLbl.Visible = false;
            }

            if(count > 0)
            {
                return false;
            }

            return true;
        }

        protected void AddToCartBtn_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(QuantityTxt.Text);
            int albumId = Convert.ToInt32(Request.QueryString["albumId"]);
            Album album = AlbumController.GetAlbum(albumId);

            if(validateAddtoCart(quantity, album.AlbumStock))
            {
                Customer customer = (Customer)Session["User"];
                CartController.AddCart(customer.CustomerId, albumId, quantity);
                Response.Redirect("~/View/Home.aspx");
            }
        }
    }
}