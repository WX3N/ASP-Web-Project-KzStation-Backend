using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;
using Projek.Factory;

namespace Projek.Repository
{
    public class ArtistRepository
    {

            Database1Entities1 db = new Database1Entities1();

            public void AddArtist(string artistName, string artistImage)
            {
                db.Artists.Add(ArtistFactory.createArtist(artistName, artistImage));
                db.SaveChanges();
            }

        public void DeleteArtist(int id)
        {
             Artist artist = db.Artists.Where(x => x.ArtistId == id).FirstOrDefault();
        //    Artist artist = db.Artists.Find(id);
      
            db.Artists.Remove(artist);
            db.SaveChanges();


    }
 

        public void UpdateArtist(int id, string artistName, string artistImage)
            {
            //Artist artist = db.Artists.Where(x => x.ArtistId == id).FirstOrDefault();
                Artist artist = db.Artists.Find(id);
            if (artist != null)
            {
                artist.ArtistName = artistName;
                artist.ArtistImage = artistImage;

                db.SaveChanges();
            }

            }


        public Artist getArtist(int id)
        {
            Artist artist = db.Artists.Where(x => x.ArtistId == id).FirstOrDefault();
            return artist;
        }

    }
}