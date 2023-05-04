﻿// <auto-generated />
using System;
using E_mart_final_project.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Emartfinalproject.Migrations
{
    [DbContext(typeof(EmartContext))]
    [Migration("20230227123129_add_toCart_col_update_withQTY2")]
    partial class add_toCart_col_update_withQTY2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_mart_final_project.models.AddToCart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartID"));

                    b.Property<double>("CardHolderPrice")
                        .HasColumnType("float");

                    b.Property<double>("DiscountPrice")
                        .HasColumnType("float");

                    b.Property<int>("PointRedm")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductMastersProductID")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersUserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CartID");

                    b.HasIndex("ProductMastersProductID");

                    b.HasIndex("UsersUserName");

                    b.ToTable("AddToCarts");
                });

            modelBuilder.Entity("E_mart_final_project.models.CatMaster", b =>
                {
                    b.Property<int>("CatMasterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatMasterID"));

                    b.Property<string>("CatID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CatImagPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CatName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductMastersProductID")
                        .HasColumnType("int");

                    b.Property<string>("SubCatID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatMasterID");

                    b.HasIndex("ProductMastersProductID");

                    b.ToTable("CatMaster");
                });

            modelBuilder.Entity("E_mart_final_project.models.ConfigMaster", b =>
                {
                    b.Property<int>("ConfigID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConfigID"));

                    b.Property<string>("ConfigName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConfigID");

                    b.ToTable("ConfigMaster");
                });

            modelBuilder.Entity("E_mart_final_project.models.Order", b =>
                {
                    b.Property<int>("OrderTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderTID"));

                    b.Property<int?>("AddToCartsCartID")
                        .HasColumnType("int");

                    b.Property<double>("CardHolderPrice")
                        .HasColumnType("float");

                    b.Property<int>("CartID")
                        .HasColumnType("int");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<double>("GrandTotal")
                        .HasColumnType("float");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PointRedm")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductMastersProductID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersUserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderTID");

                    b.HasIndex("AddToCartsCartID");

                    b.HasIndex("ProductMastersProductID");

                    b.HasIndex("UsersUserName");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("E_mart_final_project.models.Payment", b =>
                {
                    b.Property<int>("PayID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PayID"));

                    b.Property<int>("OrderTID")
                        .HasColumnType("int");

                    b.Property<int?>("OrdersOrderTID")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersUserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PayID");

                    b.HasIndex("OrdersOrderTID");

                    b.HasIndex("UsersUserName");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("E_mart_final_project.models.ProductDtlMaster", b =>
                {
                    b.Property<int>("ProductDtlID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductDtlID"));

                    b.Property<string>("ConfigDtl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConfigID")
                        .HasColumnType("int");

                    b.Property<int?>("ConfigMastersConfigID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductMastersProductID")
                        .HasColumnType("int");

                    b.HasKey("ProductDtlID");

                    b.HasIndex("ConfigMastersConfigID");

                    b.HasIndex("ProductMastersProductID");

                    b.ToTable("ProductDtlMaster");
                });

            modelBuilder.Entity("E_mart_final_project.models.ProductMaster", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<double>("CardHolderPrice")
                        .HasColumnType("float");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("PointRedm")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductLongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("ProductMaster");
                });

            modelBuilder.Entity("E_mart_final_project.models.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardHolder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MobileNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("UserName");

                    b.ToTable("User");
                });

            modelBuilder.Entity("E_mart_final_project.models.AddToCart", b =>
                {
                    b.HasOne("E_mart_final_project.models.ProductMaster", "ProductMasters")
                        .WithMany("AddToCarts")
                        .HasForeignKey("ProductMastersProductID");

                    b.HasOne("E_mart_final_project.models.User", "Users")
                        .WithMany("AddToCarts")
                        .HasForeignKey("UsersUserName");

                    b.Navigation("ProductMasters");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("E_mart_final_project.models.CatMaster", b =>
                {
                    b.HasOne("E_mart_final_project.models.ProductMaster", "ProductMasters")
                        .WithMany("CatMasters")
                        .HasForeignKey("ProductMastersProductID");

                    b.Navigation("ProductMasters");
                });

            modelBuilder.Entity("E_mart_final_project.models.Order", b =>
                {
                    b.HasOne("E_mart_final_project.models.AddToCart", "AddToCarts")
                        .WithMany("Orders")
                        .HasForeignKey("AddToCartsCartID");

                    b.HasOne("E_mart_final_project.models.ProductMaster", "ProductMasters")
                        .WithMany("Orders")
                        .HasForeignKey("ProductMastersProductID");

                    b.HasOne("E_mart_final_project.models.User", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("UsersUserName");

                    b.Navigation("AddToCarts");

                    b.Navigation("ProductMasters");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("E_mart_final_project.models.Payment", b =>
                {
                    b.HasOne("E_mart_final_project.models.Order", "Orders")
                        .WithMany("Payments")
                        .HasForeignKey("OrdersOrderTID");

                    b.HasOne("E_mart_final_project.models.User", "Users")
                        .WithMany("Payments")
                        .HasForeignKey("UsersUserName");

                    b.Navigation("Orders");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("E_mart_final_project.models.ProductDtlMaster", b =>
                {
                    b.HasOne("E_mart_final_project.models.ConfigMaster", "ConfigMasters")
                        .WithMany("ProductDtlMasters")
                        .HasForeignKey("ConfigMastersConfigID");

                    b.HasOne("E_mart_final_project.models.ProductMaster", "ProductMasters")
                        .WithMany("ProductDtlMasters")
                        .HasForeignKey("ProductMastersProductID");

                    b.Navigation("ConfigMasters");

                    b.Navigation("ProductMasters");
                });

            modelBuilder.Entity("E_mart_final_project.models.AddToCart", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("E_mart_final_project.models.ConfigMaster", b =>
                {
                    b.Navigation("ProductDtlMasters");
                });

            modelBuilder.Entity("E_mart_final_project.models.Order", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("E_mart_final_project.models.ProductMaster", b =>
                {
                    b.Navigation("AddToCarts");

                    b.Navigation("CatMasters");

                    b.Navigation("Orders");

                    b.Navigation("ProductDtlMasters");
                });

            modelBuilder.Entity("E_mart_final_project.models.User", b =>
                {
                    b.Navigation("AddToCarts");

                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
