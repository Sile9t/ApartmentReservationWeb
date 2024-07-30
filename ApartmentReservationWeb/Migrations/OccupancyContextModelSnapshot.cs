﻿// <auto-generated />
using System;
using ApartmentReservationWeb.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApartmentReservationWeb.Migrations
{
    [DbContext(typeof(OccupancyContext))]
    partial class OccupancyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.ApartFacilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("ApartFacilities");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.ApartFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApartFacilitiesId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApartFacilitiesId");

                    b.ToTable("ApartFacility");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.ApartmentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BedsCount")
                        .HasColumnType("int");

                    b.Property<double>("CapacitySquare")
                        .HasColumnType("float");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FacilitiesInfoId")
                        .HasColumnType("int");

                    b.Property<int>("GuestsCount")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Photos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("RoomsCount")
                        .HasColumnType("int");

                    b.Property<int?>("RuleId")
                        .HasColumnType("int");

                    b.Property<int?>("RulesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacilitiesInfoId");

                    b.HasIndex("HotelId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RuleId");

                    b.ToTable("ApartmentsInfo", (string)null);
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.ApartmentRules", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CancelCondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("FromTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("TillTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("ApartmentRules");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.HotelInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BuildingDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoomsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HotelInfo");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel.Occupancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("EvictionDate")
                        .HasColumnType("date");

                    b.Property<int>("GuestesCount")
                        .HasColumnType("int");

                    b.Property<DateOnly>("OccupancyDate")
                        .HasColumnType("date");

                    b.Property<int>("OccupancyStateId")
                        .HasColumnType("int");

                    b.Property<int>("ReservedById")
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("OccupancyStateId");

                    b.HasIndex("ReservedById");

                    b.HasIndex("ReviewId")
                        .IsUnique();

                    b.ToTable("Occupancies", (string)null);
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel.OccupancyState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OccupancyState");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.ReservationDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<double>("ExtraCharge")
                        .HasColumnType("float");

                    b.Property<int>("OccupancyId")
                        .HasColumnType("int");

                    b.Property<int>("ReservedById")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("OccupancyId");

                    b.HasIndex("ReservedById");

                    b.HasIndex("StateId");

                    b.ToTable("ReservationDates", (string)null);
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ApartmentInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OccupancyId")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentInfoId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.Rules", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApartmentRulesId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentRulesId");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.UserModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApartmentRulesId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Languages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentRulesId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.ApartFacility", b =>
                {
                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.ApartFacilities", null)
                        .WithMany("FacilitiesList")
                        .HasForeignKey("ApartFacilitiesId");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.ApartmentInfo", b =>
                {
                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.ApartFacilities", "FacilitiesInfo")
                        .WithMany()
                        .HasForeignKey("FacilitiesInfoId");

                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.HotelInfo", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId");

                    b.HasOne("ApartmentReservationWeb.Models.UserModel.User", "Owner")
                        .WithMany("Apartments")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.ApartmentRules", "Rule")
                        .WithMany()
                        .HasForeignKey("RuleId");

                    b.Navigation("FacilitiesInfo");

                    b.Navigation("Hotel");

                    b.Navigation("Owner");

                    b.Navigation("Rule");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel.Occupancy", b =>
                {
                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.ApartmentInfo", "Apartment")
                        .WithMany("Occupancies")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel.OccupancyState", "State")
                        .WithMany("Occupancies")
                        .HasForeignKey("OccupancyStateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApartmentReservationWeb.Models.UserModel.User", "ReservedBy")
                        .WithMany("Occupancies")
                        .HasForeignKey("ReservedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.Review", "Review")
                        .WithOne("Occupancy")
                        .HasForeignKey("ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel.Occupancy", "ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("ReservedBy");

                    b.Navigation("Review");

                    b.Navigation("State");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.ReservationDate", b =>
                {
                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.ApartmentInfo", "Apartment")
                        .WithMany("Dates")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel.Occupancy", "Occupancy")
                        .WithMany("Dates")
                        .HasForeignKey("OccupancyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApartmentReservationWeb.Models.UserModel.User", "ReservedBy")
                        .WithMany()
                        .HasForeignKey("ReservedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel.OccupancyState", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("Occupancy");

                    b.Navigation("ReservedBy");

                    b.Navigation("State");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.Review", b =>
                {
                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.ApartmentInfo", null)
                        .WithMany("Reviews")
                        .HasForeignKey("ApartmentInfoId");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.Rules", b =>
                {
                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.ApartmentRules", null)
                        .WithMany("RulesList")
                        .HasForeignKey("ApartmentRulesId");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.UserModel.User", b =>
                {
                    b.HasOne("ApartmentReservationWeb.Models.ApartmentModel.ApartmentRules", "Rules")
                        .WithMany()
                        .HasForeignKey("ApartmentRulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rules");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.ApartFacilities", b =>
                {
                    b.Navigation("FacilitiesList");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.ApartmentInfo", b =>
                {
                    b.Navigation("Dates");

                    b.Navigation("Occupancies");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.ApartmentRules", b =>
                {
                    b.Navigation("RulesList");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel.Occupancy", b =>
                {
                    b.Navigation("Dates");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel.OccupancyState", b =>
                {
                    b.Navigation("Occupancies");
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.ApartmentModel.Review", b =>
                {
                    b.Navigation("Occupancy")
                        .IsRequired();
                });

            modelBuilder.Entity("ApartmentReservationWeb.Models.UserModel.User", b =>
                {
                    b.Navigation("Apartments");

                    b.Navigation("Occupancies");
                });
#pragma warning restore 612, 618
        }
    }
}
