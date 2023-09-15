using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projek.Model;
using Projek.Factory;

namespace Projek.Repository
{
    public class TransactionDetailRepository
    {
        public static Database1Entities1 db = new Database1Entities1();

        public static void AddTransactionDetail(int transactionId, int albumId, int qty)
        {
            var existingTransactionDetail = db.TransactionDetails
                .SingleOrDefault(td => td.TransactionId == transactionId && td.AlbumId == albumId);

            if (existingTransactionDetail == null)
            {
                // Tambahkan TransactionDetail baru
                db.TransactionDetails.Add(new TransactionDetail
                {
                    TransactionId = transactionId,
                    AlbumId = albumId,
                    Qty = qty
                });

                db.SaveChanges();
                
            }
        }

        public static dynamic GetTransactionDetails(int transactionId)
        {
            return db.TransactionDetails.Where(x => x.TransactionId == transactionId).ToList();
        }

    }
}