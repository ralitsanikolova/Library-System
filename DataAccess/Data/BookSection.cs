using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class BookSection
    {
        public int BookId { get; set; }
        public int SectionId { get; set; }
        public Book? Book { get; set; }
        public Section? Section { get; set; }
    }
}
