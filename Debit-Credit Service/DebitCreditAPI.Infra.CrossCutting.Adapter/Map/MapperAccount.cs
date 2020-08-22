using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Domain.Models;
using DebitCreditAPI.Infra.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (accountDTO == null)
                return null;
            Account account = new Account
            {
                Id = accountDTO.Id,
                AccountNumber = accountDTO.AccountNumber,
                Balance = accountDTO.Balance
            };

            return account;
        }
        public IEnumerable<AccountDTO> MapperListAccounts(IEnumerable<Account> accounts)
        {
            if (accounts != null)
                foreach (var item in accounts)
                {
                    AccountDTO accountDTO = new AccountDTO
                    {
                        Id = item.Id,
                        AccountNumber = item.AccountNumber,
                        Balance = item.Balance,
                        DestinyEntries = mapperEntry.MapperListEntries(item.DestinyEntries).ToList(),
                        OriginEntries = mapperEntry.MapperListEntries(item.OriginEntries).ToList()
                    };

                    accountDTOs.Add(accountDTO);
                }
            return accountDTOs;
        }

        public AccountDTO MapperToDTO(Account Account)
        {
            if (Account == null)
                return null;
            AccountDTO accountDTO = new AccountDTO
            {
                Id = Account.Id,
                AccountNumber = Account.AccountNumber,
                Balance = Account.Balance,
                DestinyEntries = mapperEntry.MapperListEntries(Account.DestinyEntries).ToList(),
                OriginEntries = mapperEntry.MapperListEntries(Account.OriginEntries).ToList()
            };

            return accountDTO;
        }
        #endregion
    }
}
