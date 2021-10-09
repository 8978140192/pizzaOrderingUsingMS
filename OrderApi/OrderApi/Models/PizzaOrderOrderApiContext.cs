using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OrderApi.Models
{
    public partial class PizzaOrderOrderApiContext : DbContext
    {
        public PizzaOrderOrderApiContext()
        {
        }

        public PizzaOrderOrderApiContext(DbContextOptions<PizzaOrderOrderApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderToppingDetail> OrderToppingDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=KANINI-LTP-455\\SQLSERVER2019G3;user id=sa;password=Admin@123;Initial catalog=PizzaOrderOrderApi");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__OrderDet__727E838B6FA229A1");

                entity.Property(e => e.PizzaId)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__38996AB5");
            });

            modelBuilder.Entity<OrderToppingDetail>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.ToppingId })
                    .HasName("PK__OrderTop__DC0F3DC8C9A2B6D6");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.ToppingId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("toppingId");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderToppingDetails)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderTopp__itemI__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
