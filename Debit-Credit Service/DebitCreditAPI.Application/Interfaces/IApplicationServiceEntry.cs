using System;
using System.Collections.Generic;
using System.Text;
using DebitCreditAPI.Application.DTO.DTO;

namespace DebitCreditAPI.Application.Interfaces
{
    public interface IApplicationServiceEntry
    {
        void Add(EntryDTO obj);

        EntryDTO GetById(int id);

        IEnumerable<EntryDTO> GetAll();

        void Update(EntryDTO obj);

        void Remove(EntryDTO obj);

        void Dispose();
    }
}
