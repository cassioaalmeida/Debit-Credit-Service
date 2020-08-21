using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace DebitCreditAPI.Domain.Models
{
    public class Entry:Base
    {
        public int OriginAccountId { get; set; }
        public Account OriginAccount { get; set; }
        public int DestinyAccountId { get; set; }
        public Account DestinyAccount { get; set; }
        public decimal Value { get; set; }
    }
}
