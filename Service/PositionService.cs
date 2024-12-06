using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class PositionService(IUnitOfWork unitOfWork) : IPositionService
    {
        public async Task<IPosition> GetByIdAsync(int id)
        {
            return await unitOfWork.Positions.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IPosition>> GetAllAsync()
        {
            return await unitOfWork.Positions.GetAllAsync();
        }

        public async Task AddAsync(IPosition entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.Positions.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IPosition entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.Positions.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.Positions.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }
    }
}