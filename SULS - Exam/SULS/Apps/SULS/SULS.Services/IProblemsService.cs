namespace SULS.Services
{
    using Models;
    using System.Linq;

    public interface IProblemsService
    {
        void Create(Problem problem);

        IQueryable<Problem> GetAll();
    }
}
