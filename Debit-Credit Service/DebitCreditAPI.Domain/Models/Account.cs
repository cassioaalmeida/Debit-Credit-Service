using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace DebitCreditAPI.Domain.Models
{
    public class Account : Base
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public virtual IEnumerable<Entry> OriginEntries { get; set; }
        public virtual IEnumerable<Entry> DestinyEntries { get; set; }
    }
}
