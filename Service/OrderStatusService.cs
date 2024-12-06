using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class OrderStatusService(IUnitOfWork unitOfWork) : IOrderStatusService
    {
        public async Task<IOrderStatus> GetByIdAsync(int id)
        {
            return await unitOfWork.OrderStatuses.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IOrderStatus>> GetAllAsync()
        {
            return await unitOfWork.OrderStatuses.GetAllAsync();
        }

        public async Task AddAsync(IOrderStatus entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.OrderStatuses.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IOrderStatus entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.OrderStatuses.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.OrderStatuses.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }
    }
}