namespace SULS.App.ViewModels.Users
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UsersLoginInputModel
    {
        private const string ErrorMessage = "Invalid username or password!";

        [RequiredSis]
        [StringLengthSis(5, 20, ErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, ErrorMessage)]
        public string Password { get; set; }
    }
}
