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
        ArtistRepository artistRepository = new ArtistRepository();
        CustomerRepository customerRepository = new CustomerRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }



    }
}