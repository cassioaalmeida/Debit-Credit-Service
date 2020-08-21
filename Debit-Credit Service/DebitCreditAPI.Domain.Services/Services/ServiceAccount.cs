using DebitCreditAPI.Domain.Core.Interfaces.Repositories;
using DebitCreditAPI.Domain.Core.Interfaces.Services;
using DebitCreditAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Domain.Services.Services
{
    public class ServiceAccount :ServiceBase<Account>, IServiceAccount
    {
        public readonly IRepositoryAccount _repositoryAccount;

        public ServiceAccount(IRepositoryAccount RepositoryAccount)
            : base(RepositoryAccount)
        {
            _repositoryAccount = RepositoryAccount;
        }
        public override void Add(Account obj)
        {
            if (_repositoryAccount.GetAccountByAccountNumber(obj.AccountNumber) == null)
                _repositoryAccount.Add(obj);
            else
                throw new Exception("Account Number already exists!");
        }

        public Account GetAccountByAccountNumber(int accountNumber)
        {
            return _repositoryAccount.GetAccountByAccountNumber(accountNumber);
        }

        public IEnumerable<Account> GetAllWithChilds()
        {
            return _repositoryAccount.GetAllWithChilds();
        }
    }
}
