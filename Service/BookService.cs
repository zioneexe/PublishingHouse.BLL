using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class BookService(IBookRepository repository) : IBookService
{
    public async Task<List<BookOutput>> GetAllAsync()
    {
        var books = await repository.GetAllAsync();
        return books.Select(book => book.ToOutputModel()).ToList();
    }

    public async Task<BookOutput?> GetByIdAsync(int id)
    {
        var book = await repository.GetByIdAsync(id);
        return book?.ToOutputModel();
    }

    public async Task<BookOutput> AddAsync(BookInput bookInput)
    {
        ArgumentNullException.ThrowIfNull(bookInput, nameof(bookInput));

        var bookEntity = bookInput.ToEntity();
        var createdBook = await repository.AddAsync(bookEntity);
        return createdBook.ToOutputModel();
    }

    public async Task<BookOutput?> UpdateAsync(int id, BookInput bookInput)
    {
        ArgumentNullException.ThrowIfNull(bookInput, nameof(bookInput));

        var existingBook = await repository.GetByIdAsync(id);
        if (existingBook == null) return null;

        var updatedEntity = bookInput.ToEntity();
        updatedEntity.BookId = id;

        var updatedBook = await repository.UpdateAsync(id, updatedEntity);
        return updatedBook?.ToOutputModel();
    }

    public async Task<BookOutput?> DeleteAsync(int id)
    {
        var book = await repository.DeleteAsync(id);
        return book?.ToOutputModel();
    }

    public async Task<BookOutput?> GetBookWithDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }
}