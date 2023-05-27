using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Factory;
using Projek.Model;

namespace Projek.Repository
{
    public class AlbumRepository
    {
        Database1Entities1 db = new Database1Entities1();

        public void AddAlbum(string albumName, string albumImage, int albumPrice, int albumStock, string albumDescription)
        {
            db.Albums.Add(AlbumFactory.createAlbum(albumName, albumImage, albumPrice, albumStock, albumDescription));
            db.SaveChanges();
        }

        public void DeleteAlbum(int id)
        {
            Album album = db.Albums.Where(x => x.AlbumId == id).FirstOrDefault();

            db.Albums.Remove(album);
            db.SaveChanges();
        }

        public void UpdateAlbum(int id, string albumName, string albumImage, int albumPrice, int albumStock, string albumDescription)
        {
            Album album= db.Albums.Where(x => x.AlbumId == id).FirstOrDefault();

            album.AlbumName = albumName;
            album.AlbumName = albumName;
            album.AlbumImage = albumImage;
            album.AlbumPrice = albumPrice;
            album.AlbumStock = albumStock;
            album.AlbumDescription = albumDescription;

            db.SaveChanges();
        }
    }
}