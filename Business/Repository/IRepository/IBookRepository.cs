using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IBookRepository
    {
        public Task<BookDTO> CreateBook(BookDTO bookDTO);
        public Task<BookDTO> UpdateBook(int bookId, BookDTO bookDTO);
        public Task<int> DeleteBook(int bookId);
        public Task<BookDTO> GetBook(int bookId);
        public Task<BookDTO> IsBookUnique(string title, int bookId = 0);
        public Task<IEnumerable<BookDTO>> GetAllBooks();
    }
}
