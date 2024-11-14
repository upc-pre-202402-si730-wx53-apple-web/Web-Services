using DebtGo.IAM.Domain.Model.Aggregates;
using DebtGo.IAM.Interfaces.REST.Resources;

namespace DebtGo.IAM.Interfaces.REST.Transform
{
    public class AuthenticatedUserResourceFromEntityAssembler
    {
        public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
        {
            return new AuthenticatedUserResource(user.Id, user.Name, token);
        }
    }
}