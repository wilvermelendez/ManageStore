﻿// <auto-generated />
using System;
using ManageStore.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManageStore.ApplicationDbContext.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190915231207_AddInitialTables_Products_Billings_BillingDetails_Users_and_ProductLogs")]
    partial class AddInitialTables_Products_Billings_BillingDetails_Users_and_ProductLogs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManageStore.Models.Models.Billing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<DateTime?>("ModifieDateTime");

                    b.Property<int?>("ModifiedById");

                    b.Property<int>("ReceiptType");

                    b.Property<int>("RegisterStatus");

                    b.Property<int>("VoucherNumber");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Billings");
                });

            modelBuilder.Entity("ManageStore.Models.Models.BillingDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillingId");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime?>("ModifieDateTime");

                    b.Property<int?>("ModifiedById");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("ProductId");

                    b.Property<double>("Quantity");

                    b.Property<int>("RegisterStatus");

                    b.HasKey("Id");

                    b.HasIndex("BillingId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("ProductId");

                    b.ToTable("BillingDetails");
                });

            modelBuilder.Entity("ManageStore.Models.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("ModifieDateTime");

                    b.Property<int?>("ModifiedById");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("RegisterStatus");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ManageStore.Models.Models.ProductLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime?>("ModifieDateTime");

                    b.Property<int?>("ModifiedById");

                    b.Property<decimal>("NewPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("ProductId");

                    b.Property<int>("RegisterStatus");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductLogs");
                });

            modelBuilder.Entity("ManageStore.Models.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<DateTime?>("ModifieDateTime");

                    b.Property<int?>("ModifiedById");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<int>("RegisterStatus");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById")
                        .IsUnique()
                        .HasFilter("[ModifiedById] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ManageStore.Models.Models.Billing", b =>
                {
                    b.HasOne("ManageStore.Models.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ManageStore.Models.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");
                });

            modelBuilder.Entity("ManageStore.Models.Models.BillingDetail", b =>
                {
                    b.HasOne("ManageStore.Models.Models.Billing", "Billing")
                        .WithMany()
                        .HasForeignKey("BillingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ManageStore.Models.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ManageStore.Models.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.HasOne("ManageStore.Models.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManageStore.Models.Models.Product", b =>
                {
                    b.HasOne("ManageStore.Models.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ManageStore.Models.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");
                });

            modelBuilder.Entity("ManageStore.Models.Models.ProductLog", b =>
                {
                    b.HasOne("ManageStore.Models.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ManageStore.Models.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.HasOne("ManageStore.Models.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManageStore.Models.Models.User", b =>
                {
                    b.HasOne("ManageStore.Models.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ManageStore.Models.Models.User", "ModifiedBy")
                        .WithOne()
                        .HasForeignKey("ManageStore.Models.Models.User", "ModifiedById");
                });
#pragma warning restore 612, 618
        }
    }
}
