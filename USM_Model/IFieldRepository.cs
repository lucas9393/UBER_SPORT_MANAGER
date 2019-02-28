using System.Collections.Generic;
using System.Threading.Tasks;

namespace USM_Model
{
    public interface IFieldRepository
    {
        Task<Field[]> AllFields();
        bool AddField(Field field);
        bool RemoveField(Field field);
        Field EditField(int fieldId);
        IEnumerable<Field> SortedFields(FieldSortingType sortingType);
        Task<Field[]> SearchFieldByName(string fieldName);
        Task<Field[]> SearchFieldByType(TerrainType fieldType);
        Task<Field[]> SearchFieldBySport(SportType sportType);
    }
}