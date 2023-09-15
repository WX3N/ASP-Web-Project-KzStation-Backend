using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Handler;

namespace Projek.Controller
{
    public class CartController
    {
        public static void AddCart(int customerId, int albumId, int quantity)
        {
            CartHandler.AddCart(customerId, albumId, quantity);
        }

        public static void RemoveCart(int albumId)
        {
            CartHandler.RemoveCart(albumId);
        }

        public static void CartCheckout(int customerId)
        {
            CartHandler.CartCheckout(customerId);
        }

        public static int FindAlbumQuantity(int customerId, int albumId)
        {
            return CartHandler.FindAlbumQuantity(customerId, albumId);
        }

        public static dynamic GetCustomerCart(int customerId)
        {
            return CartHandler.GetCustomerCart(customerId);
        }
    }
}