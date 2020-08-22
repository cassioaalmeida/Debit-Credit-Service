using DebitCreditAPI.Application.DTO.DTO;
using DebitCreditAPI.Domain.Models;
using DebitCreditAPI.Infra.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Infra.CrossCutting.Adapter.Map
{
    public class MapperEntry : IMapperEntry
    {
        #region Properties

        List<EntryDTO> entryDTOs = new List<EntryDTO>();
        List<Entry> entries = new List<Entry>();

        #endregion

        #region Methods
        public Entry MapperToEntity(EntryDTO entryDTO)
        {
            if (entryDTO == null)
                return null;
            Entry entry = new Entry
            {
                Id = entryDTO.Id,
                Value = entryDTO.Value,
                OriginAccountId = entryDTO.OriginAccountId,
                DestinyAccountId = entryDTO.DestinyAccountId
            };

            return entry;
        }
        public IEnumerable<EntryDTO> MapperListEntries(IEnumerable<Entry> entries)
        {
            entryDTOs = new List<EntryDTO>();
            if (entries !=null)
                foreach (var item in entries)
                {
                    EntryDTO entryDTO = new EntryDTO
                    {
                        Id = item.Id,
                        Value = item.Value,
                        OriginAccountId = item.OriginAccountId,
                        DestinyAccountId = item.DestinyAccountId
                    };

                    entryDTOs.Add(entryDTO);
                }
            return entryDTOs;
        }
        public IEnumerable<Entry> MapperListEntriesEntity(IEnumerable<EntryDTO> entryDTOs)
        {
            entries = new List<Entry>();
            if (entryDTOs != null)
                foreach (var item in entryDTOs)
                {
                    Entry entry = new Entry
                    {
                        Id = item.Id,
                        Value = item.Value,
                        OriginAccountId = item.OriginAccountId,
                        DestinyAccountId = item.DestinyAccountId
                    };

                    entries.Add(entry);
                }
            return entries;
        }

        public EntryDTO MapperToDTO(Entry Entry)
        {
            if (Entry == null)
                return null;
            EntryDTO entryDTO = new EntryDTO
            {
                Id = Entry.Id,
                Value = Entry.Value,
                OriginAccountId = Entry.OriginAccountId,
                DestinyAccountId = Entry.DestinyAccountId
            };

            return entryDTO;
        }
        #endregion
    }
}
