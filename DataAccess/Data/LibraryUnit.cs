using DataAccess.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class LibraryUnit
    {
        public LibraryUnit()
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

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
