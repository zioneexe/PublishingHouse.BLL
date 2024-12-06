using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class PrintOrderService(IUnitOfWork unitOfWork) : IPrintOrderService
    {
        public async Task<IPrintOrder> GetByIdAsync(int id)
        {
            return await unitOfWork.PrintOrders.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IPrintOrder>> GetAllAsync()
        {
            return await unitOfWork.PrintOrders.GetAllAsync();
        }

        public async Task AddAsync(IPrintOrder entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.PrintOrders.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IPrintOrder entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.PrintOrders.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.OrderBooks.DeleteByOrderIdAsync(id);
            await unitOfWork.PrintOrders.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<IPrintOrder>> GetByCustomerIdAsync(int customerId)
        {
            return await unitOfWork.PrintOrders.GetByCustomerIdAsync(customerId);
        }

        public async Task<IEnumerable<IPrintOrder>> GetByEmployeeIdAsync(int employeeId)
        {
            return await unitOfWork.PrintOrders.GetByEmployeeIdAsync(employeeId);
        }

        public async Task CancelOrderAsync(int orderId)
        {
            var order = await unitOfWork.PrintOrders.GetByIdAsync(orderId);
            if (order == null)
                throw new KeyNotFoundException($"Order with ID {orderId} not found.");

            if (order.OrderStatus?.Name == "Cancelled")
                throw new InvalidOperationException($"Order with ID {orderId} is already canceled.");

            var canceledStatus = await unitOfWork.OrderStatuses.GetByNameAsync("Cancelled");
            if (canceledStatus == null)
                throw new InvalidOperationException($"Order status 'Cancelled' does not exist.");

            order.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.PrintOrders.UpdateOrderStatusAsync(orderId, canceledStatus);
            await unitOfWork.CompleteAsync();
        }

        public async Task<int> AddWithIdAsync(IPrintOrder entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            var orderId = await unitOfWork.PrintOrders.AddWithIdAsync(entity);
            await unitOfWork.CompleteAsync();

            return orderId;
        }

    }
}