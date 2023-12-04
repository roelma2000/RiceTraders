using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RiceTrader.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<FinalOrder> FinalOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().ToTable("OrderQueue");

            modelBuilder.Entity<Order>()
                .Property(o => o.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<PurchaseOrder>().ToTable("PurchaseOrder");

            modelBuilder.Entity<PurchaseOrder>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(p => p.FinalOrders)
                .WithOne(f => f.PurchaseOrder)
                .HasForeignKey(f => f.PoId);
           }



    }
}
