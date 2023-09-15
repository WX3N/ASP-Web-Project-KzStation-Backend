using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projek.Model
{
    public class CartItemWithQuantity
    {
        public int CartId { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string AlbumImage { get; set; }
        public int AlbumPrice { get; set; }
        public int Quantity { get; set; }
        public string AlbumDescription { get; set; }
    }
}