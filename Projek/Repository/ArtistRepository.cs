using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;
using Projek.Factory;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Hosting;

namespace Projek.Repository
{
    public class ArtistRepository
    {

        public static Database1Entities1 db = new Database1Entities1();

        public static void AddArtist(string artistName, FileUpload artistImage)
        {
            db.Artists.Add(ArtistFactory.createArtist(artistName, artistImage));
            db.SaveChanges();
        }

        public static void DeleteArtist(int id)
        {
            Artist artist = db.Artists.Where(x => x.ArtistId == id).FirstOrDefault();

            string artistImagePath = HostingEnvironment.MapPath("~/Assets/Artist/") + artist.ArtistImage;
            if (File.Exists(artistImagePath))
            {
                File.Delete(artistImagePath);
            }

            List<Album> albums = db.Albums.Where(a => a.ArtistId == id).ToList();
            db.Albums.RemoveRange(albums);

            db.Artists.Remove(artist);
            db.SaveChanges();

        }
 

        public static void UpdateArtist(int id, string artistName, FileUpload artistImage)
        {
            Artist artist = db.Artists.Where(x => x.ArtistId == id).FirstOrDefault();

            if (artist != null)
            {
                string artistImagePath = HostingEnvironment.MapPath("~/Assets/Artist/") + artist.ArtistImage;
                if (File.Exists(artistImagePath))
                {
                    File.Delete(artistImagePath);
                }

                var file = artistImage.PostedFile;
                var fileName = "~/Assets/Artist/" + file.FileName;
                var filePath = HttpContext.Current.Server.MapPath(fileName);
                file.SaveAs(filePath);
                string artistImageName = artistImage.FileName;

                artist.ArtistName = artistName;
                artist.ArtistImage = artistImageName;

                db.SaveChanges();
            }

        }

        public static dynamic getArtist(int id)
        {
            Artist artist = db.Artists.Where(x => x.ArtistId == id).FirstOrDefault();
            return artist;
        }

    }
}