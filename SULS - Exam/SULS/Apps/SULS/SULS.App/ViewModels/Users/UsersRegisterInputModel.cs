namespace SULS.App.ViewModels.Users
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UsersRegisterInputModel
    {
        private const string UsernameErrorMessage = "Invalid username! Must be between 5 and 20 symbols!";
        private const string PasswordErrorMessage = "Invalid username! Must be between 6 and 20 symbols!";
        private const string EmailErrorMessage = "Invalid email!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [EmailSis(EmailErrorMessage)]
        public string Email { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, PasswordErrorMessage)]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }
    }
}
