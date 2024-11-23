using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper;

public static class AuthorMapper
{
    public static IAuthor ToEntity(this AuthorInput input)
    {
        return new Author
        {
            Name = input.Name
        };
    }

    public static AuthorOutput ToOutputModel(this IAuthor author)
    {
        return new AuthorOutput
        {
            AuthorId = author.AuthorId,
            Name = author.Name,
            CreateDateTime = author.CreateDateTime,
            UpdateDateTime = author.UpdateDateTime
        };
    }
}