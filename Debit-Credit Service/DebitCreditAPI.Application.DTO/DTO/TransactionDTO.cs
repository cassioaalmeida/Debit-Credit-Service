using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Application.DTO.DTO
{
    public class TransactionDTO
    {
        public int OriginAccountNumber { get; set; }
        public int DestinyAccountNumber { get; set; }
        public decimal Value { get; set; }
    }
}
