using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Domain.Models
{
    public class Account : Base
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
    }
}
