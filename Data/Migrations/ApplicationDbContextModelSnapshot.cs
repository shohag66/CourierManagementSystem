﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourierManagementSystem.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourierManagementSystem.Entity.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("CourierManagementSystem.Entity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int?>("isActive")
                        .HasColumnType("int");

                    b.Property<string>("org")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int?>("userTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CourierManagementSystem.Entity.MasterData.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConsignmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Consignmentstatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EstimatedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OrderPlacedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("isActive")
                        .HasColumnType("int");

                    b.Property<int?>("isDelete")
                        .HasColumnType("int");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CourierManagementSystem.Entity.MasterData.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("customerId")
                        .HasColumnType("int");

                    b.Property<decimal?>("deliveryCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("dueAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("heaight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("isDelete")
                        .HasColumnType("int");

                    b.Property<decimal?>("itemQty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("pickupBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("processedBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("unitRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal?>("weaight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("customerId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("CourierManagementSystem.Entity.MasterData.ShipTracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ConsigmentStatus")
                        .HasColumnType("int");

                    b.Property<string>("ConsignmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EditDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("customerId")
                        .HasColumnType("int");

                    b.Property<int?>("isDelete")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("customerId");

                    b.ToTable("ShipTrackings");
                });

            modelBuilder.Entity("CourierManagementSystem.Entity.UserLogHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("browserName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ipAddress")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("isDelete")
                        .HasColumnType("int");

                    b.Property<DateTime>("logTime")
                        .HasMaxLength(250)
                        .HasColumnType("datetime2");

                    b.Property<string>("pcName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("updatedBy")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("userId")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("UserLogHistories");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CourierManagementSystem.Entity.MasterData.Customer", b =>
                {
                    b.HasOne("CourierManagementSystem.Entity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("CourierManagementSystem.Entity.MasterData.OrderDetails", b =>
                {
                    b.HasOne("CourierManagementSystem.Entity.MasterData.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customerId");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("CourierManagementSystem.Entity.MasterData.ShipTracking", b =>
                {
                    b.HasOne("CourierManagementSystem.Entity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CourierManagementSystem.Entity.MasterData.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customerId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("CourierManagementSystem.Entity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CourierManagementSystem.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CourierManagementSystem.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("CourierManagementSystem.Entity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourierManagementSystem.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CourierManagementSystem.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
