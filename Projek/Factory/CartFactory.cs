using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;

namespace Projek.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int customerId, int albumId, int quantity)
        {
            return new Cart
            {
                CustomerId = customerId,
                AlbumId = albumId,
                Qty = quantity
            };
        }
    }
}