using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic.CompilerServices;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.DAL.Data;

namespace PublishingHouse.BLL.Service
{
    public class EmployeeService(IUnitOfWork unitOfWork) : IEmployeeService
    {
        public async Task<IEmployee> GetByIdAsync(int id)
        {
            return await unitOfWork.Employees.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IEmployee>> GetAllAsync()
        {
            return await unitOfWork.Employees.GetAllAsync();
        }

        public async Task AddAsync(IEmployee entity)
        {
            entity.CreateDateTime = DateTime.UtcNow;

            await unitOfWork.Employees.AddAsync(entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, IEmployee entity)
        {
            entity.UpdateDateTime = DateTime.UtcNow;

            await unitOfWork.Employees.UpdateAsync(id, entity);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.Employees.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }

        public async Task<int> GetIdByUserIdAsync(string userId)
        {
            return await unitOfWork.Employees.GetIdByUserIdAsync(userId);
        }
    }
}