using Microsoft.EntityFrameworkCore;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.ValueTypes;

namespace Next.Steps.Infrastructure.Context
{
    public class NextStepsContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public NextStepsContext() : base()
        {
        }

        public NextStepsContext(DbContextOptions<NextStepsContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NextSteps;Data Source=DESKTOP-0GSQJ72\SQLEXPRESS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("NextSteps");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", schema: "NextSteps");
                entity.OwnsOne(h => h.Hobbies);
            });
        }
    }

}