using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class UserMapper
    {
        public static IUser ToEntity(this UserInput input)
        {
            return new User
            {
                RoleId = input.RoleId,
                Username = input.Username,
                PasswordHash = input.PasswordHash,
                FullName = input.FullName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber
            };
        }

        public static UserOutput ToOutputModel(this IUser user)
        {
            return new UserOutput
            {
                UserId = user.UserId,
                RoleId = user.RoleId,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CreateDateTime = user.CreateDateTime,
                UpdateDateTime = user.UpdateDateTime
            };
        }
    }
}
