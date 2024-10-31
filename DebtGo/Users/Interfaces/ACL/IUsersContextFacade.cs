namespace DebtGo.Users.Interfaces.ACL;

public interface IUsersContextFacade
{
    Task<int> CreateUser(string firstName, string lastName, string email);
    Task<int> FetchProfileIdByEmail(string email);
}