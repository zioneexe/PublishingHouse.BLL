using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class CustomerMapper
    {
        public static ICustomer ToEntity(this CustomerInput input)
        {
            return new Customer
            {
                CustomerTypeId = input.CustomerTypeId,
                Name = input.Name,
                Email = input.Email
            };
        }

        public static CustomerOutput ToOutputModel(this ICustomer customer)
        {
            return new CustomerOutput
            {
                CustomerId = customer.CustomerId,
                CustomerTypeId = customer.CustomerTypeId,
                Name = customer.Name,
                AddressDate = customer.AddressDate,
                Email = customer.Email,
                CreateDateTime = customer.CreateDateTime,
                UpdateDateTime = customer.UpdateDateTime
            };
        }
    }
}
