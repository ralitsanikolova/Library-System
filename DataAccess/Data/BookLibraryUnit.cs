using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class BookLibraryUnit
    {
        public int BookId { get; set; }
        public int InventoryId { get; set; }
        public Book Book { get; set; }
        public LibraryUnit LibraryUnit { get; set; }
    }
}
