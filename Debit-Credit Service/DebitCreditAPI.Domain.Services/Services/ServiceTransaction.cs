using DebitCreditAPI.Domain.Core.Interfaces.Repositories;
using DebitCreditAPI.Domain.Core.Interfaces.Services;
using DebitCreditAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Domain.Services.Services
{
    public class ServiceTransaction : IServiceTransaction
    {
        public readonly IRepositoryTransaction _repositoryTransaction;

        public ServiceTransaction(IRepositoryTransaction RepositoryTransaction)
        {
            _repositoryTransaction = RepositoryTransaction;
        }

        public void CreateTransaction(Account origin, Account destiny, Entry entry)
        {
            if (entry.Value <= 0)
                throw new Exception("Invalid Value");
            _repositoryTransaction.CreateTransaction(origin, destiny, entry);
        }
    }
}
