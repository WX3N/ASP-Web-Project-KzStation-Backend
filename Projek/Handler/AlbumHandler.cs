using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Projek.Repository;

namespace Projek.Handler
{
    public class AlbumHandler
    {
        public static void AddAlbum(int artistId, string albumName, FileUpload albumImage, int albumPrice, int albumStock, string albumDescription)
        {
            AlbumRepository.AddAlbum(artistId, albumName, albumImage, albumPrice, albumStock, albumDescription);
        }


        public static void DeleteAlbum(int id)
        {
            AlbumRepository.DeleteAlbum(id);
        }

        public static void UpdateAlbum(int id, string albumName, FileUpload albumImage, int albumPrice, int albumStock, string albumDescription)
        {
            AlbumRepository.UpdateAlbum(id, albumName, albumImage, albumPrice, albumStock, albumDescription);
        }

        public static dynamic GetAlbum(int albumId)
        {
            return AlbumRepository.GetAlbum(albumId);
        }

        public static dynamic GetArtistAlbums(int artistId)
        {
            return AlbumRepository.GetArtistAlbums(artistId);
        }
    }
}