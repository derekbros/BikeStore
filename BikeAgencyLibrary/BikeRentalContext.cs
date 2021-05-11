using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BikeAgencyLibrary
{
    public partial class BikeRentalContext : DbContext
    {
        public BikeRentalContext()
        {
        }

        public BikeRentalContext(DbContextOptions<BikeRentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<BikeType> BikeTypes { get; set; }
        public virtual DbSet<BikesInShop> BikesInShops { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<RentalDetail> RentalDetails { get; set; }
        public virtual DbSet<RentalRate> RentalRates { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<SpecialFeature> SpecialFeatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BikeRental;MultipleActiveResultSets=true;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bike>(entity =>
            {
                entity.Property(e => e.BikeId)
                    .ValueGeneratedNever()
                    .HasColumnName("BikeID");

                entity.Property(e => e.FeatureId).HasColumnName("FeatureID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RateId).HasColumnName("RateID");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.Bikes)
                    .HasForeignKey(d => d.FeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bikes_SpecialFeatures");

                entity.HasOne(d => d.Rate)
                    .WithMany(p => p.Bikes)
                    .HasForeignKey(d => d.RateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bikes_RentalRates");
            });

            modelBuilder.Entity<BikeType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BikeType");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type)
                    .WithMany()
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BikeType_Bikes");
            });

            modelBuilder.Entity<BikesInShop>(entity =>
            {
                entity.HasKey(e => e.ShopId);

                entity.ToTable("BikesInShop");

                entity.Property(e => e.ShopId)
                    .ValueGeneratedNever()
                    .HasColumnName("ShopID");

                entity.Property(e => e.BikeId).HasColumnName("BikeID");

                entity.Property(e => e.DateTimeIn)
                    .HasColumnType("datetime")
                    .HasColumnName("DateTime_In");

                entity.Property(e => e.DateTimeOut)
                    .HasColumnType("datetime")
                    .HasColumnName("DateTime_Out");

                entity.Property(e => e.OtherDetails)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Bike)
                    .WithMany(p => p.BikesInShops)
                    .HasForeignKey(d => d.BikeId)
                    .HasConstraintName("FK_BikesInShop_Bikes");

                entity.HasOne(d => d.Shop)
                    .WithOne(p => p.BikesInShop)
                    .HasForeignKey<BikesInShop>(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BikesInShop_Shops");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.Property(e => e.CustId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("LName");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Shops");
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.HasKey(e => e.PaymentStatusCode);

                entity.ToTable("PaymentStatus");

                entity.Property(e => e.PaymentStatusCode).ValueGeneratedNever();

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PaymentStatusDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.Property(e => e.RentalId)
                    .ValueGeneratedNever()
                    .HasColumnName("RentalID");

                entity.Property(e => e.ActualEndDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Actual_End_DateTime");

                entity.Property(e => e.ActualStartDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Actual_Start_DateTime");

                entity.Property(e => e.BikeId).HasColumnName("BikeID");

                entity.Property(e => e.BookedEndDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Booked_End_DateTime");

                entity.Property(e => e.BookedStartDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Booked_Start_DateTime");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.OtherDetails).HasMaxLength(50);

                entity.Property(e => e.RateId).HasColumnName("RateID");

                entity.Property(e => e.RentalPaymentDue)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("Rental_Payment_Due");

                entity.Property(e => e.RentalPaymentMade)
                    .HasMaxLength(3)
                    .HasColumnName("Rental_Payment_Made")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Bike)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.BikeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentals_Bikes");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentals_Customers");

                entity.HasOne(d => d.PaymentStatusCodeNavigation)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.PaymentStatusCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentals_PaymentStatus");
            });

            modelBuilder.Entity<RentalDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BikeId).HasColumnName("BikeID");

                entity.Property(e => e.RateId).HasColumnName("RateID");

                entity.Property(e => e.RentalId).HasColumnName("RentalID");

                entity.HasOne(d => d.Bike)
                    .WithMany()
                    .HasForeignKey(d => d.BikeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentalDetails_Bikes");

                entity.HasOne(d => d.Rate)
                    .WithMany()
                    .HasForeignKey(d => d.RateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentalDetails_RentalRates");

                entity.HasOne(d => d.Rental)
                    .WithMany()
                    .HasForeignKey(d => d.RentalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentalDetails_Rentals");
            });

            modelBuilder.Entity<RentalRate>(entity =>
            {
                entity.HasKey(e => e.RateId);

                entity.Property(e => e.RateId)
                    .ValueGeneratedNever()
                    .HasColumnName("RateID");

                entity.Property(e => e.DailyRate).HasColumnType("money");

                entity.Property(e => e.HourlyRate).HasColumnType("money");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.ShopId)
                    .ValueGeneratedNever()
                    .HasColumnName("ShopID");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SpecialFeature>(entity =>
            {
                entity.HasKey(e => e.FeatureId);

                entity.Property(e => e.FeatureId)
                    .ValueGeneratedNever()
                    .HasColumnName("FeatureID");

                entity.Property(e => e.AllTerrain).HasColumnName("All_Terrain");

                entity.Property(e => e.ChildSeat).HasColumnName("Child_Seat");

                entity.Property(e => e.Color).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
