using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Repository;

namespace Projek.Handler
{
    public class TransactionDetailHandler
    {
        public static void AddTransactionDetail(int transactionId, int albumId, int qty)
        {
            TransactionDetailRepository.AddTransactionDetail(transactionId, albumId, qty);
        }

        public static dynamic GetTransactionDetails(int transactionId)
        {
            return TransactionDetailRepository.GetTransactionDetails(transactionId);
        }
    }
}