﻿// <auto-generated />
using System;
using MahalaxmiFuniture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MahalaxmiFuniture.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MahalaxmiFuniture.Models.AccountControl", b =>
                {
                    b.Property<int>("accountControlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("accControlName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("accHeadId")
                        .HasColumnType("int");

                    b.Property<int?>("accId")
                        .HasColumnType("int");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("accountControlId");

                    b.HasIndex("accId");

                    b.HasIndex("userId");

                    b.ToTable("AccountControls");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.AccountHead", b =>
                {
                    b.Property<int>("accHeadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("accHeadName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("accHeadId");

                    b.HasIndex("userId");

                    b.ToTable("AccountHeads");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.AccountSubControl", b =>
                {
                    b.Property<int>("accSubControlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accControlId")
                        .HasColumnType("int");

                    b.Property<int>("accHeadId")
                        .HasColumnType("int");

                    b.Property<string>("accSubControlName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("accSubControlId");

                    b.HasIndex("userId");

                    b.ToTable("AccountSubControls");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Category", b =>
                {
                    b.Property<int>("cId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("cId");

                    b.HasIndex("userId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Customer", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("customerId");

                    b.HasIndex("userId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.CustomerInvoice", b =>
                {
                    b.Property<int>("customerInvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("invoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("invoiceNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("totalAmount")
                        .HasColumnType("real");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("customerInvoiceId");

                    b.ToTable("CustomerInvoices");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.CustomerInvoiceDetail", b =>
                {
                    b.Property<int>("customerInvoiceDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("customerInvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("pId")
                        .HasColumnType("int");

                    b.Property<int>("saleQuantity")
                        .HasColumnType("int");

                    b.Property<int>("unitPrice")
                        .HasColumnType("int");

                    b.HasKey("customerInvoiceDetailId");

                    b.ToTable("CustomerInvoiceDetails");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.CustomerPayment", b =>
                {
                    b.Property<int>("customerPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<int>("customerInvoiceId")
                        .HasColumnType("int");

                    b.Property<float>("discountPercentage")
                        .HasColumnType("real");

                    b.Property<string>("invoiceNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("paidAmount")
                        .HasColumnType("real");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("remainingAmount")
                        .HasColumnType("real");

                    b.Property<float>("totalAmount")
                        .HasColumnType("real");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("customerPaymentId");

                    b.ToTable("CustomerPayments");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Employee", b =>
                {
                    b.Property<int>("eId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("contactNo")
                        .HasColumnType("int");

                    b.Property<string>("designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("imageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("salary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("eId");

                    b.HasIndex("userId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.FinancialYear", b =>
                {
                    b.Property<int>("financialYearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("financialYear")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("financialYearId");

                    b.ToTable("FinancialYears");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date_of_order")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("requiredDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("shippedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("orderId");

                    b.HasIndex("customerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.OrderDetails", b =>
                {
                    b.Property<int>("orderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("pId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("unitPrice")
                        .HasColumnType("int");

                    b.HasKey("orderDetailId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Payroll", b =>
                {
                    b.Property<int>("payrollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeeId")
                        .HasColumnType("int");

                    b.Property<int>("eId")
                        .HasColumnType("int");

                    b.Property<DateTime>("paymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("payrollInvoiceNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("salaryMonth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salaryYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("totalAmount")
                        .HasColumnType("real");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("payrollId");

                    b.HasIndex("EmployeeeId");

                    b.ToTable("Payrolls");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Product", b =>
                {
                    b.Property<int>("pId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategorycId")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.Property<int>("cId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("totalQuantity")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("pId");

                    b.HasIndex("CategorycId");

                    b.HasIndex("userId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Stock", b =>
                {
                    b.Property<int>("cId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("currentPurchaseUnitPrice")
                        .HasColumnType("real");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("manufactureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("pId")
                        .HasColumnType("int");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<float>("saleUnitPrice")
                        .HasColumnType("real");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("cId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Supplier", b =>
                {
                    b.Property<int>("sId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("supplierAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("supplierContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("supplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("sId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.SupplierInvoice", b =>
                {
                    b.Property<int>("supplierInvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("invoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("invoiceNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("totalAmount")
                        .HasColumnType("float");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("supplierInvoiceId");

                    b.ToTable("SupplierInvoices");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.SupplierInvoiceDetail", b =>
                {
                    b.Property<int>("supplierInvoiceDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("pId")
                        .HasColumnType("int");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("purchaseQuantity")
                        .HasColumnType("int");

                    b.Property<int>("purchaseUnitPrice")
                        .HasColumnType("int");

                    b.Property<int>("supplierInvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("supplierInvoiceDetailId");

                    b.ToTable("SupplierInvoiceDetails");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.SupplierPayment", b =>
                {
                    b.Property<int>("supplierPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("invoiceNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("paymentAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("remainingAmount")
                        .HasColumnType("float");

                    b.Property<int>("sId")
                        .HasColumnType("int");

                    b.Property<int>("supplierInvoiceId")
                        .HasColumnType("int");

                    b.Property<double>("totalAmount")
                        .HasColumnType("float");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("supplierPaymentId");

                    b.ToTable("SupplierPayments");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Transaction", b =>
                {
                    b.Property<int>("tId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accountControlId")
                        .HasColumnType("int");

                    b.Property<int>("accountHeadId")
                        .HasColumnType("int");

                    b.Property<int>("accountSubControlId")
                        .HasColumnType("int");

                    b.Property<int>("credit")
                        .HasColumnType("int");

                    b.Property<int>("debit")
                        .HasColumnType("int");

                    b.Property<int>("financialYear")
                        .HasColumnType("int");

                    b.Property<string>("invoiceNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("transactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("transactionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("tId");

                    b.HasIndex("userId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("contactNo")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.UserType", b =>
                {
                    b.Property<int>("userTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("postedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("userTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userTypeId");

                    b.HasIndex("userId");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.AccountControl", b =>
                {
                    b.HasOne("MahalaxmiFuniture.Models.AccountHead", "AccountHeads")
                        .WithMany()
                        .HasForeignKey("accId");

                    b.HasOne("MahalaxmiFuniture.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountHeads");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.AccountHead", b =>
                {
                    b.HasOne("MahalaxmiFuniture.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.AccountSubControl", b =>
                {
                    b.HasOne("MahalaxmiFuniture.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Category", b =>
                {
                    b.HasOne("MahalaxmiFuniture.Models.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Customer", b =>
                {
                    b.HasOne("MahalaxmiFuniture.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Employee", b =>
                {
                    b.HasOne("MahalaxmiFuniture.Models.User", null)
                        .WithMany("Employees")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Order", b =>
                {
                    b.HasOne("MahalaxmiFuniture.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Payroll", b =>
                {
                    b.HasOne("MahalaxmiFuniture.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Product", b =>
                {
                    b.HasOne("MahalaxmiFuniture.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategorycId");

                    b.HasOne("MahalaxmiFuniture.Models.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Transaction", b =>
                {
                    b.HasOne("MahalaxmiFuniture.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.UserType", b =>
                {
                    b.HasOne("MahalaxmiFuniture.Models.User", "User")
                        .WithMany("UserTypes")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MahalaxmiFuniture.Models.User", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Employees");

                    b.Navigation("Products");

                    b.Navigation("Transactions");

                    b.Navigation("UserTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
