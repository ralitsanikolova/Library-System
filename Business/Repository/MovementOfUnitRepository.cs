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
    public class MovementOfUnitRepository : IMovementOfUnitRepository
    {
        private readonly OnlineLibraryDbContext _db;
        private readonly IMapper _mapper;

        public MovementOfUnitRepository(OnlineLibraryDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<MovementOfUnitDTO> CreateMovement(MovementOfUnitDTO movementOfUnits)
        {
            MovementOfUnit unit = _mapper.Map<MovementOfUnitDTO, MovementOfUnit>(movementOfUnits);
            unit.CreatedDate = DateTime.Now;
            unit.CreatedBy = "";
            var addedUnit = await _db.MovementsOfUnits.AddAsync(unit);
            await _db.SaveChangesAsync();
            return _mapper.Map<MovementOfUnit, MovementOfUnitDTO>(addedUnit.Entity);
        }

        public async Task<int> DeleteMovement(int unitId)
        {
            var unitDetail = await _db.MovementsOfUnits.FindAsync(unitId);
            if (unitDetail != null)
            {
                _db.MovementsOfUnits.Remove(unitDetail);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<MovementOfUnitDTO>> GetAllMovements()
        {
            try
            {
                IEnumerable<MovementOfUnitDTO> unitDTOs =
                    _mapper.Map<IEnumerable<MovementOfUnit>, IEnumerable<MovementOfUnitDTO>>(_db.MovementsOfUnits);

                return unitDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<MovementOfUnitDTO> GetMovement(int unitId)
        {
            try
            {
                MovementOfUnitDTO unit = _mapper.Map<MovementOfUnit, MovementOfUnitDTO>(
                    await _db.MovementsOfUnits.FirstOrDefaultAsync(x => x.MovementId == unitId));

                return unit;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<MovementOfUnitDTO> IsUnitMovementUnique(string librarian, int unitId = 0)
        {
            try
            {
                if (unitId == 0)
                {
                    MovementOfUnitDTO unit = _mapper.Map<MovementOfUnit, MovementOfUnitDTO>(
                        await _db.MovementsOfUnits.FirstOrDefaultAsync(x => x.Librarian == librarian));

                    return unit;
                }
                else
                {
                    MovementOfUnitDTO unit = _mapper.Map<MovementOfUnit, MovementOfUnitDTO>(
                        await _db.MovementsOfUnits.FirstOrDefaultAsync(x => x.Librarian == librarian && x.MovementId != unitId));

                    return unit;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<MovementOfUnitDTO> UpdateMovement(int unitId, MovementOfUnitDTO movementOfUnits)
        {
            try
            {
                if (unitId == movementOfUnits.MovementId)
                {
                    MovementOfUnit movementDetails = await _db.MovementsOfUnits.FindAsync(unitId);
                    MovementOfUnit unitMap = _mapper.Map<MovementOfUnitDTO, MovementOfUnit>(movementOfUnits, movementDetails);

                    unitMap.UpdatedBy = "";
                    unitMap.UpdatedDate = DateTime.Now;

                    var updatedBook = _db.MovementsOfUnits.Update(unitMap);

                    await _db.SaveChangesAsync();
                    return _mapper.Map<MovementOfUnit, MovementOfUnitDTO>(updatedBook.Entity);
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
