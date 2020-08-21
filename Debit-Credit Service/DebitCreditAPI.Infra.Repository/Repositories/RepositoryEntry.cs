using DebitCreditAPI.Domain.Core.Interfaces.Repositories;
using DebitCreditAPI.Domain.Models;
using DebitCreditAPI.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Infra.Repository.Repositories
{
    public class RepositoryEntry : RepositoryBase<Entry>, IRepositoryEntry
    {
        private readonly SqliteContext _context;
        public RepositoryEntry(SqliteContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
