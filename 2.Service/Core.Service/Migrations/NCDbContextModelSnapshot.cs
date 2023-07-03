﻿// <auto-generated />
using System;
using Core.Service.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Service.Migrations
{
    [DbContext(typeof(NCDbContext))]
    partial class NCDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Enable")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("T_Books", null, t =>
                        {
                            t.HasCheckConstraint("CK_Book_Price", "[Price] > 0");
                        });
                });

            modelBuilder.Entity("Core.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Enable")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("T_Role", (string)null);
                });

            modelBuilder.Entity("Core.Models.SalesOrderDetail", b =>
                {
                    b.Property<int>("SalesOrderId")
                        .HasColumnType("int")
                        .HasColumnName("SalesOrderID")
                        .HasComment("Primary key. Foreign key to SalesOrderHeader.SalesOrderID.");

                    b.Property<int>("SalesOrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SalesOrderDetailID")
                        .HasComment("Primary key. One incremental unique number per product sold.");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesOrderDetailId"));

                    b.Property<string>("CarrierTrackingNumber")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("Shipment tracking number supplied by the shipper.");

                    b.Property<decimal>("LineTotal")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("numeric(38, 6)")
                        .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false)
                        .HasComment("Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())")
                        .HasComment("Date and time the record was last updated.");

                    b.Property<short>("OrderQty")
                        .HasColumnType("smallint")
                        .HasComment("Quantity ordered per product.");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID")
                        .HasComment("Product sold to customer. Foreign key to Product.ProductID.");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())")
                        .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

                    b.Property<int>("SpecialOfferId")
                        .HasColumnType("int")
                        .HasColumnName("SpecialOfferID")
                        .HasComment("Promotional code. Foreign key to SpecialOffer.SpecialOfferID.");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money")
                        .HasComment("Selling price of a single product.");

                    b.Property<decimal>("UnitPriceDiscount")
                        .HasColumnType("money")
                        .HasComment("Discount amount.");

                    b.HasKey("SalesOrderId", "SalesOrderDetailId")
                        .HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

                    b.HasIndex(new[] { "Rowguid" }, "AK_SalesOrderDetail_rowguid")
                        .IsUnique();

                    b.HasIndex(new[] { "ProductId" }, "IX_SalesOrderDetail_ProductID");

                    b.ToTable("SalesOrderDetail", "Sales", t =>
                        {
                            t.HasComment("Individual products associated with a specific sales order. See SalesOrderHeader.");

                            t.HasTrigger("iduSalesOrderDetail");
                        });
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Enable")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("T_Users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
