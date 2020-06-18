﻿// <auto-generated />
using System;
using EKomplet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EKomplet.Migrations
{
    [DbContext(typeof(DistrictDBContext))]
    partial class DistrictDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EKomplet.Models.Business", b =>
                {
                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DistrictName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistrictName1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("BusinessName", "DistrictName");

                    b.HasIndex("DistrictName1");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("EKomplet.Models.District", b =>
                {
                    b.Property<string>("DistrictName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PrimarySalesman")
                        .HasColumnType("int");

                    b.Property<int?>("SalesmanPhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("DistrictName");

                    b.HasIndex("SalesmanPhoneNumber");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("EKomplet.Models.Salesman", b =>
                {
                    b.Property<int>("PhoneNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PhoneNumber");

                    b.ToTable("Salesmen");
                });

            modelBuilder.Entity("EKomplet.Models.SecondarySalesmen", b =>
                {
                    b.Property<string>("DistrictName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("DistrictName1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("SalesmanPhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("DistrictName", "PhoneNumber");

                    b.HasIndex("DistrictName1");

                    b.HasIndex("SalesmanPhoneNumber");

                    b.ToTable("SecondarySalesmens");
                });

            modelBuilder.Entity("EKomplet.Models.Business", b =>
                {
                    b.HasOne("EKomplet.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictName1");
                });

            modelBuilder.Entity("EKomplet.Models.District", b =>
                {
                    b.HasOne("EKomplet.Models.Salesman", "Salesman")
                        .WithMany()
                        .HasForeignKey("SalesmanPhoneNumber");
                });

            modelBuilder.Entity("EKomplet.Models.SecondarySalesmen", b =>
                {
                    b.HasOne("EKomplet.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictName1");

                    b.HasOne("EKomplet.Models.Salesman", "Salesman")
                        .WithMany()
                        .HasForeignKey("SalesmanPhoneNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
