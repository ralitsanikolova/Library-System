using ModelsDTO;

namespace Business.Repository.IRepository
{
    public interface IBookImageRepository
    {
        public Task<int> CreateBookImage(BookImageDTO image);
        public Task<int> DeleteBookImageByImageId(int imageId);
        public Task<int> DeleteBookImageByBookId(int bookId);
        public Task<int> DeleteBookImageByImageUrl(string imageUrl);
        public Task<IEnumerable<BookImageDTO>> GetBookImages(int bookId);
    }
}
