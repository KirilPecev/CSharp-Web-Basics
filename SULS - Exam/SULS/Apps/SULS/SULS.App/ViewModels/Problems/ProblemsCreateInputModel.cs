namespace SULS.App.ViewModels.Problems
{
    using SIS.MvcFramework.Attributes.Validation;

    public class ProblemsCreateInputModel
    {
        public const string NameErrorMessage = "Invalid name! Must be between 5 and 20 symbols!";
        public const string PointsErrorMessage = "Invalid points! Must be between 50 and 300 points!";

        [RequiredSis]
        [StringLengthSis(5, 20, NameErrorMessage)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, PointsErrorMessage)]
        public int Points { get; set; }
    }
}
