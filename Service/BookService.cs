using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class BookService(IUnitOfWork unitOfWork) : IBookService
    {
        public async Task<IBook> GetByIdAsync(int id)
        {
            return await unitOfWork.Books.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IBook>> GetAllAsync()
        {
            return await unitOfWork.Books.GetAllAsync();
        }

        public async Task AddAsync(IBook entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.Books.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IBook entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.Books.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.Books.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }

        public async Task<int> AddWithIdAsync(IBook entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            var bookId = await unitOfWork.Books.AddWithIdAsync(entity);
            await unitOfWork.CompleteAsync();

            return bookId;
        }
    }
}