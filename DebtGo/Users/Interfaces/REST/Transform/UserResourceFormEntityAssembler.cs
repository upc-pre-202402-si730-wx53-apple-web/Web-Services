using DebtGo.Users.Domain.Model.Aggregates;
using DebtGo.Users.Interfaces.REST.Resources;

namespace DebtGo.Users.Interfaces.REST.Transform;

public static class UserResourceFormEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.FullName, entity.EmailAddress);
    }
}