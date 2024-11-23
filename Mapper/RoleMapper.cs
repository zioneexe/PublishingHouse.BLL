using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Mapper
{
    public static class RoleMapper
    {
        public static IRole ToEntity(this RoleInput input)
        {
            return new Role
            {
                Name = input.Name,
            };
        }

        public static RoleOutput ToOutputModel(this IRole role)
        {
            return new RoleOutput
            {
                RoleId = role.RoleId,
                Name = role.Name,               
            };
        }
    }
}
