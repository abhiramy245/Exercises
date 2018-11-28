using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountTransaction.DataLayer
{
    public class Account
    {
        public long AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
    }
}
