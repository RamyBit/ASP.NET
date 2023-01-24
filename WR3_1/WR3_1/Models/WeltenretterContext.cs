using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WR3_1.Models
{
    public partial class WeltenretterContext : DbContext
    {
        public WeltenretterContext()
        {
        }

        public WeltenretterContext(DbContextOptions<WeltenretterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aggressor> Aggressor { get; set; }
        public virtual DbSet<Bedrohung> Bedrohung { get; set; }
        public virtual DbSet<Held> Held { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Weltenretter;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aggressor>(entity =>
            {
                entity.Property(e => e.AggressorId)
                    .HasColumnName("aggressor_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Spezialitaet)
                    .IsRequired()
                    .HasColumnName("spezialitaet")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Bedrohung>(entity =>
            {
                entity.Property(e => e.BedrohungId)
                    .HasColumnName("bedrohung_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AggressorId).HasColumnName("aggressor_id");

                entity.Property(e => e.Akut).HasColumnName("akut");

                entity.Property(e => e.HeldId).HasColumnName("held_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Aggressor)
                    .WithMany(p => p.Bedrohung)
                    .HasForeignKey(d => d.AggressorId)
                    .HasConstraintName("fk_bedrohung_aggressor");

                entity.HasOne(d => d.Held)
                    .WithMany(p => p.Bedrohung)
                    .HasForeignKey(d => d.HeldId)
                    .HasConstraintName("fk_bedrohung_held");
            });

            modelBuilder.Entity<Held>(entity =>
            {
                entity.Property(e => e.HeldId)
                    .HasColumnName("held_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Beruf)
                    .IsRequired()
                    .HasColumnName("beruf")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
