using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class Pirat_Vertreter_Besuch_ASPContext : DbContext
    {
        public Pirat_Vertreter_Besuch_ASPContext()
        {
        }

        public Pirat_Vertreter_Besuch_ASPContext(DbContextOptions<Pirat_Vertreter_Besuch_ASPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Besuch> Besuches { get; set; } = null!;
        public virtual DbSet<Consultant> Consultants { get; set; } = null!;
        public virtual DbSet<Gebiet> Gebiets { get; set; } = null!;
        public virtual DbSet<Kunde> Kundes { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Pirat_Vertreter_Besuch_ASP;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Besuch>(entity =>
            {
                entity.ToTable("Besuch");

                entity.Property(e => e.BesuchId)
                    .ValueGeneratedNever()
                    .HasColumnName("besuch_id");

                entity.Property(e => e.Beschreibung)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("beschreibung")
                    .IsFixedLength();

                entity.Property(e => e.ConsultantId).HasColumnName("consultant_id");

                entity.Property(e => e.Datum)
                    .HasColumnType("date")
                    .HasColumnName("datum");

                entity.Property(e => e.KundeId).HasColumnName("kunde_id");

                entity.HasOne(d => d.Consultant)
                    .WithMany(p => p.Besuches)
                    .HasForeignKey(d => d.ConsultantId)
                    .HasConstraintName("fk_besuch_consultant");

                entity.HasOne(d => d.Kunde)
                    .WithMany(p => p.Besuches)
                    .HasForeignKey(d => d.KundeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_besuch_kunde");
            });

            modelBuilder.Entity<Consultant>(entity =>
            {
                entity.ToTable("Consultant");

                entity.HasIndex(e => e.GebietId, "UQ__Consulta__E2222AE3E16943E2")
                    .IsUnique();

                entity.Property(e => e.ConsultantId)
                    .ValueGeneratedNever()
                    .HasColumnName("consultant_id");

                entity.Property(e => e.GebietId).HasColumnName("gebiet_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength();

                entity.HasOne(d => d.Gebiet)
                    .WithOne(p => p.Consultant)
                    .HasForeignKey<Consultant>(d => d.GebietId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_consultant_gebiet");
            });

            modelBuilder.Entity<Gebiet>(entity =>
            {
                entity.ToTable("Gebiet");

                entity.Property(e => e.GebietId)
                    .ValueGeneratedNever()
                    .HasColumnName("gebiet_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.ToTable("Kunde");

                entity.Property(e => e.KundeId)
                    .ValueGeneratedNever()
                    .HasColumnName("kunde_id");

                entity.Property(e => e.Hausnummer)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("hausnummer")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength();

                entity.Property(e => e.Plz)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("plz")
                    .IsFixedLength();

                entity.Property(e => e.Stadt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("stadt")
                    .IsFixedLength();

                entity.Property(e => e.Stammkd).HasColumnName("stammkd");

                entity.Property(e => e.Strasse)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("strasse")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
