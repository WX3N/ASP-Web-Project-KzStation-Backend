using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Projek.Repository;

namespace Projek.Handler
{
    public class ArtistHandler
    {
        public static void AddArtist(string artistName, FileUpload artistImage)
        {
            ArtistRepository.AddArtist(artistName, artistImage);
        }

        public static void DeleteArtist(int id)
        {
            ArtistRepository.DeleteArtist(id);
        }

        public static void UpdateArtist(int id, string artistName, FileUpload artistImage)
        {
            ArtistRepository.UpdateArtist(id, artistName, artistImage);
        }

        public static dynamic getArtist(int id)
        {
            return ArtistRepository.getArtist(id);
        }

    }
}