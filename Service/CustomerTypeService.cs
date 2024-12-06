using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class CustomerTypeService(IUnitOfWork unitOfWork) : ICustomerTypeService
    {
        public async Task<ICustomerType> GetByIdAsync(int id)
        {
            return await unitOfWork.CustomerTypes.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ICustomerType>> GetAllAsync()
        {
            return await unitOfWork.CustomerTypes.GetAllAsync();
        }

        public async Task AddAsync(ICustomerType entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.CustomerTypes.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, ICustomerType entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.CustomerTypes.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.CustomerTypes.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }
    }
}