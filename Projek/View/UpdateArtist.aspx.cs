using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Model;
using Projek.Controller;

namespace Projek
{
    public partial class UpdateArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["artistId"] != null)
            {
                int artistId = Convert.ToInt32(Request.QueryString["artistId"]);
                Artist artist = ArtistController.getArtist(artistId);
            }
        }


        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string artistName = ArtistNameTxt.Text.ToString();
            int id = Convert.ToInt32(Request.QueryString["artistId"]);

            List<string> msgs = ArtistController.UpdateArtist(id, artistName, FileUpload1);
            if (msgs != null)
            {
                if (msgs[0] != "")
                {
                    ArtistNameLbl.Visible = true;
                    ArtistNameLbl.Text = msgs[0];
                }
                else
                {
                    ArtistNameLbl.Visible = false;
                }

                if (msgs[1] != "")
                {
                    ArtistImageLbl.Visible = true;
                    ArtistImageLbl.Text = msgs[1];
                }
                else
                {
                    ArtistImageLbl.Visible = false;
                }

            }
            else
            {
                Response.Redirect("~/View/Home.aspx");
            }



        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx?");
        }
    }


    
}