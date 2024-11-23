using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class UserService(IUserRepository repository) : IUserService
{
    public async Task<List<UserOutput>> GetAllAsync()
    {
        var users = await repository.GetAllAsync();
        return users.Select(user => user.ToOutputModel()).ToList();
    }

    public async Task<UserOutput?> GetByIdAsync(int id)
    {
        var user = await repository.GetByIdAsync(id);
        return user?.ToOutputModel();
    }

    public async Task<UserOutput> AddAsync(UserInput userInput)
    {
        ArgumentNullException.ThrowIfNull(userInput, nameof(userInput));

        var userEntity = userInput.ToEntity();
        var createdUser = await repository.AddAsync(userEntity);
        return createdUser.ToOutputModel();
    }

    public async Task<UserOutput?> UpdateAsync(int id, UserInput userInput)
    {
        ArgumentNullException.ThrowIfNull(userInput, nameof(userInput));

        var existingUser = await repository.GetByIdAsync(id);
        if (existingUser == null) return null;

        var updatedEntity = userInput.ToEntity();
        updatedEntity.UserId = id;

        var updatedUser = await repository.UpdateAsync(id,updatedEntity);
        return updatedUser?.ToOutputModel();
    }

    public async Task<UserOutput?> DeleteAsync(int id)
    {
        var user = await repository.DeleteAsync(id);
        return user?.ToOutputModel();
    }

    public async Task<UserOutput?> GetUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<UserOutput?> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }
}