using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class RegionService(IRegionRepository repository) : IRegionService
{
    public async Task<List<RegionOutput>> GetAllAsync()
    {
        var regions = await repository.GetAllAsync();
        return regions.Select(region => region.ToOutputModel()).ToList();
    }

    public async Task<RegionOutput?> GetByIdAsync(int id)
    {
        var region = await repository.GetByIdAsync(id);
        return region?.ToOutputModel();
    }

    public async Task<RegionOutput> AddAsync(RegionInput regionInput)
    {
        ArgumentNullException.ThrowIfNull(regionInput, nameof(regionInput));

        var regionEntity = regionInput.ToEntity();
        var createdRegion = await repository.AddAsync(regionEntity);
        return createdRegion.ToOutputModel();
    }

    public async Task<RegionOutput?> UpdateAsync(int id, RegionInput regionInput)
    {
        ArgumentNullException.ThrowIfNull(regionInput, nameof(regionInput));

        var existingRegion = await repository.GetByIdAsync(id);
        if (existingRegion == null) return null;

        var updatedEntity = regionInput.ToEntity();
        updatedEntity.RegionId = id;

        var updatedRegion = await repository.UpdateAsync(id, updatedEntity);
        return updatedRegion?.ToOutputModel();
    }

    public async Task<RegionOutput?> DeleteAsync(int id)
    {
        var region = await repository.DeleteAsync(id);
        return region?.ToOutputModel();
    }

    public async Task<RegionOutput?> GetRegionWithCitiesAsync(int id)
    {
        throw new NotImplementedException();
    }
}

