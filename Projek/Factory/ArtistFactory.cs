using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;
using System.Web.UI.WebControls;

namespace Projek.Factory
{
    public class ArtistFactory
    {
        public static Artist createArtist(string artistName, FileUpload artistImage)
        {

            var file = artistImage.PostedFile;
            var paths = "~/Assets/Artist/" + file.FileName;
            string imageName = artistImage.FileName;
            var filePath = HttpContext.Current.Server.MapPath(paths);
            file.SaveAs(filePath);

            return new Artist
            {
                ArtistName = artistName,
                ArtistImage = imageName
            };
        }
    }
}