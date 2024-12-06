using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class CityService(IUnitOfWork unitOfWork) : ICityService
    {
        public async Task<ICity> GetByIdAsync(int id)
        {
            return await unitOfWork.Cities.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ICity>> GetAllAsync()
        {
            return await unitOfWork.Cities.GetAllAsync();
        }

        public async Task AddAsync(ICity entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.Cities.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, ICity entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.Cities.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.Cities.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }
    }
}