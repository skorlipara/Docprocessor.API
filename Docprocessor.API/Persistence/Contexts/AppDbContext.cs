using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Docprocessor.API.Domain.Models;

namespace Docprocessor.API.Persistence.Contexts
{
    public class AppDbContext
    {
        public DbSet<Doc> Docs { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Doc>().ToTable("Docs");
            builder.Entity<Doc>().HasKey(d => d.Id);
            builder.Entity<Doc>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Doc>().Property(d => d.Name).IsRequired().HasMaxLength(30);

            builder.Entity<Doc>().HasData
            (
                new Doc { Id = 100, Name = "Microsoft Document" }, // Id set manually due to in-memory provider
                new Doc { Id = 101, Name = "Google Document" }
            );

        }
    }
}
