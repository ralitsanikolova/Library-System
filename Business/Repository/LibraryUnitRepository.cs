using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class LibraryUnitRepository : ILibraryUnitRepository
    {
        private readonly OnlineLibraryDbContext _db;
        private readonly IMapper _mapper;

        public LibraryUnitRepository(OnlineLibraryDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<LibraryUnitDTO> CreateUnit(LibraryUnitDTO libraryUnitsDTO)
        {
            LibraryUnit unit = _mapper.Map<LibraryUnitDTO, LibraryUnit>(libraryUnitsDTO);
            unit.CreatedDate = DateTime.Now;
            unit.CreatedBy = "";
            var addedUnit = await _db.LibraryUnits.AddAsync(unit);
            await _db.SaveChangesAsync();
            return _mapper.Map<LibraryUnit, LibraryUnitDTO>(addedUnit.Entity);
        }

        public async Task<int> DeleteUnit(int unitId)
        {
            var unitDetail = await _db.LibraryUnits.FindAsync(unitId);
            if (unitDetail != null)
            {
                _db.LibraryUnits.Remove(unitDetail);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<LibraryUnitDTO>> GetAllUnits()
        {
            try
            {
                IEnumerable<LibraryUnitDTO> unitDTOs =
                    _mapper.Map<IEnumerable<LibraryUnit>, IEnumerable<LibraryUnitDTO>>(_db.LibraryUnits);

                return unitDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<LibraryUnitDTO> GetUnit(int unitId)
        {
            try
            {
                LibraryUnitDTO unit = _mapper.Map<LibraryUnit, LibraryUnitDTO>(
                    await _db.LibraryUnits
                    .FirstOrDefaultAsync(x => x.InventoryId == unitId));

                return unit;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<LibraryUnitDTO> IsUnitUnique(int inventoryNumber, int unitId = 0)
        {
            try
            {
                if (unitId == 0)
                {

                    LibraryUnitDTO unit = _mapper.Map<LibraryUnit, LibraryUnitDTO>(
                        await _db.LibraryUnits.FirstOrDefaultAsync(x => x.InventoryId == inventoryNumber));

                    return unit;
                }
                else
                {
                    LibraryUnitDTO unit = _mapper.Map<LibraryUnit, LibraryUnitDTO>(
                        await _db.LibraryUnits.FirstOrDefaultAsync(x => x.InventoryId == inventoryNumber && x.InventoryId != unitId));

                    return unit;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<LibraryUnitDTO> UpdateUnit(int unitId, LibraryUnitDTO libraryUnitsDTO)
        {
            try
            {
                if (unitId == libraryUnitsDTO.InventoryId)
                {
                    LibraryUnit unitDetails = await _db.LibraryUnits.FindAsync(unitId);
                    LibraryUnit unitMap = _mapper.Map<LibraryUnitDTO, LibraryUnit>(libraryUnitsDTO, unitDetails);

                    unitMap.UpdatedBy = "";
                    unitMap.UpdatedDate = DateTime.Now;

                    var updatedBook = _db.LibraryUnits.Update(unitMap);

                    await _db.SaveChangesAsync();
                    return _mapper.Map<LibraryUnit, LibraryUnitDTO>(updatedBook.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
