using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shoptask.Models;

namespace shoptask.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Typeb> types { get; set; }
        public DbSet<Blog> blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company { Id=1,Name="Niki"},
                new Company { Id=2,Name="Adidas"}
                );
            modelBuilder.Entity<Typeb>().HasData(new Typeb { Id = 1, Name = "comedy" },
                new Typeb { Id=2,Name= "drama" },
                new Typeb { Id=3,Name= "Action" }
                );
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
