using DebtGo.IAM.Application.Internal.OutBoundServices;
using DebtGo.IAM.Domain.Model.Aggregates;
using DebtGo.IAM.Domain.Model.Commands;
using DebtGo.IAM.Domain.Repositories;
using DebtGo.IAM.Domain.Services;
using DebtGo.Shared.Domain.Repositories;

namespace DebtGo.IAM.Application.Internal.CommandServices
{
    public class UserCommandService(IUserRepository userRepository, IHashingService hashingService, IUnitOfWork unitOfWork) : IUserCommandService
    {
        public async Task<User?> Handle(SignUpCommand command)
        {
            var hashedCommand = command with { Password = hashingService.GenerateHash(command.Password) };
            var user = new User(hashedCommand);

            try
            {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return user;
        }

        public async Task<User?> Handle(SignInCommand command)
        {
            var user = await userRepository.FindByEmailAsync(command.Email);

            if (user == null || !hashingService.VerifyHash(command.Password, user.Password))
                throw new Exception("Invalid username or password");

            return user;
        }
    }
}