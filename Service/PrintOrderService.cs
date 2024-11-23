using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class PrintOrderService(IPrintOrderRepository repository) : IPrintOrderService
{
    public async Task<List<PrintOrderOutput>> GetAllAsync()
    {
        var printOrders = await repository.GetAllAsync();
        return printOrders.Select(printOrder => printOrder.ToOutputModel()).ToList();
    }

    public async Task<PrintOrderOutput?> GetByIdAsync(int id)
    {
        var printOrder = await repository.GetByIdAsync(id);
        return printOrder?.ToOutputModel();
    }

    public async Task<PrintOrderOutput> AddAsync(PrintOrderInput printOrderInput)
    {
        ArgumentNullException.ThrowIfNull(printOrderInput, nameof(printOrderInput));

        var printOrderEntity = printOrderInput.ToEntity();
        var createdPrintOrder = await repository.AddAsync(printOrderEntity);
        return createdPrintOrder.ToOutputModel();
    }

    public async Task<PrintOrderOutput?> UpdateAsync(int id, PrintOrderInput printOrderInput)
    {
        ArgumentNullException.ThrowIfNull(printOrderInput, nameof(printOrderInput));

        var existingPrintOrder = await repository.GetByIdAsync(id);
        if (existingPrintOrder == null) return null;

        var updatedEntity = printOrderInput.ToEntity();
        updatedEntity.OrderId = id;

        var updatedPrintOrder = await repository.UpdateAsync(id, updatedEntity);
        return updatedPrintOrder?.ToOutputModel();
    }

    public async Task<PrintOrderOutput?> DeleteAsync(int id)
    {
        var printOrder = await repository.DeleteAsync(id);
        return printOrder?.ToOutputModel();
    }

    public async Task<PrintOrderOutput?> GetPrintOrderWithDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }
}