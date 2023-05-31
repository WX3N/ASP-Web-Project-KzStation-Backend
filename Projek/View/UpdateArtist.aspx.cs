using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Model;
using Projek.Repository;

namespace Projek
{
    public partial class UpdateArtist : System.Web.UI.Page
    {
        ArtistRepository artistRepository = new ArtistRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            //int id = Convert.ToInt32(Request.QueryString["Id"]);
            LinkButton linkbtn = (LinkButton)sender;
            int id = Convert.ToInt32(linkbtn.CommandArgument);
            Artist artist = artistRepository.getArtist(id);
            ArtistNameTxt.Text = artist.ArtistName;
            */
            // Mengambil ID artis dari parameter URL
            if (Request.QueryString["artistId"] != null)
            {
                int artistId = Convert.ToInt32(Request.QueryString["artistId"]);
                Artist artist = artistRepository.getArtist(artistId);
                if (artist != null)
                {
                    ArtistNameTxt.Text = artist.ArtistName;
                }
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {

                int id = Convert.ToInt32(Request.QueryString["artistId"]);
                
                if (FileUpload1.HasFile)
                {
                    string artistName = ArtistNameTxt.Text;
                    FileUpload1.SaveAs(Server.MapPath("~") + "/Assets/Artist/" + FileUpload1.FileName);
                    string artistImage = FileUpload1.FileName;
                    artistRepository.UpdateArtist(id, artistName, artistImage);
                    Response.Redirect("~/View/Home.aspx");

                    
                }
   

        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx?");
        }
    }


    
}