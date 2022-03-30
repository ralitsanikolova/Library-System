using DataAccess.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class MovementOfUnit
    {
        public MovementOfUnit()
        {
            LibraryUnits = new HashSet<LibraryUnit>();
        }

        public int MovementId { get; set; }

        [Required(ErrorMessage = "Please choose movement.")]
        public Movement Movement { get; set; }

        [Required(ErrorMessage = "Please enter year of date of movement.")]
        public DateTime DateTimeOfMovement { get; set; }

        [Required(ErrorMessage = "Please enter deadline.")]
        public DateTime Deadline { get; set; }

        [Required(ErrorMessage = "Please enter reader name.")]
        public string Reader { get; set; }

        [Required(ErrorMessage = "Please enter librarian name.")]
        public string Librarian { get; set; }
        public UnitCondition? UnitCondition { get; set; }

        public ICollection<LibraryUnit> LibraryUnits { get; set; }


        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
