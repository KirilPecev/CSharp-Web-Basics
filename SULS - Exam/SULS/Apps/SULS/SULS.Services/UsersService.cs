namespace SULS.Services
{
    using Data;
    using Models;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersService : IUsersService
    {
        private readonly SULSContext context;

        public UsersService(SULSContext context)
        {
            this.context = context;
        }

        public string Create(User user)
        {
            if (context.Users.Any(u => u.Username == user.Username))
            {
                return null;
            }

            user.Password = this.HashPassword(user.Password);

            context.Users.Add(user);
            context.SaveChanges();

            return user.Id;
        }

        public User LogIn(string username, string password)
        {
            return context.Users.SingleOrDefault(x => x.Username == username && x.Password == HashPassword(password));
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
