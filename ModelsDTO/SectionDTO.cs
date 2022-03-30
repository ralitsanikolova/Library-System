using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDTO
{
    public class SectionDTO
    {
        public SectionDTO()
        {
            Books = new HashSet<BookSection>();
        }

        public int SectionId { get; set; }
        [Required(ErrorMessage = "Please enter year of name of section.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter description.")]
        public string Description { get; set; }
        public ICollection<BookSection> Books { get; set; }

    }
}
