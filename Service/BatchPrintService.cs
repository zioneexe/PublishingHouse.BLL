using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class BatchPrintService(IBatchPrintRepository repository) : IBatchPrintService
{
    public async Task<List<BatchPrintOutput>> GetAllAsync()
    {
        var batchPrints = await repository.GetAllAsync();
        return batchPrints.Select(batchPrint => batchPrint.ToOutputModel()).ToList();
    }

    public async Task<BatchPrintOutput?> GetByIdAsync(int id)
    {
        var batchPrint = await repository.GetByIdAsync(id);
        return batchPrint?.ToOutputModel();
    }

    public async Task<BatchPrintOutput> AddAsync(BatchPrintInput batchPrintInput)
    {
        ArgumentNullException.ThrowIfNull(batchPrintInput, nameof(batchPrintInput));

        var batchPrintEntity = batchPrintInput.ToEntity();
        var createdBatchPrint = await repository.AddAsync(batchPrintEntity);
        return createdBatchPrint.ToOutputModel();
    }

    public async Task<BatchPrintOutput?> UpdateAsync(int id, BatchPrintInput batchPrintInput)
    {
        ArgumentNullException.ThrowIfNull(batchPrintInput, nameof(batchPrintInput));

        var existingBatchPrint = await repository.GetByIdAsync(id);
        if (existingBatchPrint == null) return null;

        var updatedEntity = batchPrintInput.ToEntity();
        updatedEntity.BatchPrintId = id;

        var updatedBatchPrint = await repository.UpdateAsync(id,updatedEntity);
        return updatedBatchPrint?.ToOutputModel();
    }

    public async Task<BatchPrintOutput?> DeleteAsync(int id)
    {
        var batchPrint = await repository.DeleteAsync(id);
        return batchPrint?.ToOutputModel();
    }

    public async Task<BatchPrintOutput?> GetBatchPrintWithDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }
}

