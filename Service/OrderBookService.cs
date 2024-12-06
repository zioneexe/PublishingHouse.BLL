using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class OrderBookService(IUnitOfWork unitOfWork) : IOrderBookService
    {
        public async Task<IOrderBook> GetByIdAsync(int id)
        {
            return await unitOfWork.OrderBooks.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IOrderBook>> GetAllAsync()
        {
            return await unitOfWork.OrderBooks.GetAllAsync();
        }

        public async Task AddAsync(IOrderBook entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.OrderBooks.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IOrderBook entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.OrderBooks.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.OrderBooks.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<IOrderBook>> GetBooksByOrderIdAsync(int orderId)
        {
            return await unitOfWork.OrderBooks.GetByOrderIdAsync(orderId);
        }

    }
}