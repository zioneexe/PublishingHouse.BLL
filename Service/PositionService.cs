using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class PositionService(IPositionRepository repository) : IPositionService
{
    public async Task<List<PositionOutput>> GetAllAsync()
    {
        var positions = await repository.GetAllAsync();
        return positions.Select(position => position.ToOutputModel()).ToList();
    }

    public async Task<PositionOutput?> GetByIdAsync(int id)
    {
        var position = await repository.GetByIdAsync(id);
        return position?.ToOutputModel();
    }

    public async Task<PositionOutput> AddAsync(PositionInput positionInput)
    {
        ArgumentNullException.ThrowIfNull(positionInput, nameof(positionInput));

        var positionEntity = positionInput.ToEntity();
        var createdPosition = await repository.AddAsync(positionEntity);
        return createdPosition.ToOutputModel();
    }

    public async Task<PositionOutput?> UpdateAsync(int id, PositionInput positionInput)
    {
        ArgumentNullException.ThrowIfNull(positionInput, nameof(positionInput));

        var existingPosition = await repository.GetByIdAsync(id);
        if (existingPosition == null) return null;

        var updatedEntity = positionInput.ToEntity();
        updatedEntity.PositionId = id;

        var updatedPosition = await repository.UpdateAsync(id, updatedEntity);
        return updatedPosition?.ToOutputModel();
    }

    public async Task<PositionOutput?> DeleteAsync(int id)
    {
        var position = await repository.DeleteAsync(id);
        return position?.ToOutputModel();
    }

    public async Task<PositionOutput?> GetPositionWithEmployeesAsync(int id)
    {
        throw new NotImplementedException();
    }
}

