using CRUSLesson.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRUDLesson.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
        
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-D3L48SP\SQLEXPRESS;Database=CRUDLesson;Trusted_Connection=True;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users")
                    .HasKey(k => k.Id);
                
                builder.Property(k => k.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                builder.Property(k => k.Name)
                    .HasColumnName("Name");

                builder.Property(k => k.Email)
                    .HasColumnName("Email");
            });
        }
    }
}