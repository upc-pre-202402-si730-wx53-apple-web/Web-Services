using DebtGo.IAM.Domain.Model.Aggregates;
using DebtGo.IAM.Domain.Model.Commands;

namespace DebtGo.IAM.Domain.Services
{
    public interface IUserCommandService
    {
        Task<User?> Handle(SignUpCommand command);
        Task<User?> Handle(SignInCommand command);
    }
}