namespace SULS.App.Controllers
{
    using Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using System.Linq;
    using ViewModels.Submissions;

    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            SubmissionProblemViewModel model = new SubmissionProblemViewModel();

            var id = this.Request.QueryData["id"].FirstOrDefault();

            var modelProblem = this.problemsService.GetAll()
                .FirstOrDefault(x => x.Id == id);

            if (modelProblem != null)
            {
                model.ProblemId = modelProblem.Id;
                model.Name = modelProblem.Name;
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(SubmissionsCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Submissions/Create");
            }

            this.submissionsService.Create(model.Code, this.User.Id, model.ProblemId);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete()
        {
            var submissionId = this.Request.QueryData["id"].FirstOrDefault();

            this.submissionsService.Delete(submissionId);

            return this.Redirect("/");
        }
    }
}
