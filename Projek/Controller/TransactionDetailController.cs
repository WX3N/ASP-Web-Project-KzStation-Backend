using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Handler;
namespace Projek.Controller
{
    public class TransactionDetailController
    {
        public static void AddTransactionDetail(int transactionId, int albumId, int qty)
        {
            TransactionDetailHandler.AddTransactionDetail(transactionId, albumId, qty);
        }

        public static dynamic GetTransactionDetails(int transactionId)
        {
            return TransactionDetailHandler.GetTransactionDetails(transactionId);
        }
    }
}