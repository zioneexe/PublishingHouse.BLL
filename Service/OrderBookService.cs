using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class OrderBookService(IOrderBookRepository repository) : IOrderBookService
{
    public async Task<List<OrderBookOutput>> GetAllAsync()
    {
        var orderBooks = await repository.GetAllAsync();
        return orderBooks.Select(orderBook => orderBook.ToOutputModel()).ToList();
    }

    public async Task<OrderBookOutput?> GetByIdAsync(int id)
    {
        var orderBook = await repository.GetByIdAsync(id);
        return orderBook?.ToOutputModel();
    }

    public async Task<OrderBookOutput> AddAsync(OrderBookInput orderBookInput)
    {
        ArgumentNullException.ThrowIfNull(orderBookInput, nameof(orderBookInput));

        var orderBookEntity = orderBookInput.ToEntity();
        var createdOrderBook = await repository.AddAsync(orderBookEntity);
        return createdOrderBook.ToOutputModel();
    }

    public async Task<OrderBookOutput?> UpdateAsync(int id, OrderBookInput orderBookInput)
    {
        ArgumentNullException.ThrowIfNull(orderBookInput, nameof(orderBookInput));

        var existingOrderBook = await repository.GetByIdAsync(id);
        if (existingOrderBook == null) return null;

        var updatedEntity = orderBookInput.ToEntity();
        updatedEntity.OrderBooksId = id;

        var updatedOrderBook = await repository.UpdateAsync(id, updatedEntity);
        return updatedOrderBook?.ToOutputModel();
    }

    public async Task<OrderBookOutput?> DeleteAsync(int id)
    {
        var orderBook = await repository.DeleteAsync(id);
        return orderBook?.ToOutputModel();
    }

    public async Task<OrderBookOutput?> GetOrderBookWithDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }
}

