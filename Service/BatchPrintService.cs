using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class BatchPrintService(IUnitOfWork unitOfWork) : IBatchPrintService
    {
        public async Task<IBatchPrint> GetByIdAsync(int id)
        {
            return await unitOfWork.BatchPrints.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IBatchPrint>> GetAllAsync()
        {
            return await unitOfWork.BatchPrints.GetAllAsync();
        }

        public async Task AddAsync(IBatchPrint entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.BatchPrints.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IBatchPrint entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.BatchPrints.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.BatchPrints.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }
    }
}