using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToolStore.Domain.Models;

namespace ToolStore.Infrastructure.Context
{
    public class ToolStoreDbContext : DbContext
    {
        public ToolStoreDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.HasIndex(e => e.CategoryId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Tools)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(d => d.Orders)
                    .WithMany(p => p.Tools)
                    .UsingEntity<Dictionary<string, object>>(
                        "ToolsOrder",
                        l => l.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.ClientSetNull),
                        r => r.HasOne<Tool>().WithMany().HasForeignKey("ToolId").OnDelete(DeleteBehavior.ClientSetNull),
                        j =>
                        {
                            j.HasKey("ToolId", "OrderId");
                        });
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired();

                entity.HasOne(d => d.Tool)
                    .WithOne(p => p.Inventory)
                    .HasForeignKey<Inventory>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}