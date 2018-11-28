using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountTransaction.DataLayer
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public long AccountNum { get; set; }
        public string TransactionType { get; set; }
        public int Amount { get; set; }
        public string Remarks { get; set; }
    }
}
