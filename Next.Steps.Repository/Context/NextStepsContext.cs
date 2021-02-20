using Microsoft.EntityFrameworkCore;
using Next.Steps.Domain.Entities;

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
            modelBuilder.UseIdentityColumns();

            modelBuilder.HasDefaultSchema("NextSteps");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", schema: "NextSteps");
                entity.HasKey(x => x.Id);
            });
            
            modelBuilder.Entity<Person>().OwnsMany(
                p => p.Hobbies, a =>
                {
                    a.WithOwner().HasForeignKey("PersonId");
                    a.Property<int>("Id");
                    a.HasKey("Id");
                });
        }
    }
}