namespace SULS.App.ViewModels.Submissions
{
    using System.Collections.Generic;

    public class SubmissionsListViewModel
    {
        public SubmissionsListViewModel()
        {
            this.Submissions = new List<SubmissionsDetailsViewModel>();
        }

        public List<SubmissionsDetailsViewModel> Submissions { get; set; }

        public string Name { get; set; }
    }
}
