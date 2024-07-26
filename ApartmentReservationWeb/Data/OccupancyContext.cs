using ApartmentReservationWeb.Models.ApartmentModel;
using ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel;
using ApartmentReservationWeb.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace ApartmentReservationWeb.DB
{
    public class OccupancyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ApartmentInfo> Apartments { get; set; }
        public DbSet<Occupancy> Occupancies { get; set; }
        public DbSet<ReservationDate> ReservationDates { get; set; }

        public OccupancyContext(DbContextOptions<OccupancyContext> optBuilder) 
            : base(optBuilder) 
        { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    .HasForeignKey(x => x.ApartmentId);
            });

            modelBuilder.Entity<ReservationDate>(entity =>
            {
                entity.ToTable("ReservationDates");
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Apartment)
                    .WithMany(x => x.Dates)
                    .HasForeignKey(x => x.ApartmentId);
                entity.HasOne(x => x.Occupancy)
                    .WithMany(x => x.Dates)
                    .HasForeignKey(x => x.OccupancyId);
            });
        }
    }
}
