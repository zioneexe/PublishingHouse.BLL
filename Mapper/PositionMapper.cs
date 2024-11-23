using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class PositionMapper
    {
        public static IPosition ToEntity(this PositionInput input)
        {
            return new Position
            {
                Name = input.Name
            };
        }

        public static PositionOutput ToOutputModel(this IPosition position)
        {
            return new PositionOutput
            {
                PositionId = position.PositionId,
                Name = position.Name,
                CreateDateTime = position.CreateDateTime,
                UpdateDateTime = position.UpdateDateTime
            };
        }
    }
}
