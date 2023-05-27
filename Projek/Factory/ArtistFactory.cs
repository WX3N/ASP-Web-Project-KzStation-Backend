using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;

namespace Projek.Factory
{
    public class ArtistFactory
    {
        public static Artist createArtist(string artistName, string artistImage)
        {
            return new Artist
            {
                ArtistName = artistName,
                ArtistImage = artistImage
            };
        }
    }
}