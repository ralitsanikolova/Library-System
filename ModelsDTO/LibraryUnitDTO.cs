using DataAccess.Data;
using DataAccess.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ModelsDTO
{
    public class LibraryUnitDTO
    {
        public LibraryUnitDTO()
        {
            Books = new HashSet<BookLibraryUnit>();
        }
        public int InventoryId { get; set; }
        public int? MovementId { get; set; }

        [Required(ErrorMessage = "Please choose unit condition.")]
        public UnitCondition UnitCondition { get; set; }

        [Required(ErrorMessage = "Please enter year of carrier.")]
        public Carrier Carrier { get; set; }

        public MovementOfUnit? Movement { get; set; }
        public ICollection<BookLibraryUnit> Books { get; set; }
    }
}
