using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Repository;

namespace Projek.Handler
{
    public class TransactionHeaderHandler
    {
        public static void AddTransactionHeader(DateTime transactionDate, int customerId)
        {
            TransactionHeaderRepository.AddTransactionHeader(transactionDate, customerId);
        }

        public static dynamic createTransactionHeader(DateTime transactionDate, int customerId)
        {
            return TransactionHeaderRepository.createTransactionHeader(transactionDate, customerId);
        }


        public static int GetLastTransactionId(int customerId)
        {
            return TransactionHeaderRepository.GetLastTransactionId(customerId);
        }

        public static dynamic GetTransactionHeaderbyId(int transactionId)
        {
            return TransactionHeaderRepository.GetTransactionHeaderbyId(transactionId);
        }

        public static dynamic GetTransactionHeader(int customerId)
        {
            return TransactionHeaderRepository.GetTransactionHeader(customerId);
        }

        public static dynamic GetAllTansactionHeader()
        {
            return TransactionHeaderRepository.GetAllTansactionHeader();
        }
    }
}