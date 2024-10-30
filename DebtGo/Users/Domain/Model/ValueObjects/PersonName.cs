namespace DebtGo.Users.Domain.Model.ValueObjects;

public record PersonName(string FirstNme, string LastName)
{
    public PersonName(): this(string.Empty, string.Empty) {}
    
    public PersonName(string firstName): this(firstName, string.Empty) {}
    
    public string FullName => $"{FirstNme} {LastName}";
}