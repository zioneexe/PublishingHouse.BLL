using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class QualityMarkService(IUnitOfWork unitOfWork) : IQualityMarkService
    {
        public async Task<IQualityMark> GetByIdAsync(int id)
        {
            return await unitOfWork.QualityMarks.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IQualityMark>> GetAllAsync()
        {
            return await unitOfWork.QualityMarks.GetAllAsync();
        }

        public async Task AddAsync(IQualityMark entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.QualityMarks.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IQualityMark entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.QualityMarks.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.QualityMarks.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }

    }
}