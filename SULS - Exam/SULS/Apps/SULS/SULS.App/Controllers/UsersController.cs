namespace SULS.App.Controllers
{
    using Models;
    using Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Result;
    using ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Authorize("anonymous")]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize("anonymous")]
        public IActionResult Login(UsersLoginInputModel user)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var currentUser = this.usersService.LogIn(user.Username, user.Password);

            if (currentUser == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(currentUser.Id, currentUser.Username, currentUser.Email);

            return this.Redirect("/");
        }

        [Authorize("anonymous")]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize("anonymous")]
        public IActionResult Register(UsersRegisterInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            User currentUser = ModelMapper.ProjectTo<User>(model);

            var id = this.usersService.Create(currentUser);

            if (id == null)
            {
                ModelState.Add("User", "User with this username already exists! Please choose another username.");
                return this.Redirect("/Users/Register");
            }

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}