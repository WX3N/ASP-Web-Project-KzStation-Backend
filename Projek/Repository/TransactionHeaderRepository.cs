using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;
using Projek.Factory;

namespace Projek.Repository
{
    public class TransactionHeaderRepository
    {
        public static Database1Entities1 db = new Database1Entities1();
        
        public static void AddTransactionHeader(DateTime transactionDate, int customerId)
        {

            db.TransactionHeaders.Add(TransactionHeaderFactory.createTransactionHeader(transactionDate, customerId));
            db.SaveChanges();
        }

        public static dynamic createTransactionHeader(DateTime transactionDate, int customerId)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                TransactionDate = transactionDate,
                CustomerId = customerId
            };

            return transactionHeader;
        }

        
        public static int GetLastTransactionId(int customerId)
        {
            int lastTransactionId = db.TransactionHeaders
                .Where(th => th.CustomerId == customerId)
                .OrderByDescending(th => th.TransactionId)
                .Select(th => th.TransactionId)
                .FirstOrDefault();

            return lastTransactionId;
        }

        public static dynamic GetTransactionHeaderbyId(int transactionId)
        {
            return db.TransactionHeaders.FirstOrDefault(x => x.TransactionId == transactionId);
        }

        public static dynamic GetTransactionHeader(int customerId)
        {
            return db.TransactionHeaders.FirstOrDefault(x => x.CustomerId == customerId);
        }

        public static dynamic GetAllTansactionHeader()
        {
            return db.TransactionHeaders.ToList();
        }
    }
}