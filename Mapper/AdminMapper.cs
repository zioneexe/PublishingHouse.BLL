using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper;

public static class AdminMapper
{
    public static IAdmin ToEntity(this AdminInput input)
    {
        return new Admin
        {
            Department = input.Department,
            UserId = input.UserId,
        };
    }

    public static AdminOutput ToOutputModel(this IAdmin admin)
    {
        return new AdminOutput
        {
            AdminId = admin.AdminId,
            UserId = admin.UserId,
            Department = admin.Department,
            CreateDateTime = admin.CreateDateTime,
            UpdateDateTime = admin.UpdateDateTime
        };
    }
}