using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface ILibraryUnitRepository
    {
        public Task<LibraryUnitDTO> CreateUnit(LibraryUnitDTO libraryUnitsDTO);
        public Task<LibraryUnitDTO> UpdateUnit(int unitId, LibraryUnitDTO libraryUnitsDTO);
        public Task<int> DeleteUnit(int unitId);
        public Task<LibraryUnitDTO> GetUnit(int unitId);
        public Task<LibraryUnitDTO> IsUnitUnique(int inventoryNumber, int unitId = 0);
        public Task<IEnumerable<LibraryUnitDTO>> GetAllUnits();
    }
}
