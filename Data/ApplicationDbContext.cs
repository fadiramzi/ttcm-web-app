using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ttcm_mvc.Models;

namespace ttcm_mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, ApplicationRole, int>
    {
        public DbSet<Prog> Programs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("AspNetUsers");
            builder.Entity<Trainer>().ToTable("Trainers");
            builder.Entity<Trainee>().ToTable("Trainees");
            builder.Entity<Admin>().ToTable("Admins");

            base.OnModelCreating(builder);

        }
    }
}
