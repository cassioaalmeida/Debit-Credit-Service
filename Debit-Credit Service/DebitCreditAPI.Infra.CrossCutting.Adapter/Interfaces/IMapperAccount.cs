using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Infra.CrossCutting.Adapter.Interfaces
{
    public interface IMapperAccount
    {
        Account MapperToEntity(AccountDTO clienteDTO);

        IEnumerable<AccountDTO> MapperListAccounts(IEnumerable<Account> clientes);

        AccountDTO MapperToDTO(Account Cliente);
    }
}
