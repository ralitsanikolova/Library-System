using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class BookImage
    {
        public int ImageId { get; set; }
        public int? BookId { get; set; }
        public string? BookImageUrl { get; set; }
        public Book? Book { get; set; }
    }
}
