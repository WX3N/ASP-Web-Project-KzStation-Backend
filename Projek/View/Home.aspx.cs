using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Repository;
using Projek.Model;

namespace Projek.View
{
    
    public partial class Home : System.Web.UI.Page
    {
        Database1Entities1 db = new Database1Entities1();
        ArtistRepository artistRepository = new ArtistRepository();
        CustomerRepository customerRepository = new CustomerRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CardRepeater.DataSource = db.Artists.ToList();
                CardRepeater.DataBind();
            }

        }

        protected void OpenDetail_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            string id = linkbtn.CommandArgument;
            Response.Redirect("~/View/ArtistDetail.aspx?id=" + id);
        }


        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            //RepeaterItem item = (RepeaterItem)linkbtn.NamingContainer;
            int id = Convert.ToInt32(linkbtn.CommandArgument);
            artistRepository.DeleteArtist(id);
            Response.Redirect("~/View/Home.aspx");
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender;
            int id = Convert.ToInt32(linkbtn.CommandArgument);
            Response.Redirect("~/View/UpdateArtist.aspx?artistId=" + id);

        }
    }
}