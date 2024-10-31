using DebtGo.IAM.Domain.Model.Commands;
using DebtGo.IAM.Domain.Model.Entities;

namespace DebtGo.IAM.Domain.Model.Aggregates
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public PaymentCard PaymentCard { get; private set; }

        public User()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            PaymentCard = new PaymentCard();
        }

        public User(SignInCommand command)
        {
            Email = command.Email;
            Password = command.Password;
        }

        public User(SignUpCommand command)
        {
            Name = command.Name;
            Email = command.Email;
            Password = command.Password;
            PaymentCard = new PaymentCard(command.CardNumber, command.ExpiryDate, command.CVV);
        }
    }
}