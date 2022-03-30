using DataAccess.Data;
using DataAccess.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDTO
{
    public class BookDTO
    {
        public BookDTO()
        {
            BookImages = new HashSet<BookImage>();
            Units = new HashSet<BookLibraryUnit>();
            Sections = new HashSet<BookSection>();
        }
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter author.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter year of publish.")]
        public int YearPublished { get; set; }
        public string? Kind { get; set; }
        public int? ISBN { get; set; }
        public string? ImageUrlCatalogue { get; set; }
        public List<string> ImageUrls { get; set; }

        public ICollection<BookImage>? BookImages { get; set; }
        public ICollection<BookLibraryUnit>? Units { get; set; }
        public ICollection<BookSection>? Sections { get; set; }

    }
}
