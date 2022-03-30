using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class Section
    {
        public Section()
        {
            Books = new HashSet<BookSection>();
        }

        public int SectionId { get; set; }
        [Required(ErrorMessage = "Please enter year of name of section.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter description.")]
        public string Description { get; set; }

        public ICollection<BookSection> Books { get; set; }


        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
