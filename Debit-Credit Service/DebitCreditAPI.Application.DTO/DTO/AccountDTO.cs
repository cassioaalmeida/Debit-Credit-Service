using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Application.DTO.DTO
{
    public class AccountDTO
    {
        public int? Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public List<EntryDTO> OriginEntries { get; set; }
        public List<EntryDTO> DestinyEntries { get; set; }
    }
}
