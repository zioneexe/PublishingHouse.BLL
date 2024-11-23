using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class CityMapper
    {
        public static ICity ToEntity(this CityInput input)
        {
            return new City
            {
                RegionId = input.RegionId,
                Name = input.Name
            };
        }

        public static CityOutput ToOutputModel(this ICity city)
        {
            return new CityOutput
            {
                CityId = city.CityId,
                RegionId = city.RegionId,
                Name = city.Name,
                CreateDateTime = city.CreateDateTime,
                UpdateDateTime = city.UpdateDateTime
            };
        }
    }
}
