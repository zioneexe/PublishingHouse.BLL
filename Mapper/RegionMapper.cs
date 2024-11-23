using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class RegionMapper
    {
        public static IRegion ToEntity(this RegionInput input)
        {
            return new Region
            {
                Name = input.Name
            };
        }

        public static RegionOutput ToOutputModel(this IRegion region)
        {
            return new RegionOutput
            {
                RegionId = region.RegionId,
                Name = region.Name,
                CreateDateTime = region.CreateDateTime,
                UpdateDateTime = region.UpdateDateTime
            };
        }
    }
}
