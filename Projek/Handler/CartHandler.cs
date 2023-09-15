using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Repository;

namespace Projek.Handler
{
    public class CartHandler
    {
        public static void AddCart(int customerId, int albumId, int quantity)
        {
            CartRepository.AddCart(customerId, albumId, quantity);
        }

        public static void RemoveCart(int albumId)
        {
            CartRepository.RemoveCart(albumId);
        }

        public static void CartCheckout(int customerId)
        {
            CartRepository.CartCheckout(customerId);
        }

        public static int FindAlbumQuantity(int customerId, int albumId)
        {
            return CartRepository.FindAlbumQuantity(customerId, albumId);
        }

        public static dynamic GetCustomerCart(int customerId)
        {
            return CartRepository.GetCustomerCart(customerId);
        }

    }
}