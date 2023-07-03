//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace Core.Models.Models;

//public partial class AdventureWorks2016Context : DbContext
//{
//    public AdventureWorks2016Context()
//    {
//    }

//    public AdventureWorks2016Context(DbContextOptions<AdventureWorks2016Context> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=.;database=AdventureWorks2016;uid=sa;pwd=1314520a@;TrustServerCertificate=true");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

//        modelBuilder.Entity<SalesOrderDetail>(entity =>
//        {
//            entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId }).HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

//            entity.ToTable("SalesOrderDetail", "Sales", tb =>
//                {
//                    tb.HasComment("Individual products associated with a specific sales order. See SalesOrderHeader.");
//                    tb.HasTrigger("iduSalesOrderDetail");
//                });

//            entity.HasIndex(e => e.Rowguid, "AK_SalesOrderDetail_rowguid").IsUnique();

//            entity.HasIndex(e => e.ProductId, "IX_SalesOrderDetail_ProductID");

//            entity.Property(e => e.SalesOrderId)
//                .HasComment("Primary key. Foreign key to SalesOrderHeader.SalesOrderID.")
//                .HasColumnName("SalesOrderID");
//            entity.Property(e => e.SalesOrderDetailId)
//                .ValueGeneratedOnAdd()
//                .HasComment("Primary key. One incremental unique number per product sold.")
//                .HasColumnName("SalesOrderDetailID");
//            entity.Property(e => e.CarrierTrackingNumber)
//                .HasMaxLength(25)
//                .HasComment("Shipment tracking number supplied by the shipper.");
//            entity.Property(e => e.LineTotal)
//                .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false)
//                .HasComment("Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.")
//                .HasColumnType("numeric(38, 6)");
//            entity.Property(e => e.ModifiedDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time the record was last updated.")
//                .HasColumnType("datetime");
//            entity.Property(e => e.OrderQty).HasComment("Quantity ordered per product.");
//            entity.Property(e => e.ProductId)
//                .HasComment("Product sold to customer. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");
//            entity.Property(e => e.Rowguid)
//                .HasDefaultValueSql("(newid())")
//                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                .HasColumnName("rowguid");
//            entity.Property(e => e.SpecialOfferId)
//                .HasComment("Promotional code. Foreign key to SpecialOffer.SpecialOfferID.")
//                .HasColumnName("SpecialOfferID");
//            entity.Property(e => e.UnitPrice)
//                .HasComment("Selling price of a single product.")
//                .HasColumnType("money");
//            entity.Property(e => e.UnitPriceDiscount)
//                .HasComment("Discount amount.")
//                .HasColumnType("money");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
