using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Handler;

namespace Projek.Controller
{
    public class TransactionHeaderController
    {
        public static void AddTransactionHeader(DateTime transactionDate, int customerId)
        {
            TransactionHeaderHandler.AddTransactionHeader(transactionDate, customerId);
        }

        public static dynamic createTransactionHeader(DateTime transactionDate, int customerId)
        {
            return TransactionHeaderHandler.createTransactionHeader(transactionDate, customerId);
        }


        public static int GetLastTransactionId(int customerId)
        {
            return TransactionHeaderHandler.GetLastTransactionId(customerId);
        }

        public static dynamic GetTransactionHeaderbyId(int transactionId)
        {
            return TransactionHeaderHandler.GetTransactionHeaderbyId(transactionId);
        }

        public static dynamic GetTransactionHeader(int customerId)
        {
            return TransactionHeaderHandler.GetTransactionHeader(customerId);
        }

        public static dynamic GetAllTansactionHeader()
        {
            return TransactionHeaderHandler.GetAllTansactionHeader();
        }
    }
}