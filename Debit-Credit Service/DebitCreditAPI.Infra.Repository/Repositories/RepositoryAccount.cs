using DebitCreditAPI.Domain.Core.Interfaces.Repositories;
using DebitCreditAPI.Domain.Models;
using DebitCreditAPI.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public Account GetAccountByAccountNumber(int accountNumber)
        {
            return _context.Accounts.Where(p => p.AccountNumber == accountNumber).FirstOrDefault();
        }

        public IEnumerable<Account> GetAllWithChilds()
        {
            return _context.Accounts.Include(p => p.OriginEntries).Include(p => p.DestinyEntries).ToList();
        }
    }
}
