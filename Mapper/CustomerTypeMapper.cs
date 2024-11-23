using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class CustomerTypeMapper
    {
        public static ICustomerType ToEntity(this CustomerTypeInput input)
        {
            return new CustomerType
            {
                Name = input.Name
            };
        }

        public static CustomerTypeOutput ToOutputModel(this ICustomerType customerType)
        {
            return new CustomerTypeOutput
            {
                CustomerTypeId = customerType.CustomerTypeId,
                Name = customerType.Name,
                CreateDateTime = customerType.CreateDateTime,
                UpdateDateTime = customerType.UpdateDateTime
            };
        }
    }
}
