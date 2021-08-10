using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Context : DbContext
    {
        public DbSet<ChartData> Charts { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ChartData>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(p => p.Category)
                    .HasMaxLength(100);
                entity.Property(p => p.Value);
                entity.Property(p => p.Status);
            });

        }
    }
}