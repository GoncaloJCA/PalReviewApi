using Microsoft.EntityFrameworkCore;
using PalReviewApi.Models;

namespace PalReviewApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pal> Pals { get; set; }
        public DbSet<PalCategory> PalCategories { get; set; }
        public DbSet<PalOwner> PalOwners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalCategory>()
                .HasKey(pc => new { pc.PalId, pc.CategoryId });
            modelBuilder.Entity<PalCategory>()
                .HasOne(p => p.Pal)
                .WithMany(pc => pc.PalCategories)
                .HasForeignKey(p => p.PalId);
            modelBuilder.Entity<PalCategory>()
                .HasOne(c => c.Category)
                .WithMany(pc => pc.PalCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PalOwner>()
                .HasKey(po => new { po.PalId, po.OwnerId });
            modelBuilder.Entity<PalOwner>()
                .HasOne(p => p.Pal)
                .WithMany(po => po.PalOwners)
                .HasForeignKey(p => p.PalId);
            modelBuilder.Entity<PalOwner>()
                .HasOne(o => o.Owner)
                .WithMany(po => po.PalOwners)
                .HasForeignKey(o => o.OwnerId);
        }
    }
}
