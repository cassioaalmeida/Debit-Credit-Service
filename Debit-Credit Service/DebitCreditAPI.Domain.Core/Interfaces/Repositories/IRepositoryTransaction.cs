using DebitCreditAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryTransaction
    {
        void CreateTransaction(Account origin, Account destiny, Entry entry);
    }
}
