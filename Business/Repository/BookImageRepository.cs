using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using ModelsDTO;

namespace Business.Repository
{
    public class BookImageRepository : IBookImageRepository
    {
        private readonly OnlineLibraryDbContext _db;
        private readonly IMapper _mapper;
        public BookImageRepository(OnlineLibraryDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<int> CreateBookImage(BookImageDTO imageDTO)
        {
            var image = _mapper.Map<BookImageDTO, BookImage>(imageDTO);
            await _db.BookImages.AddAsync(image);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteBookImageByBookId(int bookId)
        {
            var imageList = await _db.BookImages.Where(x => x.BookId == bookId).ToListAsync();
            _db.BookImages.RemoveRange(imageList);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteBookImageByImageId(int imageId)
        {
            var image = await _db.BookImages.FindAsync(imageId);
            _db.BookImages.Remove(image);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteBookImageByImageUrl(string imageUrl)
        {
            var allImages = await _db.BookImages.FirstOrDefaultAsync(x => x.BookImageUrl.ToLower() == imageUrl.ToLower());
            if (allImages != null)
            {
                return 0;
            }
            _db.BookImages.Remove(allImages);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookImageDTO>> GetBookImages(int bookId)
        {
            return _mapper.Map<IEnumerable<BookImage>, IEnumerable<BookImageDTO>>(
              await _db.BookImages.Where(x => x.BookId == bookId).ToListAsync());
        }
    }
}
