using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class GenreService(IGenreRepository repository) : IGenreService
{
    public async Task<List<GenreOutput>> GetAllAsync()
    {
        var genres = await repository.GetAllAsync();
        return genres.Select(genre => genre.ToOutputModel()).ToList();
    }

    public async Task<GenreOutput?> GetByIdAsync(int id)
    {
        var genre = await repository.GetByIdAsync(id);
        return genre?.ToOutputModel();
    }

    public async Task<GenreOutput> AddAsync(GenreInput genreInput)
    {
        throw new NotImplementedException();
    }

    public async Task<GenreOutput?> UpdateAsync(int id, GenreInput genreInput)
    {
        ArgumentNullException.ThrowIfNull(genreInput, nameof(genreInput));

        var existingGenre = await repository.GetByIdAsync(id);
        if (existingGenre == null) return null;

        var updatedEntity = genreInput.ToEntity();
        updatedEntity.GenreId = id;

        var updatedGenre = await repository.UpdateAsync(id, updatedEntity);
        return updatedGenre?.ToOutputModel();
    }

    public async Task<GenreOutput?> DeleteAsync(int id)
    {
        var genre = await repository.DeleteAsync(id);
        return genre?.ToOutputModel();
    }

    public async Task<GenreOutput?> GetGenreWithBooksAsync(int id)
    {
        throw new NotImplementedException();
    }
}

