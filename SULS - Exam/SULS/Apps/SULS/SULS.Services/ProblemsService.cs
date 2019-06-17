namespace SULS.Services
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Linq;

    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext context;

        public ProblemsService(SULSContext context)
        {
            this.context = context;
        }

        public void Create(Problem problem)
        {
            this.context
                .Problems.Add(problem);

            this.context.SaveChanges();
        }

        public IQueryable<Problem> GetAll()
        {
            return this.context
                .Problems
                .Include(x => x.Submissions)
                .AsQueryable<Problem>();
        }
    }
}
