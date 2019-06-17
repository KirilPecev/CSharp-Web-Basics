namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SULSContext : DbContext
    {
        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Submission>()
                .HasOne(e => e.User)
                .WithMany(u => u.Submissions);

            modelBuilder.Entity<Submission>()
                .HasOne(e => e.Problem)
                .WithMany(u => u.Submissions);
        }
    }
}