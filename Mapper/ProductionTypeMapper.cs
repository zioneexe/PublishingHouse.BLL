using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class ProductionTypeMapper
    {
        public static IProductionType ToEntity(this ProductionTypeInput input)
        {
            return new ProductionType
            {
                Name = input.Name
            };
        }

        public static ProductionTypeOutput ToOutputModel(this IProductionType productionType)
        {
            return new ProductionTypeOutput
            {
                ProductionTypeId = productionType.ProductionTypeId,
                Name = productionType.Name,
                CreateDateTime = productionType.CreateDateTime,
                UpdateDateTime = productionType.UpdateDateTime
            };
        }
    }
}
