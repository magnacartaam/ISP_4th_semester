﻿using Microsoft.EntityFrameworkCore;

namespace _253504_Patrebka.Persistense.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base (dbContextOptions)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>()
                .HasMany(c => c.Advertisements)
                .WithOne(a => a.Car)
                .HasForeignKey(a => a.CarId);
            modelBuilder.Entity<Advertisement>()
                .HasOne(a => a.Car)
                .WithMany(c => c.Advertisements);
        }
    }
}
