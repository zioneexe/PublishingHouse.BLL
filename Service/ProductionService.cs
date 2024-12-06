using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class ProductionService(IUnitOfWork unitOfWork) : IProductionService
    {
        public async Task<IProduction> GetByIdAsync(int id)
        {
            return await unitOfWork.Productions.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IProduction>> GetAllAsync()
        {
            return await unitOfWork.Productions.GetAllAsync();
        }

        public async Task AddAsync(IProduction entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.Productions.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IProduction entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.Productions.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.Productions.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }
    }
}