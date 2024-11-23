using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class EmployeeMapper
    {
        public static IEmployee ToEntity(this EmployeeInput input)
        {
            return new Employee
            {
                UserId = input.UserId,
                PositionId = input.PositionId,
                ProductionId = input.ProductionId,
            };
        }

        public static EmployeeOutput ToOutputModel(this IEmployee employee)
        {
            return new EmployeeOutput
            {
                EmployeeId = employee.EmployeeId,
                UserId = employee.UserId,
                PositionId = employee.PositionId,
                ProductionId = employee.ProductionId,
                CreateDateTime = employee.CreateDateTime,
                UpdateDateTime = employee.UpdateDateTime
            };
        }
    }
}
