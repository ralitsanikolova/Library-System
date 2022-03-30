using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IMovementOfUnitRepository
    {
        public Task<MovementOfUnitDTO> CreateMovement(MovementOfUnitDTO movementOfUnits);
        public Task<MovementOfUnitDTO> UpdateMovement(int unitId, MovementOfUnitDTO movementOfUnits);
        public Task<int> DeleteMovement(int unitId);
        public Task<MovementOfUnitDTO> GetMovement(int unitId);
        public Task<MovementOfUnitDTO> IsUnitMovementUnique(string librarian, int unitId = 0);
        public Task<IEnumerable<MovementOfUnitDTO>> GetAllMovements();
    }
}
