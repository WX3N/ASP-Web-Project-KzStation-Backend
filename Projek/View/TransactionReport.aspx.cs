using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek.Reporting;
using Projek.Model;
using Projek.Controller;

namespace Projek.View
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;

            DataSet1 data = loadDetailData(TransactionHeaderController.GetAllTansactionHeader());
            report.SetDataSource(data);
        }

        private DataSet1 loadDetailData(List<TransactionHeader> transactions)
        {
            DataSet1 newData = new DataSet1();

            var headerTable = newData.TransactionHeader;
            var detailTable = newData.TransactionDetail;

            foreach (TransactionHeader tr in transactions)
            {
                var row = headerTable.NewRow();
                int GrandTotal = 0;
                row["TransactionId"] = tr.TransactionId;
                row["CustomerId"] = tr.CustomerId;
                row["TransactionDate"] = tr.TransactionDate;        
                foreach (TransactionDetail detail in tr.TransactionDetails)
                {
                    Album album = AlbumController.GetAlbum(detail.AlbumId);
                    var drow = detailTable.NewRow();
                    drow["TransactionId"] = detail.TransactionId;
                    drow["AlbumId"] = detail.AlbumId;
                    drow["Qty"] = detail.Qty;
                    drow["AlbumPrice"] = album.AlbumPrice;
                    drow["SubTotalValue"] = (album.AlbumPrice)*(detail.Qty) ;
                    GrandTotal += (album.AlbumPrice) * (detail.Qty);
                    detailTable.Rows.Add(drow);
                }
                row["GrandTotalValue"] = GrandTotal;
                headerTable.Rows.Add(row);
            }
            return newData;
        }
    }
}