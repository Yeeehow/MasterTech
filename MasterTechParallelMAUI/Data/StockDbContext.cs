using Microsoft.EntityFrameworkCore;
using MasterTechParallelMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTechParallelMAUI.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Staff> Staffs => Set<Staff>();
        public DbSet<Aisle> Aisles => Set<Aisle>();
        public DbSet<AisleLevel> AisleLevels => Set<AisleLevel>();
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            // User
            b.Entity<User>(e =>
            {
                e.HasKey(x => x.UserId);
                e.Property(x => x.UserId).HasMaxLength(16).IsRequired();
                e.Property(x => x.Name).HasMaxLength(32).IsRequired();
            });

            // Staff
            b.Entity<Staff>(e =>
            {
                e.HasKey(x => x.StaffUserId);
                e.Property(x => x.StaffUserId).HasMaxLength(16).IsRequired();
                e.Property(x => x.Name).HasMaxLength(32).IsRequired();
            });

            // Aisle
            b.Entity<Aisle>(e =>
            {
                e.HasKey(x => x.AisleId);                  // R_ID
                e.Property(x => x.RackId);
                e.Property(x => x.FloorLevel);
                e.HasMany(x => x.Levels)
                 .WithOne(x => x.Aisle!)
                 .HasForeignKey(x => x.AisleId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // AisleLevel
            b.Entity<AisleLevel>(e =>
            {
                e.HasKey(x => x.LevelId);                 // RL_ID
                e.HasIndex(x => new { x.LevelId, x.AisleId }).IsUnique(false);
                e.HasMany(x => x.Products)
                 .WithOne(x => x.AisleLevel!)
                 .HasForeignKey(x => x.AisleLevelId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // Product
            b.Entity<Product>(e =>
            {
                e.HasKey(x => x.ProductId);               // P_ID
                e.HasOne(x => x.Aisle)
                 .WithMany()
                 .HasForeignKey(x => x.AisleId)
                 .OnDelete(DeleteBehavior.Restrict);

                // Basic validation constraints
                e.Property(x => x.StockOnRack).HasDefaultValue(0);
                e.Property(x => x.StockInTotal).HasDefaultValue(0);
            });
        }
    }
}
