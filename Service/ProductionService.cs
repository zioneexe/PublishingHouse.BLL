using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class ProductionService(IProductionRepository repository) : IProductionService
{
    public async Task<List<ProductionOutput>> GetAllAsync()
    {
        var productions = await repository.GetAllAsync();
        return productions.Select(production => production.ToOutputModel()).ToList();
    }

    public async Task<ProductionOutput?> GetByIdAsync(int id)
    {
        var production = await repository.GetByIdAsync(id);
        return production?.ToOutputModel();
    }

    public async Task<ProductionOutput> AddAsync(ProductionInput productionInput)
    {
        ArgumentNullException.ThrowIfNull(productionInput, nameof(productionInput));

        var productionEntity = productionInput.ToEntity();
        var createdProduction = await repository.AddAsync(productionEntity);
        return createdProduction.ToOutputModel();
    }

    public async Task<ProductionOutput?> UpdateAsync(int id, ProductionInput productionInput)
    {
        ArgumentNullException.ThrowIfNull(productionInput, nameof(productionInput));

        var existingProduction = await repository.GetByIdAsync(id);
        if (existingProduction == null) return null;

        var updatedEntity = productionInput.ToEntity();
        updatedEntity.ProductionId = id;

        var updatedProduction = await repository.UpdateAsync(id, updatedEntity);
        return updatedProduction?.ToOutputModel();
    }

    public async Task<ProductionOutput?> DeleteAsync(int id)
    {
        var production = await repository.DeleteAsync(id);
        return production?.ToOutputModel();
    }

    public async Task<ProductionOutput?> GetProductionWithDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }
}

