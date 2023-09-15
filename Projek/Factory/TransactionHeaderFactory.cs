using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;
namespace Projek.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader createTransactionHeader(DateTime transactionDate, int customerId)
        {
            return new TransactionHeader
            {
                TransactionDate = transactionDate,
                CustomerId = customerId
            };
        }
    }
}