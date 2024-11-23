using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class ProductionTypeService(IProductionTypeRepository repository) : IProductionTypeService
{
    public async Task<List<ProductionTypeOutput>> GetAllAsync()
    {
        var productionTypes = await repository.GetAllAsync();
        return productionTypes.Select(productionType => productionType.ToOutputModel()).ToList();
    }

    public async Task<ProductionTypeOutput?> GetByIdAsync(int id)
    {
        var productionType = await repository.GetByIdAsync(id);
        return productionType?.ToOutputModel();
    }

    public async Task<ProductionTypeOutput> AddAsync(ProductionTypeInput productionTypeInput)
    {
        ArgumentNullException.ThrowIfNull(productionTypeInput, nameof(productionTypeInput));

        var productionTypeEntity = productionTypeInput.ToEntity();
        var createdProductionType = await repository.AddAsync(productionTypeEntity);
        return createdProductionType.ToOutputModel();
    }

    public async Task<ProductionTypeOutput?> UpdateAsync(int id, ProductionTypeInput productionTypeInput)
    {
        ArgumentNullException.ThrowIfNull(productionTypeInput, nameof(productionTypeInput));

        var existingProductionType = await repository.GetByIdAsync(id);
        if (existingProductionType == null) return null;

        var updatedEntity = productionTypeInput.ToEntity();
        updatedEntity.ProductionTypeId = id;

        var updatedProductionType = await repository.UpdateAsync(id, updatedEntity);
        return updatedProductionType?.ToOutputModel();
    }

    public async Task<ProductionTypeOutput?> DeleteAsync(int id)
    {
        var productionType = await repository.DeleteAsync(id);
        return productionType?.ToOutputModel();
    }

    public async Task<ProductionTypeOutput?> GetProductionTypeWithProductionsAsync(int id)
    {
        throw new NotImplementedException();
    }
}