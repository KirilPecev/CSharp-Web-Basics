namespace SULS.App.Controllers
{
    using Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels.Problems;

    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return Index();
        }

        public IActionResult Index()
        {
            ProblemsListViewModel model = new ProblemsListViewModel();

            if (this.IsLoggedIn())
            {
                var problems = this.problemsService.GetAll();

                model.Problems = new List<ProblemsViewModel>();

                if (problems != null)
                {
                    var problemsList = problems.Select(x => new ProblemsViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Count = x.Submissions.Count
                    }).ToList();

                    model.Problems = problemsList;
                }

                return this.View(model, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}