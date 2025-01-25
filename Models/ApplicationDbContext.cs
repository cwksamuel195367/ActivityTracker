using Microsoft.EntityFrameworkCore;
namespace ActivityTracker.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Filename=./Activities.sqlite");
        }

        public DbSet<Activities> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Activities>().HasData(new Activities
            {
                Id = 1,
                Name = "Take Home Project",
                Date = DateOnly.FromDateTime(DateTime.Now),
                Summary = "What more do you want to know?"
            });
        }
    }
}
