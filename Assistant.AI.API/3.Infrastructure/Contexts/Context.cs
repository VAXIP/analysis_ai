using System;
using System.Collections.Generic;
using Assistant.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assistant.Infrastructure.Contexts;

public partial class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AssistantThread> AssistantThreads { get; set; }

    public virtual DbSet<SalesRecord> SalesRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssistantThread>(entity =>
        {
            entity.HasKey(e => e.ThreadsId).HasName("threads_pkey");

            entity.ToTable("assistant_threads", "assistant_settings");

            entity.Property(e => e.ThreadsId)
                .HasColumnType("character varying")
                .HasColumnName("threads_id");
            entity.Property(e => e.AssistantId)
                .HasColumnType("character varying")
                .HasColumnName("assistant_id");
        });

        modelBuilder.Entity<SalesRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sales_records_pkey");

            entity.ToTable("sales_records", "assistant_settings");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('sales_records_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(255)
                .HasColumnName("product_category");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.SaleDate).HasColumnName("sale_date");
            entity.Property(e => e.SaleLocation)
                .HasMaxLength(255)
                .HasColumnName("sale_location");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10, 2)
                .HasColumnName("unit_price");
            entity.Property(e => e.UnitsSold).HasColumnName("units_sold");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
