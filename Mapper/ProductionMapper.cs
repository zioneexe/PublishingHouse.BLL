using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class ProductionMapper
    {
        public static IProduction ToEntity(this ProductionInput input)
        {
            return new Production
            {
                ProductionTypeId = input.ProductionTypeId,
                CityId = input.CityId,
                Address = input.Address
            };
        }

        public static ProductionOutput ToOutputModel(this IProduction production)
        {
            return new ProductionOutput
            {
                ProductionId = production.ProductionId,
                CityId = production.CityId,
                ProductionTypeId = production.ProductionTypeId,
                Address = production.Address,
                CreateDateTime = production.CreateDateTime,
                UpdateDateTime = production.UpdateDateTime
            };
        }
    }
}
