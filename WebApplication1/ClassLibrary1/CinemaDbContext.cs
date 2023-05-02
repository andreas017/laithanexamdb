using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Training.Sql.Entity.Entity;

namespace Training.Sql.Entity
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }
        public DbSet<Cinema> Cinemas => Set<Cinema>();
        public DbSet<Theatre> Theatres => Set<Theatre>();
        public DbSet<TheatreType> TheatreTypes => Set<TheatreType>();
        public DbSet<Blob> Blobs => Set<Blob>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Blob>(entity =>
            {
                entity.HasKey(e => e.BlobId)
                .HasName("blob_pkey");
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("cinema_pkey");
                entity.HasMany<Theatre>(e => e.Theatres)
                .WithOne(e => e.Cinema).HasConstraintName("t__theatre_fkey").IsRequired();

                entity.HasOne(e => e.Blob)
                .WithMany(e => e.Cinemas)
                .HasForeignKey(e => e.BlobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("u__blob_fkey");
            });


            modelBuilder.Entity<Theatre>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("theatre_pkey");

                entity.HasOne<TheatreType>(e => e.TheatreType)
                .WithMany(e => e.Theatres)
                .HasForeignKey(e => e.TheatreTypeId)
                .HasConstraintName("t__theatreType_fkey").IsRequired();

                entity.HasOne(e => e.Cinema)
                .WithMany(e => e.Theatres)
                .HasForeignKey(e => e.CinemaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("t__cinema_fkey").IsRequired();
            });

            var type1 = new TheatreType
            {
                Id = 1,
                Name = "Reguler"
            };
            var type2 = new TheatreType
            {
                Id = 2,
                Name = "Premium"
            };

            modelBuilder.Entity<TheatreType>().HasData(type1, type2);
        }
    }
}
