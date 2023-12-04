﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiceTrader.Models;

#nullable disable

namespace RiceTrader.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231204013355_LinkFinalOrderToPurchaseOrder")]
    partial class LinkFinalOrderToPurchaseOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RiceTrader.Models.FinalOrder", b =>
                {
                    b.Property<int>("FinalOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FinalOrderId"), 1L, 1);

                    b.Property<int>("PoId")
                        .HasColumnType("int");

                    b.HasKey("FinalOrderId");

                    b.HasIndex("PoId");

                    b.ToTable("FinalOrders");
                });

            modelBuilder.Entity("RiceTrader.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("OrderQueue", (string)null);
                });

            modelBuilder.Entity("RiceTrader.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("PoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoId"), 1L, 1);

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PoId");

                    b.ToTable("PurchaseOrder", (string)null);
                });

            modelBuilder.Entity("RiceTrader.Models.FinalOrder", b =>
                {
                    b.HasOne("RiceTrader.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany("FinalOrders")
                        .HasForeignKey("PoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("RiceTrader.Models.PurchaseOrder", b =>
                {
                    b.Navigation("FinalOrders");
                });
#pragma warning restore 612, 618
        }
    }
}