using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly OnlineLibraryDbContext _db;
        private readonly IMapper _mapper;
        public BookRepository(OnlineLibraryDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<BookDTO> CreateBook(BookDTO bookDTO)
        {
            Book book = _mapper.Map<BookDTO, Book>(bookDTO);
            book.CreatedDate = DateTime.Now;
            book.CreatedBy = "";
            var addedBook = await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
            return _mapper.Map<Book, BookDTO>(addedBook.Entity);
        }

        public async Task<int> DeleteBook(int bookId)
        {
            var bookDetail = await _db.Books.FindAsync(bookId);
            if (bookDetail != null)
            {
                var allImages = await _db.BookImages.Where(x => x.BookId == bookId).ToListAsync();
                foreach (var image in allImages)
                {
                    if (File.Exists(image.BookImageUrl))
                    {
                        File.Delete(image.BookImageUrl);
                    }
                }
                _db.BookImages.RemoveRange(allImages);
                _db.Books.Remove(bookDetail);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            try
            {
                IEnumerable<BookDTO> bookDTOs =
                    _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(_db.Books);

                

                return bookDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<BookDTO> GetBook(int bookId)
        {
            try
            {
                BookDTO book = _mapper.Map<Book, BookDTO>(
                  await _db.Books.Include(x => x.Sections).SingleOrDefaultAsync(y => y.BookId == bookId));

                // .Include(x => x.Sections.Select(y => y.Section))

                //.FirstOrDefaultAsync(x => x.BookId == bookId));

                return book;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<BookDTO> IsBookUnique(string title, int bookId = 0)
        {
            try
            {
                if (bookId == 0)
                {
                    BookDTO book = _mapper.Map<Book, BookDTO>(
                        await _db.Books.FirstOrDefaultAsync(x => x.Title == title.ToLower()));

                    return book;
                }
                else
                {
                    BookDTO book = _mapper.Map<Book, BookDTO>(
                        await _db.Books.FirstOrDefaultAsync(x => x.Title == title.ToLower() && x.BookId != bookId));
                    return book;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<BookDTO> UpdateBook(int bookId, BookDTO bookDTO)
        {
            try
            {
                if (bookId == bookDTO.BookId)
                {
                    Book bookDetails = await _db.Books.FindAsync(bookId);
                    Book bookMap = _mapper.Map<BookDTO, Book>(bookDTO, bookDetails);

                    bookMap.UpdatedBy = "";
                    bookMap.UpdatedDate = DateTime.Now;

                    var updatedBook = _db.Books.Update(bookMap);

                    await _db.SaveChangesAsync();
                    return _mapper.Map<Book, BookDTO>(updatedBook.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
