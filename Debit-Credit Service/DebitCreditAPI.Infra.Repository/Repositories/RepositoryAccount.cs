using DebitCreditAPI.Domain.Core.Interfaces.Repositories;
using DebitCreditAPI.Domain.Models;
using DebitCreditAPI.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Infra.Repository.Repositories
{
    public class RepositoryAccount : RepositoryBase<Account>, IRepositoryAccount
    {
        private readonly SqliteContext _context;
        public RepositoryAccount(SqliteContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
