using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Infra.CrossCutting.Adapter.Interfaces
{
    public interface IMapperEntry
    {
        Entry MapperToEntity(EntryDTO clienteDTO);

        IEnumerable<EntryDTO> MapperListEntries(IEnumerable<Entry> clientes);
        IEnumerable<Entry> MapperListEntriesEntity(IEnumerable<EntryDTO> clientes);

        EntryDTO MapperToDTO(Entry Cliente);
    }
}
