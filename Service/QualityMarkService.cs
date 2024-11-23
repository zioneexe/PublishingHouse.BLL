using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class QualityMarkService(IQualityMarkRepository repository) : IQualityMarkService
{
    public async Task<List<QualityMarkOutput>> GetAllAsync()
    {
        var qualityMarks = await repository.GetAllAsync();
        return qualityMarks.Select(qualityMark => qualityMark.ToOutputModel()).ToList();
    }

    public async Task<QualityMarkOutput?> GetByIdAsync(int id)
    {
        var qualityMark = await repository.GetByIdAsync(id);
        return qualityMark?.ToOutputModel();
    }

    public async Task<QualityMarkOutput> AddAsync(QualityMarkInput qualityMarkInput)
    {
        ArgumentNullException.ThrowIfNull(qualityMarkInput, nameof(qualityMarkInput));

        var qualityMarkEntity = qualityMarkInput.ToEntity();
        var createdQualityMark = await repository.AddAsync(qualityMarkEntity);
        return createdQualityMark.ToOutputModel();
    }

    public async Task<QualityMarkOutput?> UpdateAsync(int id, QualityMarkInput qualityMarkInput)
    {
        ArgumentNullException.ThrowIfNull(qualityMarkInput, nameof(qualityMarkInput));

        var existingQualityMark = await repository.GetByIdAsync(id);
        if (existingQualityMark == null) return null;

        var updatedEntity = qualityMarkInput.ToEntity();
        updatedEntity.QualityMarkId = id;

        var updatedQualityMark = await repository.UpdateAsync(id, updatedEntity);
        return updatedQualityMark?.ToOutputModel();
    }

    public async Task<QualityMarkOutput?> DeleteAsync(int id)
    {
        var qualityMark = await repository.DeleteAsync(id);
        return qualityMark?.ToOutputModel();
    }

    public async Task<QualityMarkOutput?> GetQualityMarkWithBatchPrintsAsync(int id)
    {
        throw new NotImplementedException();
    }
}

