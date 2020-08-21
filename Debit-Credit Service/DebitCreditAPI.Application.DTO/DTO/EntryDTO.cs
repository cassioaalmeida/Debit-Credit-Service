using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Application.DTO.DTO
{
    public class EntryDTO
    {
        public int? Id { get; set; }
        public int OriginAccountId { get; set; }
        public int DestinyAccountId { get; set; }
        public decimal Value { get; set; }
    }
}
