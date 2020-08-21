using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Domain.Models;
using DebitCreditAPI.Infra.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Infra.CrossCutting.Adapter.Map
{
    public class MapperAccount : IMapperAccount
    {
        #region Properties

        List<AccountDTO> accountDTOs = new List<AccountDTO>();

        MapperEntry mapperEntry = new MapperEntry();

        #endregion

        #region Methods
        public Account MapperToEntity(AccountDTO accountDTO)
        {
            Account account = new Account
            {
                Id = accountDTO.Id,
                AccountNumber = accountDTO.AccountNumber,
                Balance = accountDTO.Balance,
                Entries = mapperEntry.MapperListEntriesEntity(accountDTO.Entries)
            };

            return account;
        }
        public IEnumerable<AccountDTO> MapperListAccounts(IEnumerable<Account> accounts)
        {
            throw new NotImplementedException();
        }

        public AccountDTO MapperToDTO(Account Account)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
