using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class BookMapper
    {
        public static IBook ToEntity(this BookInput input)
        {
            return new Book
            {
                Name = input.Name,
                AuthorId = input.AuthorId,
                GenreId = input.GenreId,
                Sku = input.Sku,
                Isbn = input.Isbn,
                Pages = input.Pages,
                PublicationYear = input.PublicationYear,
                Size = input.Size,
                Weight = input.Weight,
                Annotation = input.Annotation
            };
        }

        public static BookOutput ToOutputModel(this IBook book)
        {
            return new BookOutput
            {
                BookId = book.BookId,
                Name = book.Name,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId,
                Sku = book.Sku,
                Isbn = book.Isbn,
                Pages = book.Pages,
                PublicationYear = book.PublicationYear,
                Size = book.Size,
                Weight = book.Weight,
                Annotation = book.Annotation,
                CreateDateTime = book.CreateDateTime,
                UpdateDateTime = book.UpdateDateTime
            };
        }
    }
}
