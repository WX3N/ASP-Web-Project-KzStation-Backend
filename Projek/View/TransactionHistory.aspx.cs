using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Model;
using System.Data;
using Projek.Controller;

namespace Projek.View
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransactionHistory();
            }
            
        }

        private void BindTransactionHistory()
        {
            int customerId = Convert.ToInt32(Request.QueryString["customerId"]);

            using (var context = new Database1Entities1())
            {
                var transactionHistory = (from th in context.TransactionHeaders
                                          join td in context.TransactionDetails on th.TransactionId equals td.TransactionId
                                          join c in context.Customers on th.CustomerId equals c.CustomerId
                                          join a in context.Albums on td.AlbumId equals a.AlbumId
                                          where c.CustomerId == customerId  
                                          orderby th.TransactionDate descending
                                          select new
                                          {
                                              th.TransactionId,
                                              th.TransactionDate,
                                              c.CustomerName,
                                              a.AlbumPrice,
                                              a.AlbumName,
                                              td.Qty,
                                              TotalPrice = a.AlbumPrice * td.Qty
                                          }).ToList();

                rptTransactionHistory.DataSource = transactionHistory;
                rptTransactionHistory.DataBind();
            }
        }
        
    }
}