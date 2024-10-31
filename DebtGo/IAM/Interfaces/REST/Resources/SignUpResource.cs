namespace DebtGo.IAM.Interfaces.REST.Resources
{
    //TODO docs
    public record SignUpResource(string Name, string Email, string Password, string CardNumber, string ExpiryDate, string CVV);
}