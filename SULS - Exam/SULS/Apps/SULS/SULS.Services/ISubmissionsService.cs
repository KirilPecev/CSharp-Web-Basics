namespace SULS.Services
{
    using Models;
    using System.Linq;

    public interface ISubmissionsService
    {
        void Create(string code, string userId, string problemId);

        IQueryable<Submission> GetAll();

        void Delete(string submissionId);
    }
}
