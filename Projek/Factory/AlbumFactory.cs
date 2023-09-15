using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Projek.Model;

namespace Projek.Factory
{
    public class AlbumFactory
    {
        public static Album createAlbum(int artistId, string albumName, FileUpload albumImage, int albumPrice, int albumStock, string albumDescription)
        {

            var file = albumImage.PostedFile;
            var paths = "~/Assets/Album/" + file.FileName;
            string imageName = albumImage.FileName;
            var filePath = HttpContext.Current.Server.MapPath(paths);
            file.SaveAs(filePath);


            return new Album
            {
                ArtistId = artistId,
                AlbumName = albumName,
                AlbumImage = imageName,
                AlbumPrice = albumPrice,
                AlbumStock = albumStock,
                AlbumDescription = albumDescription
            };
        }
    }
}