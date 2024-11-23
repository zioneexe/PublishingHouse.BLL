using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class OrderStatusService(IOrderStatusRepository repository) : IOrderStatusService
{
    public async Task<List<OrderStatusOutput>> GetAllAsync()
    {
        var orderStatuses = await repository.GetAllAsync();
        return orderStatuses.Select(orderStatus => orderStatus.ToOutputModel()).ToList();
    }

    public async Task<OrderStatusOutput?> GetByIdAsync(int id)
    {
        var orderStatus = await repository.GetByIdAsync(id);
        return orderStatus?.ToOutputModel();
    }

    public async Task<OrderStatusOutput> AddAsync(OrderStatusInput orderStatusInput)
    {
        ArgumentNullException.ThrowIfNull(orderStatusInput, nameof(orderStatusInput));

        var orderStatusEntity = orderStatusInput.ToEntity();
        var createdOrderStatus = await repository.AddAsync(orderStatusEntity);
        return createdOrderStatus.ToOutputModel();
    }

    public async Task<OrderStatusOutput?> UpdateAsync(int id, OrderStatusInput orderStatusInput)
    {
        ArgumentNullException.ThrowIfNull(orderStatusInput, nameof(orderStatusInput));

        var existingOrderStatus = await repository.GetByIdAsync(id);
        if (existingOrderStatus == null) return null;

        var updatedEntity = orderStatusInput.ToEntity();
        updatedEntity.OrderStatusId = id;

        var updatedOrderStatus = await repository.UpdateAsync(id, updatedEntity);
        return updatedOrderStatus?.ToOutputModel();
    }

    public async Task<OrderStatusOutput?> DeleteAsync(int id)
    {
        var orderStatus = await repository.DeleteAsync(id);
        return orderStatus?.ToOutputModel();
    }

    public async Task<OrderStatusOutput?> GetOrderStatusWithPrintOrdersAsync(int id)
    {
        throw new NotImplementedException();
    }
}

