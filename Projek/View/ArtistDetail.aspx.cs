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
    public partial class ArtistDetail : System.Web.UI.Page
    {
        CustomerRepository customerRepository = new CustomerRepository();
        ArtistRepository artistRepository = new ArtistRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AlbumDetailsBtn_Click(object sender, EventArgs e)
        {

        }
    }
}