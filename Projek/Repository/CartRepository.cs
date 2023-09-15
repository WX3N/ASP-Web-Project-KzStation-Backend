using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;
using Projek.Factory;
using Projek.Controller;

namespace Projek.Repository
{

    public class CartRepository
    {
        public static Database1Entities1 db = new Database1Entities1();

        public static void AddCart(int customerId, int albumId, int quantity)
        {
            Cart existingCart = db.Carts.FirstOrDefault(c => c.CustomerId == customerId && c.AlbumId == albumId);

            if (existingCart != null)
            {
                AlbumRepository albumRepository = new AlbumRepository();
                Album album = AlbumController.GetAlbum(albumId);
                CartItemWithQuantity cartItemWithQuantity = new CartItemWithQuantity();

                if ((existingCart.Qty + quantity) <= album.AlbumStock)
                {
                    existingCart.Qty += quantity;                
                    db.SaveChanges();
                }
            }
            else
            {
                Customer existingCustomer = db.Customers.FirstOrDefault(c => c.CustomerId == customerId);

                if (existingCustomer != null)
                {
                    Cart newCart = CartFactory.createCart(customerId, albumId, quantity);
                    db.Carts.Add(newCart);
                    db.SaveChanges();
                }

            }
        }

        public static void RemoveCart(int albumId)
        {
            Cart cart = db.Carts.Where(x => x.AlbumId == albumId).FirstOrDefault();

            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public static void CartCheckout(int customerId)
        {
            List<Cart> cartItems = db.Carts.Where(c => c.CustomerId == customerId).ToList();


            DateTime transactionDate = DateTime.Now;
            TransactionHeaderController.AddTransactionHeader(transactionDate, customerId);
            int lastTransactionId = TransactionHeaderController.GetLastTransactionId(customerId);
            TransactionHeader transactionHeader = TransactionHeaderController.GetTransactionHeaderbyId(lastTransactionId);

            foreach (Cart cartItem in cartItems)
            {
                TransactionDetailController.AddTransactionDetail(transactionHeader.TransactionId, cartItem.AlbumId, cartItem.Qty);
            }

            db.Carts.RemoveRange(cartItems);

            db.SaveChanges();
        }



        public static int FindAlbumQuantity(int customerId, int albumId)
        {
            Cart cartItem = db.Carts.FirstOrDefault(c => c.CustomerId == customerId && c.AlbumId == albumId);

            if (cartItem != null)
            {
                return cartItem.Qty;
            }

            return 0; 
        }



        public static dynamic GetCustomerCart(int customerId)
        {
            List<Album> albumList = new List<Album>();

            albumList = (from c in db.Carts
                         join a in db.Albums on c.AlbumId equals a.AlbumId
                         where c.CustomerId == customerId
                         select new
                         {
                             albumId = a.AlbumId,
                             albumName = a.AlbumName,
                             albumDesc = a.AlbumDescription,
                             albumPrice = a.AlbumPrice,
                             albumStock = a.AlbumPrice,
                             albumImage = a.AlbumImage
                         })
                        .AsEnumerable()
                        .Select(a => new Album
                        {
                            AlbumId = a.albumId,
                            AlbumName = a.albumName,
                            AlbumDescription = a.albumDesc,
                            AlbumPrice = a.albumPrice,
                            AlbumStock = a.albumStock,
                            AlbumImage = a.albumImage
                        })
                            .ToList();

            return albumList;
        }



    }
}