using DebitCreditAPI.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Application.Interfaces
{
    public interface IApplicationServiceTransaction
    {
        void CreateTransaction(AccountDTO origin, AccountDTO destiny, EntryDTO entry);
    }
}
