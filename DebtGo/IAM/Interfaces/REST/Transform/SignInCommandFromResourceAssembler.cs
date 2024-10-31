using DebtGo.IAM.Interfaces.REST.Resources;
using DebtGo.IAM.Domain.Model.Commands;

namespace DebtGo.IAM.Interfaces.REST.Transform
{
    public class SignInCommandFromResourceAssembler
    {
        public static SignInCommand ToCommandFromResource(SignInResource resource)
        {
            return new SignInCommand(resource.Email, resource.Password);
        }
    }
}