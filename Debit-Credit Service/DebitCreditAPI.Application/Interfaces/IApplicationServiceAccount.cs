using DebitCreditAPI.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Application.Interfaces
{
    public interface IApplicationServiceAccount
    {
        void Add(AccountDTO obj);

        AccountDTO GetById(int id);

        IEnumerable<AccountDTO> GetAll();

        void Update(AccountDTO obj);

        void Remove(AccountDTO obj);

        void Dispose();
        AccountDTO GetAccountByAccountNumber(int accountNumber);
        IEnumerable<AccountDTO> GetAllWithChilds();
    }
}
