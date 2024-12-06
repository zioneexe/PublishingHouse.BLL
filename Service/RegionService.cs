using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class RegionService(IUnitOfWork unitOfWork) : IRegionService
    {
        public async Task<IRegion> GetByIdAsync(int id)
        {
            return await unitOfWork.Regions.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IRegion>> GetAllAsync()
        {
            return await unitOfWork.Regions.GetAllAsync();
        }

        public async Task AddAsync(IRegion entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.Regions.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IRegion entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.Regions.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.Regions.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }
    }
}