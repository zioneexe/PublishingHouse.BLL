using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class PrintOrderMapper
    {
        public static IPrintOrder ToEntity(this PrintOrderInput input)
        {
            return new PrintOrder
            {
                Number = input.Number,
                PrintType  = input.PrintType,
                PaperType = input.PaperType,
                CoverType = input.CoverType,
                FasteningType = input.FasteningType,
                IsLaminated = input.IsLaminated,
                Price = input.Price,
                OrderStatusId = input.OrderStatusId,
                CustomerId = input.CustomerId,
                EmployeeId = input.EmployeeId
            };
        }

        public static PrintOrderOutput ToOutputModel(this IPrintOrder printOrder)
        {
            return new PrintOrderOutput
            {
                OrderId = printOrder.OrderId,
                Number = printOrder.Number,
                PrintType = printOrder.PrintType,
                PaperType = printOrder.PaperType,
                CoverType = printOrder.CoverType,
                FasteningType = printOrder.FasteningType,
                IsLaminated = printOrder.IsLaminated,
                Price = printOrder.Price,
                OrderStatusId = printOrder.OrderStatusId,
                RegistrationDate = printOrder.RegistrationDate,
                CompletionDate = printOrder.CompletionDate,
                CustomerId = printOrder.CustomerId,
                EmployeeId = printOrder.EmployeeId,
                CreateDateTime = printOrder.CreateDateTime,
                UpdateDateTime = printOrder.UpdateDateTime
            };
        }
    }
}
