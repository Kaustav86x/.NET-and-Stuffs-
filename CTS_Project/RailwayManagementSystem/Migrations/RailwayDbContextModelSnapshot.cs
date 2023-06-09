﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailwayManagementSystem.Data;

#nullable disable

namespace RailwayManagementSystem.Migrations
{
    [DbContext(typeof(RailwayDbContext))]
    partial class RailwayDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Class_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fare")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Class_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment_method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payment_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("User_id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Reservation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Class_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Passenger")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Payment_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Train_id")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Class_id");

                    b.HasIndex("Payment_id");

                    b.HasIndex("Train_id");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Role_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Ticket_detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Class_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Passenger")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seat_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Train_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TicketDetails");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Train_detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Arr_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Class_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dept_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Train_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("TrainDetails");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<string>("Role_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Role_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Payment", b =>
                {
                    b.HasOne("RailwayManagementSystem.Models.DbModels.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("RailwayManagementSystem.Models.DbModels.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Reservation", b =>
                {
                    b.HasOne("RailwayManagementSystem.Models.DbModels.Class", "Class")
                        .WithMany("Reservations")
                        .HasForeignKey("Class_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayManagementSystem.Models.DbModels.Payment", "Payment")
                        .WithMany("Reservations")
                        .HasForeignKey("Payment_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayManagementSystem.Models.DbModels.Train_detail", "Train_detail")
                        .WithMany("Reservations")
                        .HasForeignKey("Train_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayManagementSystem.Models.DbModels.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId");

                    b.Navigation("Class");

                    b.Navigation("Payment");

                    b.Navigation("Train_detail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Ticket_detail", b =>
                {
                    b.HasOne("RailwayManagementSystem.Models.DbModels.User", "User")
                        .WithMany("Ticket_Details")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Train_detail", b =>
                {
                    b.HasOne("RailwayManagementSystem.Models.DbModels.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.User", b =>
                {
                    b.HasOne("RailwayManagementSystem.Models.DbModels.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("Role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Class", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Payment", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.Train_detail", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RailwayManagementSystem.Models.DbModels.User", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Reservations");

                    b.Navigation("Ticket_Details");
                });
#pragma warning restore 612, 618
        }
    }
}
