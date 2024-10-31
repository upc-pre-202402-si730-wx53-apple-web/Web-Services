using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;
using DebtGo.Users.Domain.Model.Commands;
using DebtGo.Users.Domain.Model.ValueObjects;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace DebtGo.Users.Domain.Model.Aggregates;

public partial class User
{
    public User()
    {
        Name = new PersonName();
        Email = new EmailAddress();
    }
    
    public User(string firstName, string lastName, string email)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
    }

    public User(CreateUserCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
    }
    
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
}