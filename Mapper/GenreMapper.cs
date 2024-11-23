using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class GenreMapper
    {
        public static IGenre ToEntity(this GenreInput input)
        {
            return new Genre
            {
                Name = input.Name
            };
        }

        public static GenreOutput ToOutputModel(this IGenre genre)
        {
            return new GenreOutput
            {
                GenreId = genre.GenreId,
                Name = genre.Name,
                CreateDateTime = genre.CreateDateTime,
                UpdateDateTime = genre.UpdateDateTime
            };
        }
    }
}
