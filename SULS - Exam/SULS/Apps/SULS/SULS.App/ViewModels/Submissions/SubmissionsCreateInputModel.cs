namespace SULS.App.ViewModels.Submissions
{
    using SIS.MvcFramework.Attributes.Validation;

    public class SubmissionsCreateInputModel
    {
        private const string CodeErrorMessage = "Invalid code! Must be between 30 and 800 symbols!";

        [RequiredSis]
        [StringLengthSis(30, 800, CodeErrorMessage)]
        public string Code { get; set; }

        public string ProblemId { get; set; }
    }
}
