using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class AuthorService(IAuthorRepository repository) : IAuthorService
{
    public async Task<List<AuthorOutput>> GetAllAsync()
    {
        var authors = await repository.GetAllAsync();
        return authors.Select(author => author.ToOutputModel()).ToList();
    }

    public async Task<AuthorOutput?> GetByIdAsync(int id)
    {
        var author = await repository.GetByIdAsync(id);
        return author?.ToOutputModel();
    }

    public async Task<AuthorOutput> AddAsync(AuthorInput authorInput)
    {
        ArgumentNullException.ThrowIfNull(authorInput, nameof(authorInput));

        var authorEntity = authorInput.ToEntity();
        var createdAuthor = await repository.AddAsync(authorEntity);
        return createdAuthor.ToOutputModel();
    }

    public async Task<AuthorOutput?> UpdateAsync(int id, AuthorInput authorInput)
    { 
        ArgumentNullException.ThrowIfNull(authorInput, nameof(authorInput));

        var existingAuthor = await repository.GetByIdAsync(id);
        if (existingAuthor == null) return null;

        var updatedEntity = authorInput.ToEntity();
        updatedEntity.AuthorId = id;

        var updatedAuthor = await repository.UpdateAsync(id,updatedEntity);
        return updatedAuthor?.ToOutputModel();
    }

    public async Task<AuthorOutput?> DeleteAsync(int id)
    {
        var author = await repository.DeleteAsync(id);
        return author?.ToOutputModel();
    }

    public async Task<AuthorOutput?> GetAuthorWithBooksAsync(int id)
    {
        throw new NotImplementedException();
    }
}

