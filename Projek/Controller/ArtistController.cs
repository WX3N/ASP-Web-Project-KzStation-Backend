using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Projek.Handler;

namespace Projek.Controller
{
    public class ArtistController
    {
        public static List<string> AddArtist(string artistName, FileUpload artistImage)
        {
            List<string> messages = validationInputArtist(artistName, artistImage);

            if (messages[0] == "" && messages[1] == "")
            {
                ArtistHandler.AddArtist(artistName, artistImage);
                return null;
            }
            return messages;

        }

        public static List<string> validationInputArtist(string artistName, FileUpload artistImage)
        {
            List<string> messages = new List<string>();
            messages.Add("");
            messages.Add("");

            string fileExtension = Path.GetExtension(artistImage.FileName).ToLower();
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".jfif" };
            int maxSizeInBytes = 2 * 1024 * 1024; // 2MB

            if (artistName.Length == 0)
            {
                messages[0] = "Artist name must be filled";
            }

            if (!artistImage.HasFile)
            {
                messages[1] = "Please insert new artist image";
            }
            else if(!allowedExtensions.Contains(fileExtension) || artistImage.PostedFile.ContentLength > maxSizeInBytes)
            {
                messages[1] = "Invalid album image. Please choose a file with extension .png, .jpg, .jpeg, or .jfif and size less than 2MB.";

            }

            return messages;
        }

        public static void DeleteArtist(int id)
        {
            ArtistHandler.DeleteArtist(id);
        }

        public static List<string> UpdateArtist(int id, string artistName, FileUpload artistImage)
        {
            List<string> messages = validationInputArtist(artistName, artistImage);

            if (messages[0] == "" && messages[1] == "")
            {
                ArtistHandler.UpdateArtist(id, artistName, artistImage);
                return null;
            }
            return messages;
        }

        public static dynamic getArtist(int id)
        {
            return ArtistHandler.getArtist(id);
        }

    }
}