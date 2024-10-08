﻿using ApartmentReservationWeb.Models.ApartmentModel;
using ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel;
using ApartmentReservationWeb.Models.UserModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApartmentReservationWeb.DB
{
    public class OccupancyContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ApartmentInfo> Apartments { get; set; }
        public DbSet<Occupancy> Occupancies { get; set; }
        public DbSet<ReservationDate> ReservationDates { get; set; }

        public OccupancyContext(DbContextOptions optBuilder) 
            : base(optBuilder) 
        { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(x => x.Id);

                entity.HasMany(x => x.Apartments)
                    .WithOne(x => x.Owner)
                    .HasForeignKey(x => x.OwnerId);
            });

            modelBuilder.Entity<ApartmentInfo>(entity =>
            {
                entity.ToTable("ApartmentsInfo");
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Occupancy>(entity =>
            {
                entity.ToTable("Occupancies");
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Apartment)
                    .WithMany(x => x.Occupancies)
                    .HasForeignKey(x => x.ApartmentId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.ReservedBy)
                    .WithMany(x => x.Occupancies)
                    .HasForeignKey(x => x.ReservedById)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.State)
                    .WithMany(x => x.Occupancies)
                    .HasForeignKey(x => x.OccupancyStateId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.Review)
                    .WithOne(x => x.Occupancy)
                    .HasForeignKey<Occupancy>(x => x.ReviewId);
            });

            modelBuilder.Entity<ReservationDate>(entity =>
            {
                entity.ToTable("ReservationDates");
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Apartment)
                    .WithMany(x => x.Dates)
                    .HasForeignKey(x => x.ApartmentId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.Occupancy)
                    .WithMany(x => x.Dates)
                    .HasForeignKey(x => x.OccupancyId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
