using System;
using System.Collections.Generic;
using Avito_Console.Resources;
using Microsoft.EntityFrameworkCore;

namespace Avito_Console.Models;

public partial class AvitoContext : DbContext
{
    public AvitoContext()
    {
    }

    public AvitoContext(DbContextOptions<AvitoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Advert> Adverts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Коли профукал нужный файл - значит ты с ноля его и пишешь! (сказал я себе. Вот что значит безумие...)
        string connectionStr = ConntectionHelper.GetConnectionString();

        optionsBuilder.UseNpgsql(connectionStr);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Advert_pkey");

            entity.ToTable("Advert", tb => tb.HasComment("Объявления"));

            entity.HasIndex(e => e.User, "fki_User");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Label).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Text).HasMaxLength(500);

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Adverts)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Category");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.Adverts)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Category_pkey");

            entity.ToTable("Category", tb => tb.HasComment("Категории товаров"));

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User", tb => tb.HasComment("Пользователи приложения"));

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(12);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
