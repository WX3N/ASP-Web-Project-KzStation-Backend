using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Projek.Model;
using Projek.Controller;

namespace Projek.View
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int customerId = Convert.ToInt32(Request.QueryString["customerId"]);
                List<Album> cartItems = CartController.GetCustomerCart(customerId);
                List<CartItemWithQuantity> cartItemsWithQuantity = new List<CartItemWithQuantity>();

                foreach (Album album in cartItems)
                {
                    CartItemWithQuantity cartItem = new CartItemWithQuantity
                    {
                        AlbumId = album.AlbumId,
                        AlbumName = album.AlbumName,
                        AlbumDescription = album.AlbumDescription,
                        AlbumPrice = album.AlbumPrice,
                        Quantity = CartController.FindAlbumQuantity(customerId, album.AlbumId),
                        AlbumImage = album.AlbumImage
                    };

                    cartItemsWithQuantity.Add(cartItem);
                }

                CartRepeater.DataSource = cartItemsWithQuantity;
                CartRepeater.DataBind();
            }

        }

        protected void CartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int albumId = Convert.ToInt32(e.CommandArgument);
                CartController.RemoveCart(albumId);
                Response.Redirect("~/View/Cart.aspx?customerId=" + Request.QueryString["customerId"]);
            }
        }

        protected void CartCheckout_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(Request.QueryString["customerId"]);
            CartController.CartCheckout(customerId);
            Response.Redirect("~/View/Home.aspx");
        }

        protected string GetImageUrl(object albumImage)
        {
            string imageName = albumImage.ToString();
            return ResolveUrl("~/Assets/Album/" + imageName);
        }
    }
}
