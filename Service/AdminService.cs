using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;
    
public class AdminService(IAdminRepository repository) : IAdminService
{
    public async Task<List<AdminOutput>> GetAllAsync()
    {
        var admins = await repository.GetAllAsync();
        return admins.Select(admin => admin.ToOutputModel()).ToList();
    }

    public async Task<AdminOutput?> GetByIdAsync(int id)
    {
        var admin = await repository.GetByIdAsync(id);
        return admin?.ToOutputModel();
    }

    public async Task<AdminOutput> AddAsync(AdminInput adminInput)
    {
        ArgumentNullException.ThrowIfNull(adminInput, nameof(adminInput));

        var adminEntity = adminInput.ToEntity();
        var createdAdmin = await repository.AddAsync(adminEntity);
        return createdAdmin.ToOutputModel();
    }

    public async Task<AdminOutput?> UpdateAsync(int id, AdminInput adminInput)
    {
        ArgumentNullException.ThrowIfNull(adminInput, nameof(adminInput));

        var existingAdmin = await repository.GetByIdAsync(id);
        if (existingAdmin == null) return null;

        var updatedEntity = adminInput.ToEntity();
        updatedEntity.AdminId = id;

        var updatedAdmin = await repository.UpdateAsync(id, updatedEntity);
        return updatedAdmin?.ToOutputModel();
    }

    public async Task<AdminOutput?> DeleteAsync(int id)
    {
        var admin = await repository.DeleteAsync(id);
        return admin?.ToOutputModel();
    }

    public async Task<AdminOutput?> GetAdminWithUserAsync(int id)
    {
        //var adminWithUser = await repository.GetAdminWithUserAsync(id);
        //return adminWithUser?.ToOutputModel();
        return null;
    }
}