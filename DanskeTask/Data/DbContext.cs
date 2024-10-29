using DanskeTask.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DanskeTask.Data
{

    public partial class SearchDBContext : DbContext
    {
        public SearchDBContext()
        {
        }

        public SearchDBContext(DbContextOptions<SearchDBContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<SearchResult> SearchResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(e => e.Id);

            });

            modelBuilder.Entity<SearchResult>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Records)
                    .WithOne(e => e.SearchResult)
                    .HasForeignKey(e => e.SearchResultId)
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
