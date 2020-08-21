using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DebitCreditAPI.Domain.Models
{
    public class Account : Base
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        [InverseProperty("OriginAccount")]
        public virtual IEnumerable<Entry> OriginEntries { get; set; }
        [InverseProperty("DestinyAccount")]
        public virtual IEnumerable<Entry> DestinyEntries { get; set; }
    }
}
