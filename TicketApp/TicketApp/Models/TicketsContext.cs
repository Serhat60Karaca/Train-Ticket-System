using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TicketApp.Models
{
    public partial class TicketsContext : DbContext
    {
        public TicketsContext()
        {
        }

        public TicketsContext(DbContextOptions<TicketsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Passenger> Passengers { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Station> Stations { get; set; } = null!;
        public virtual DbSet<Train> Trains { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Tickets;Username=postgres;Password=*****************");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.Property(e => e.ClassId)
                    .HasColumnName("class_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("passengers");

                entity.Property(e => e.PassengerId)
                    .HasColumnName("passenger_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BirthDate).HasColumnName("birthDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservations");

                entity.Property(e => e.ReservationId)
                    .ValueGeneratedNever()
                    .HasColumnName("reservation_id");

                entity.Property(e => e.NumTickets).HasColumnName("num_tickets");

                entity.Property(e => e.PassengerId).HasColumnName("passenger_id");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.PassengerId)
                    .HasConstraintName("reservation_passengerFK");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("reservation_scheduleFK");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("routes");

                entity.Property(e => e.RouteId)
                    .ValueGeneratedNever()
                    .HasColumnName("route_id");

                entity.Property(e => e.DestinationId).HasColumnName("destination_id");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.OriginId).HasColumnName("origin_id");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.RouteDestinations)
                    .HasForeignKey(d => d.DestinationId)
                    .HasConstraintName("routes_destionationFK");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.RouteOrigins)
                    .HasForeignKey(d => d.OriginId)
                    .HasConstraintName("routes_originFK");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedules");

                entity.Property(e => e.ScheduleId)
                    .ValueGeneratedNever()
                    .HasColumnName("schedule_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.DepartureTime).HasColumnName("departure_time");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.TrainId).HasColumnName("train_id");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_classFK");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedules_routeFK");

                entity.HasOne(d => d.Train)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.TrainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedules_trainFK");

                entity.HasMany(d => d.Classes)
                    .WithMany(p => p.SchedulesNavigation)
                    .UsingEntity<Dictionary<string, object>>(
                        "ScheduleClass",
                        l => l.HasOne<Class>().WithMany().HasForeignKey("ClassId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("class_FK"),
                        r => r.HasOne<Schedule>().WithMany().HasForeignKey("ScheduleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("schedule_FK"),
                        j =>
                        {
                            j.HasKey("ScheduleId", "ClassId").HasName("schedule_class_PK");

                            j.ToTable("schedule_class");

                            j.IndexerProperty<int>("ScheduleId").HasColumnName("schedule_id");

                            j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                        });
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("stations");

                entity.Property(e => e.StationId)
                    .ValueGeneratedNever()
                    .HasColumnName("station_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.ToTable("train");

                entity.Property(e => e.TrainId)
                    .ValueGeneratedNever()
                    .HasColumnName("train_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
