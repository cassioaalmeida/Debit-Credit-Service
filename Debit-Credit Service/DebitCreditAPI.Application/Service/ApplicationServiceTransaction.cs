using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Application.Interfaces;
using DebitCreditAPI.Domain.Core.Interfaces.Services;
using DebitCreditAPI.Infra.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Application.Service
{
    public class ApplicationServiceTransaction :IApplicationServiceTransaction
    {
        private readonly IServiceTransaction _serviceTransaction;
        private readonly IMapperAccount _mapperAccount;
        private readonly IMapperEntry _mapperEntry;
        public ApplicationServiceTransaction(IServiceTransaction ServiceTransaction,
                                            IMapperEntry MapperEntry,
                                            IMapperAccount MapperAccount)

        {
            _serviceTransaction = ServiceTransaction;
            _mapperEntry = MapperEntry;
            _mapperAccount = MapperAccount;
        }

        public void CreateTransaction(AccountDTO origin, AccountDTO destiny, EntryDTO entry)
        {
            origin.Balance -= entry.Value;
            destiny.Balance += entry.Value;

            _serviceTransaction.CreateTransaction(_mapperAccount.MapperToEntity(origin),
                                                  _mapperAccount.MapperToEntity(destiny),
                                                  _mapperEntry.MapperToEntity(entry));
        }
    }
}
