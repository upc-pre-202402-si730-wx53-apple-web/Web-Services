using DebtGo.Users.Domain.Model.Commands;
using DebtGo.Users.Interfaces.REST.Resources;

namespace DebtGo.Users.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(resource.FirstName, resource.LastName, resource.Email);
    }
}