namespace DebtGo.Notification.Infrastructure.Hashing.BCrypt.Services;

public class NotificationHashingService
{
    public string Hash(string data)
    {
        return BCrypt.Net.BCrypt.HashPassword(data);
    }

    public bool Verify(string data, string hashedData)
    {
        return BCrypt.Net.BCrypt.Verify(data, hashedData);
    }
}
