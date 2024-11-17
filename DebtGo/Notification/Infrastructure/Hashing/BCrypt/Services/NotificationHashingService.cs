using System.Security.Cryptography;
using System.Text;

namespace NotificationsBC.Infrastructure.Hashing.Services
{
    public class NotificationHashingService
    {
        public string Hash(string data)
        {
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
            return Convert.ToBase64String(hashedBytes);
        }

        public bool Verify(string data, string hashedData)
        {
            string hashedInput = Hash(data);
            return hashedInput == hashedData;
        }
    }
}
