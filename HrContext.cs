using EjercitacionMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EjercitacionMVC
{
    public class HrContext : DbContext
    {
        public HrContext(DbContextOptions<HrContext> option) : base(option) {
        }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .Property(b => b.Description)
                .HasMaxLength(500)
                .IsRequired();
        }

    }
}
