using DebtGo.Users.Domain.Model.ValueObjects;

namespace DebtGo.Users.Domain.Model.Queries;

public record GetUserByEmailQuery(EmailAddress Email);