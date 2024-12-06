using Microsoft.AspNetCore.Identity;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class CustomerService(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager) : ICustomerService
    {
        public async Task<ICustomer> GetByIdAsync(int id)
        {
            return await unitOfWork.Customers.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ICustomer>> GetAllAsync()
        {
            return await unitOfWork.Customers.GetAllAsync();
        }

        public async Task AddAsync(ICustomer entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.Customers.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, ICustomer entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.Customers.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.Customers.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }

        public async Task<int> GetIdByUserIdAsync(string userId)
        {
            return await unitOfWork.Customers.GetIdByUserIdAsync(userId);
        }

        public async Task<bool> HasUserAccess(int accessedId, string userId)
        {
            var identityUser = await userManager.FindByIdAsync(userId);
            if (identityUser is null)
            {
                throw new AccessException($"No users found with id {userId}.");
            }

            var userRoles = await userManager.GetRolesAsync(identityUser);
            if (userRoles.Contains("Admin"))
            {
                return true;
            }

            if (userRoles.Contains("Employee"))
            {
                return accessedId == await GetIdByUserIdAsync(userId);
            }

            return false;
        }
    }
}