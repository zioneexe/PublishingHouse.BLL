using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class RoleService(IRoleRepository repository) : IRoleService
{
    public async Task<List<RoleOutput>> GetAllAsync()
    {
        var roles = await repository.GetAllAsync();
        return roles.Select(role => role.ToOutputModel()).ToList();
    }

    public async Task<RoleOutput?> GetByIdAsync(int id)
    {
        var role = await repository.GetByIdAsync(id);
        return role?.ToOutputModel();
    }

    public async Task<RoleOutput> AddAsync(RoleInput roleInput)
    {
        ArgumentNullException.ThrowIfNull(roleInput, nameof(roleInput));

        var roleEntity = roleInput.ToEntity();
        var createdRole = await repository.AddAsync(roleEntity);
        return createdRole.ToOutputModel();
    }

    public async Task<RoleOutput?> UpdateAsync(int id, RoleInput roleInput)
    {
        ArgumentNullException.ThrowIfNull(roleInput, nameof(roleInput));

        var existingRole = await repository.GetByIdAsync(id);
        if (existingRole == null) return null;

        var updatedEntity = roleInput.ToEntity();
        updatedEntity.RoleId = id;

        var updatedRole = await repository.UpdateAsync(id, updatedEntity);
        return updatedRole?.ToOutputModel();
    }

    public async Task<RoleOutput?> DeleteAsync(int id)
    {
        var role = await repository.DeleteAsync(id);
        return role?.ToOutputModel();
    }

    public async Task<RoleOutput?> GetRoleByRoleNameAsync(string roleName)
    {
        throw new NotImplementedException();
    }

    public async Task<RoleOutput?> GetRoleByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }
}