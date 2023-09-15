using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Factory;
using Projek.Model;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Web.Hosting;
using System.Web.UI.WebControls;

namespace Projek.Repository
{
    public class AlbumRepository
    {
        public static Database1Entities1 db = new Database1Entities1();

        public static void AddAlbum(int artistId, string albumName, FileUpload albumImage, int albumPrice, int albumStock, string albumDescription)
        {

            db.Albums.Add(AlbumFactory.createAlbum(artistId, albumName, albumImage, albumPrice, albumStock, albumDescription));
            db.SaveChanges();
        }


        public static void DeleteAlbum(int id)
        {
            Album album = db.Albums.FirstOrDefault(x => x.AlbumId == id);

            if (album != null)
            {
                string albumImagePath = HostingEnvironment.MapPath("~/Assets/Album/") + album.AlbumImage;
                if (File.Exists(albumImagePath))
                {
                    File.Delete(albumImagePath);
                }
                db.Albums.Remove(album);
                db.SaveChanges();
            }
        }

        public static void UpdateAlbum(int id, string albumName, FileUpload albumImage, int albumPrice, int albumStock, string albumDescription)
        {

            Album album= db.Albums.Where(x => x.AlbumId == id).FirstOrDefault();
            if(album != null)
            {
                string albumImagePath = HostingEnvironment.MapPath("~/Assets/Album/") + album.AlbumImage;
                if (File.Exists(albumImagePath))
                {
                    File.Delete(albumImagePath);
                }

                var file = albumImage.PostedFile;
                var fileName = "~/Assets/Album/" + file.FileName;
                var filePath = HttpContext.Current.Server.MapPath(fileName);
                file.SaveAs(filePath);
                string albumImageName = albumImage.FileName;

                album.AlbumName = albumName;
                album.AlbumName = albumName;
                album.AlbumImage = albumImageName;
                album.AlbumPrice = albumPrice;
                album.AlbumStock = albumStock;
                album.AlbumDescription = albumDescription;

                db.SaveChanges();
            }
        }

        public static dynamic GetAlbum(int albumId)
        {
            return db.Albums.FirstOrDefault(a => a.AlbumId == albumId);
        }

        public static dynamic GetArtistAlbums(int artistId)
        {
            return db.Albums.Where(a => a.ArtistId == artistId).ToList();
        }

    }
}