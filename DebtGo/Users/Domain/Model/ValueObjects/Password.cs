namespace DebtGo.Users.Domain.Model.ValueObjects;

public record Password(string Passwords)
{
    public Password() : this(string.Empty) {}
}