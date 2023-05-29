using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Model;
using Projek.Repository;

namespace Projek.View
{
    public partial class InsertArtist : System.Web.UI.Page
    {
        ArtistRepository artistRepository = new ArtistRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
            
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string name = ArtistNameTxt.Text;
                FileUpload1.SaveAs(Server.MapPath("~") + "/Assets/Artist/" + FileUpload1.FileName);
                string imageName = FileUpload1.FileName;
                artistRepository.AddArtist(name, imageName);

                Response.Redirect("~/View/Home.aspx");
            }
        }
    }
}