using DebtGo.IAM.Interfaces.REST.Resources;
using DebtGo.IAM.Domain.Model.Aggregates;

namespace DebtGo.IAM.Interfaces.REST.Transform
{
    public class UserResourceFromEntityAssembler
    {
        public static UserResource ToResourceFromEntity(User user)
        {
            return new UserResource(user.Id, user.Email);
        }
    }
}