namespace SULS.App.Controllers
{
    using Models;
    using Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Result;
    using System.Globalization;
    using System.Linq;
    using ViewModels.Problems;
    using ViewModels.Submissions;

    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public ProblemsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ProblemsCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            Problem problem = ModelMapper.ProjectTo<Problem>(model);

            this.problemsService.Create(problem);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details()
        {
            SubmissionsListViewModel model = new SubmissionsListViewModel();

            var problemId = this.Request.QueryData["id"].FirstOrDefault();

            model.Name = this.problemsService.GetAll().FirstOrDefault(x => x.Id == problemId)?.Name;

            var submissions = this.submissionsService.GetAll().Where(x => x.Problem.Id == problemId);

            if (submissions != null)
            {
                var modelSubmissions = submissions.Select(x => new SubmissionsDetailsViewModel
                {
                    SubmissionId = x.Id,
                    AchievedResult = x.AchievedResult,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("en-EN")),
                    Username = x.User.Username,
                    MaxPoints = x.Problem.Points
                }).ToList();

                model.Submissions = modelSubmissions;
            }

            return this.View(model);
        }
    }
}
