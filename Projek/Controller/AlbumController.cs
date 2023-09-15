using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Projek.Handler;

namespace Projek.Controller
{
    public class AlbumController
    {

        public static List<string> validationInputAlbum(string albumName, string albumDescription, int albumPrice, int albumStock, FileUpload albumImage)
        {
            List<string> messages = new List<string>();
            messages.Add("");
            messages.Add("");
            messages.Add("");
            messages.Add("");
            messages.Add("");

            string fileExtension = Path.GetExtension(albumImage.FileName).ToLower();
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".jfif" };
            int maxSizeInBytes = 2 * 1024 * 1024; // 2MB

            if (albumName.Length == 0)
            {
                messages[0] = "Album name must be filled";
            }
            else if (albumName.Length > 50)
            {
                messages[0] = "Album name can not be more than 50 characters";
            }


            if (albumDescription.Length == 0)
            {
                messages[1] = "Album description must be filled";
            }
            else if (albumDescription.Length > 255)
            {
                messages[1] = "Album description can not be more than 255 characters";
            }

            if (albumPrice < 100000 || albumPrice > 1000000)
            {
                messages[2] = "Album price must be between 100000 and 1000000";
            }

            if (albumStock <= 0)
            {
                messages[3] = "Album stock must be more than 0";
            }

            if (!albumImage.HasFile)
            {
                messages[4] = "Please choose an album image";
            }
            else if (!allowedExtensions.Contains(fileExtension) || albumImage.PostedFile.ContentLength > maxSizeInBytes)
            {
                messages[4] = "Invalid album image. Please choose a file with extension .png, .jpg, .jpeg, or .jfif and size less than 2MB.";
            }

            return messages;

        }

        public static List<string> AddAlbum(int artistId, string albumName, FileUpload albumImage, int albumPrice, int albumStock, string albumDescription)
        {
            List<string> messages = validationInputAlbum(albumName, albumDescription, albumPrice, albumStock, albumImage);

            if (messages[0] == "" && messages[1] == "" && messages[2] == ""
                && messages[3] == "" && messages[4] == "")
            {
                AlbumHandler.AddAlbum(artistId,albumName, albumImage, albumPrice, albumStock, albumDescription);
                return null;
            }
            return messages;
        }


        public static void DeleteAlbum(int id)
        {
            AlbumHandler.DeleteAlbum(id);
        }

        public static List<string> UpdateAlbum(int id, string albumName, FileUpload albumImage, int albumPrice, int albumStock, string albumDescription)
        {
            List<string> messages = validationInputAlbum(albumName, albumDescription, albumPrice, albumStock, albumImage);

            if (messages[0] == "" && messages[1] == "" && messages[2] == ""
                && messages[3] == "" && messages[4] == "")
            {
                AlbumHandler.UpdateAlbum(id, albumName, albumImage, albumPrice, albumStock, albumDescription);
                return null;
            }
            return messages;
        }

        public static dynamic GetAlbum(int albumId)
        {
            return AlbumHandler.GetAlbum(albumId);
        }

        public static dynamic GetArtistAlbums(int artistId)
        {
            return AlbumHandler.GetArtistAlbums(artistId);
        }
    }
}