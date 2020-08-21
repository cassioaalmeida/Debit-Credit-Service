using DebitCreditAPI.Domain.Core.Interfaces.Repositories;
using DebitCreditAPI.Domain.Core.Interfaces.Services;
using DebitCreditAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Domain.Services.Services
{
    public class ServiceEntry : ServiceBase<Entry>, IServiceEntry
    {
        public readonly IRepositoryEntry _repositoryEntry;

        public ServiceEntry(IRepositoryEntry RepositoryEntry)
            : base(RepositoryEntry)
        {
            _repositoryEntry = RepositoryEntry;
        }
    }
}
