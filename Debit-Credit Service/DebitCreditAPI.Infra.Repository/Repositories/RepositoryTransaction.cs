﻿using DebitCreditAPI.Domain.Core.Interfaces.Repositories;
using DebitCreditAPI.Domain.Models;
using DebitCreditAPI.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DebitCreditAPI.Infra.Repository.Repositories
{
    public class RepositoryTransaction : IRepositoryTransaction
    {
        private readonly SqliteContext _context;
        public RepositoryTransaction(SqliteContext Context)
        {
            _context = Context;
        }

        public void CreateTransaction(Account origin, Account destiny, Entry entry)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<Entry>().Add(entry);
                    _context.SaveChanges();

                    _context.Entry(origin).State = EntityState.Modified;
                    _context.SaveChanges();

                    _context.Entry(destiny).State = EntityState.Modified;
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
