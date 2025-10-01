using BCrypt.Net;

namespace UsersApplication.Helpers
{
    public static class Encrypt
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password,string hashPass)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPass);
        }
    }
}
