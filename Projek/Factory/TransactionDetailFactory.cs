using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;

namespace Projek.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail createTransactionDetail(int transactionId, int albumId, int qty)
        {
            return new TransactionDetail {
                TransactionId = transactionId,
                AlbumId = albumId,
                Qty = qty
            };
        }
    }
}