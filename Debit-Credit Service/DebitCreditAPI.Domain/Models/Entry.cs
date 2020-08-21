using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DebitCreditAPI.Domain.Models
{
    public class Entry:Base
    {
        public int OriginAccountId { get; set; }
        [ForeignKey("OriginAccountId")]
        public Account OriginAccount { get; set; }
        [ForeignKey("DestinyAccountId")]
        public int DestinyAccountId { get; set; }
        public Account DestinyAccount { get; set; }
        public decimal Value { get; set; }
    }
}
