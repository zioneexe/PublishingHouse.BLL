using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class OrderStatusMapper
    {
        public static IOrderStatus ToEntity(this OrderStatusInput input)
        {
            return new OrderStatus
            {
                Name = input.Name
            };
        }

        public static OrderStatusOutput ToOutputModel(this IOrderStatus orderStatus)
        {
            return new OrderStatusOutput
            {
                OrderStatusId = orderStatus.OrderStatusId,
                Name = orderStatus.Name,
                CreateDateTime = orderStatus.CreateDateTime,
                UpdateDateTime = orderStatus.UpdateDateTime
            };
        }
    }
}
