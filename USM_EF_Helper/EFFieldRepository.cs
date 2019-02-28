using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USM_Model;

namespace USM_EF_Helper
{
    class EFFieldRepository : IFieldRepository
    {
        public IQueryable<Field> Field => Context.Fields;
        public EFDBContext Context { get; set; }

        public EFFieldRepository(EFDBContext context)
        {
            Context = context;
        }

        public bool AddField(Field field)
        {
            throw new NotImplementedException();
        }

        public Task<Field[]> AllFields()
        {
            throw new NotImplementedException();
        }

        public Field EditField(int fieldId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveField(Field field)
        {
            throw new NotImplementedException();
        }

        public async Task<Field[]> SearchFieldByName(string fieldName)
        {
            return await Field.Where(f => f.Name.Contains(fieldName)).ToArrayAsync();
        }

        public async Task<Field[]> SearchFieldBySport(SportType sportType)
        {
            return await Field.Where(f => f.Sport.Equals(sportType)).ToArrayAsync();
        }

        public async Task<Field[]> SearchFieldByType(TerrainType fieldType)
        {
            return await Field.Where(f => f.Terrain.Equals(fieldType)).ToArrayAsync();
        }

        public IEnumerable<Field> SortedFields(FieldSortingType sortingType)
        {
            throw new NotImplementedException();
        }
    }
}
