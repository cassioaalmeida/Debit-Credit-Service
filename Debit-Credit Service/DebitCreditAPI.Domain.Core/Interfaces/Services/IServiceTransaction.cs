using DebitCreditAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Domain.Core.Interfaces.Services
{
    public interface IServiceTransaction
    {
        void CreateTransaction(Account origin, Account destiny, Entry entry);
    }
}
