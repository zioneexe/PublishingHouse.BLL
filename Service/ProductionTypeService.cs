using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class ProductionTypeService(IUnitOfWork unitOfWork) : IProductionTypeService
    {
        public async Task<IProductionType> GetByIdAsync(int id)
        {
            return await unitOfWork.ProductionTypes.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IProductionType>> GetAllAsync()
        {
            return await unitOfWork.ProductionTypes.GetAllAsync();
        }

        public async Task AddAsync(IProductionType entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.ProductionTypes.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IProductionType entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.ProductionTypes.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.ProductionTypes.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }
    }
}