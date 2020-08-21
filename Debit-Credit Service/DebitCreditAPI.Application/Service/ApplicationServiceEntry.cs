using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Application.Interfaces;
using DebitCreditAPI.Domain.Core.Interfaces.Services;
using DebitCreditAPI.Infra.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Application.Service
{
    public class ApplicationServiceEntry : IApplicationServiceEntry
    {
        private readonly IServiceEntry _serviceEntry;
        private readonly IMapperEntry _mapperEntry;

        public ApplicationServiceEntry(IServiceEntry ServiceEntry
                                                 , IMapperEntry MapperEntry)

        {
            _serviceEntry = ServiceEntry;
            _mapperEntry = MapperEntry;
        }


        public void Add(EntryDTO obj)
        {
            var objEntry = _mapperEntry.MapperToEntity(obj);
            _serviceEntry.Add(objEntry);
        }

        public void Dispose()
        {
            _serviceEntry.Dispose();
        }

        public IEnumerable<EntryDTO> GetAll()
        {
            var objProdutos = _serviceEntry.GetAll();
            return _mapperEntry.MapperListEntries(objProdutos);
        }

        public EntryDTO GetById(int id)
        {
            var objEntry = _serviceEntry.GetById(id);
            return _mapperEntry.MapperToDTO(objEntry);
        }

        public void Remove(EntryDTO obj)
        {
            var objEntry = _mapperEntry.MapperToEntity(obj);
            _serviceEntry.Remove(objEntry);
        }

        public void Update(EntryDTO obj)
        {
            var objEntry = _mapperEntry.MapperToEntity(obj);
            _serviceEntry.Update(objEntry);
        }
    }
}
