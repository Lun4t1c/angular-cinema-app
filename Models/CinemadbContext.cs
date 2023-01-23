using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cinema_warmup_app.Models;

public partial class CinemadbContext : DbContext
{
    public CinemadbContext()
    {
    }

    public CinemadbContext(DbContextOptions<CinemadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CinemaHall> CinemaHalls { get; set; }

    public virtual DbSet<MovieShowing> MovieShowings { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=cinemadb;Username=postgres;Password=admin;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CinemaHall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CinemaHalls_pkey");

            entity.HasIndex(e => e.Code, "CinemaHalls_Code_key").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(4);
        });

        modelBuilder.Entity<MovieShowing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MovieShowings_pkey");

            entity.Property(e => e.BeginDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.CinemaHall).WithMany(p => p.MovieShowings)
                .HasForeignKey(d => d.IdCinemaHall)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cinema_hall");
        });

        // modelBuilder.Entity<Reservation>(entity =>
        // {
        //     entity.HasKey(e => e.Id).HasName("Reservations_pkey");
        //
        //     // entity.HasOne(d => d.MovieShowing).WithMany(p => p.Reservations)
        //     //     .HasForeignKey(d => d.IdMovieShowing)
        //     //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     //     .HasConstraintName("fk_movie_showing");
        //
        //     entity.HasOne(d => d.User).WithMany(p => p.Reservations)
        //         .HasForeignKey(d => d.IdUser)
        //         .OnDelete(DeleteBehavior.ClientSetNull)
        //         .HasConstraintName("fk_user");
        //
        //     entity.HasMany(d => d.Seats).WithMany(p => p.IdReservations)
        //         .UsingEntity<Dictionary<string, object>>(
        //             "ReservationSeat",
        //             r => r.HasOne<Seat>().WithMany()
        //                 .HasForeignKey("IdSeat")
        //                 .OnDelete(DeleteBehavior.ClientSetNull)
        //                 .HasConstraintName("fk_seat"),
        //             l => l.HasOne<Reservation>().WithMany()
        //                 .HasForeignKey("IdReservation")
        //                 .OnDelete(DeleteBehavior.ClientSetNull)
        //                 .HasConstraintName("fk_reservation"),
        //             j =>
        //             {
        //                 j.HasKey("IdReservation", "IdSeat").HasName("ReservationSeats_pkey");
        //             });
        // });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Seats_pkey");

            entity.HasIndex(e => e.Code, "Seats_Code_key").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(4);

            entity.HasOne(d => d.CinemaHall).WithMany(p => p.Seats)
                .HasForeignKey(d => d.IdCinemaHall)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cinema_hall");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.HasIndex(e => e.Email, "Users_Email_key").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
