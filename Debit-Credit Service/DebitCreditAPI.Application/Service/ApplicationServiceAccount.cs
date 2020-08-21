using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Application.Interfaces;
using DebitCreditAPI.Domain.Core.Interfaces.Services;
using DebitCreditAPI.Infra.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Application.Service
{
    public class ApplicationServiceAccount :IApplicationServiceAccount
    {
        private readonly IServiceAccount _serviceAccount;
        private readonly IMapperAccount _mapperAccount;

        public ApplicationServiceAccount(IServiceAccount ServiceAccount
                                                 , IMapperAccount MapperAccount)

        {
            _serviceAccount = ServiceAccount;
            _mapperAccount = MapperAccount;
        }


        public void Add(AccountDTO obj)
        {
            var objAccount = _mapperAccount.MapperToEntity(obj);
            _serviceAccount.Add(objAccount);
        }

        public void Dispose()
        {
            _serviceAccount.Dispose();
        }

        public IEnumerable<AccountDTO> GetAll()
        {
            var objProdutos = _serviceAccount.GetAll();
            return _mapperAccount.MapperListAccounts(objProdutos);
        }

        public AccountDTO GetById(int id)
        {
            var objAccount = _serviceAccount.GetById(id);
            return _mapperAccount.MapperToDTO(objAccount);
        }

        public void Remove(AccountDTO obj)
        {
            var objAccount = _mapperAccount.MapperToEntity(obj);
            _serviceAccount.Remove(objAccount);
        }

        public void Update(AccountDTO obj)
        {
            var objAccount = _mapperAccount.MapperToEntity(obj);
            _serviceAccount.Update(objAccount);
        }
    }
}
