namespace SULS.Services
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Linq;

    public class SubmissionService : ISubmissionsService
    {
        private readonly SULSContext context;

        public SubmissionService(SULSContext context)
        {
            this.context = context;
        }

        public void Create(string code, string userId, string problemId)
        {
            var user = this.context.Users.FirstOrDefault(u => u.Id == userId);
            var problem = this.context.Problems.FirstOrDefault(p => p.Id == problemId);

            Random random = new Random();

            int achieveResult = random.Next(0, problem.Points);

            Submission submission = new Submission()
            {
                Code = code,
                AchievedResult = achieveResult,
                CreatedOn = DateTime.Now,
                Problem = problem,
                User = user
            };

            this.context.Submissions.Add(submission);
            this.context.SaveChanges();
        }

        public void Delete(string submissionId)
        {
            var submission = this.context.Submissions.FirstOrDefault(s => s.Id == submissionId);

            this.context.Submissions.Remove(submission);
            this.context.SaveChanges();
        }

        public IQueryable<Submission> GetAll()
        {
            return this.context
                    .Submissions
                    .Include(x => x.User)
                    .Include(x => x.Problem)
                    .AsQueryable<Submission>();
        }
    }
}
