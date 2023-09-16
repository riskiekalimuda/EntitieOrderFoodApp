using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderEntitie.Models;

public partial class OrderfooddbContext : DbContext
{
    public OrderfooddbContext()
    {
    }

    public OrderfooddbContext(DbContextOptions<OrderfooddbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<ListOrder> ListOrders { get; set; }

    public virtual DbSet<TransactionOrder> TransactionOrders { get; set; }

    public virtual DbSet<TransactionOrderDetail> TransactionOrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ROH_KUDA\\SQLEXPRESS;Database=orderfooddb;User Id=test-db;Password=1234asdf;Trusted_Connection=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.ToTable("Administrator");

            entity.Property(e => e.AdminCreatedAt).HasColumnType("datetime");
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AdminName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AdminPassword).IsUnicode(false);
            entity.Property(e => e.AdminPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AdminUserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.IdFood).HasName("PK__tmp_ms_x__007D1BC6C9ECB938");

            entity.ToTable("Food");

            entity.Property(e => e.FoodName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FoodPrice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ListOrder>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__ListOrde__C38F3009F382800B");

            entity.ToTable("ListOrder");

            entity.Property(e => e.DateOrder).HasColumnType("datetime");
            entity.Property(e => e.FoodPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdFoodNavigation).WithMany(p => p.ListOrders)
                .HasForeignKey(d => d.IdFood)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ListOrder_ToTable");
        });

        modelBuilder.Entity<TransactionOrder>(entity =>
        {
            entity.HasKey(e => e.IdTrx).HasName("PK__Transact__2BC59D0D63D58472");

            entity.ToTable("TransactionOrder");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Pembayaran).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TransactionOrderDetail>(entity =>
        {
            entity.HasKey(e => e.IdOrderDetail).HasName("PK__Transact__D8E06C510B277B9D");

            entity.ToTable("TransactionOrderDetail");

            entity.Property(e => e.DateOrder).HasColumnType("datetime");
            entity.Property(e => e.FoodPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdFoodNavigation).WithMany(p => p.TransactionOrderDetails)
                .HasForeignKey(d => d.IdFood)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionOrderDetail_ToTable_1");

            entity.HasOne(d => d.IdTrxNavigation).WithMany(p => p.TransactionOrderDetails)
                .HasForeignKey(d => d.IdTrx)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionOrderDetail_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
