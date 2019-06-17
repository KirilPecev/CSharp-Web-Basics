namespace SULS.Services
{
    using Models;

    public interface IUsersService
    {
        string Create(User user);

        User LogIn(string username, string password);
    }
}
