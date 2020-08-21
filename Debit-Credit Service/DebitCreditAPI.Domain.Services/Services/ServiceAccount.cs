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
    }
}
