using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;

namespace Projek.Factory
{
    public class AlbumFactory
    {
        public static Album createAlbum(string albumName, string albumImage, int albumPrice, int albumStock, string albumDescription)
        {
            return new Album
            {
                AlbumName = albumName,
                AlbumImage = albumImage,
                AlbumPrice = albumPrice,
                AlbumStock = albumStock,
                AlbumDescription = albumDescription
            };
        }
    }
}