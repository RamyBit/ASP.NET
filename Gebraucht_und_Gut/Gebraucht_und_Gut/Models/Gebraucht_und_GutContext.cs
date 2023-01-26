using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gebraucht_und_Gut.Models
{
    public partial class Gebraucht_und_GutContext : DbContext
    {
        public Gebraucht_und_GutContext()
        {
        }

        public Gebraucht_und_GutContext(DbContextOptions<Gebraucht_und_GutContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fahrzeug> Fahrzeugs { get; set; } = null!;
        public virtual DbSet<Kunde> Kundes { get; set; } = null!;
        public virtual DbSet<Rechnung> Rechnungs { get; set; } = null!;
        public virtual DbSet<Verkaeufer> Verkaeufers { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Gebraucht_und_Gut;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fahrzeug>(entity =>
            {
                entity.HasKey(e => e.FzId)
                    .HasName("pk_fahrzeug");

                entity.ToTable("Fahrzeug");

                entity.Property(e => e.FzId)
                    .ValueGeneratedNever()
                    .HasColumnName("fz_id");

                entity.Property(e => e.Marke)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("marke")
                    .IsFixedLength();

                entity.Property(e => e.Preis)
                    .HasColumnType("money")
                    .HasColumnName("preis");

                entity.Property(e => e.ReId).HasColumnName("re_id");

                entity.Property(e => e.Typ)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("typ")
                    .IsFixedLength();

                entity.HasOne(d => d.Re)
                    .WithMany(p => p.Fahrzeugs)
                    .HasForeignKey(d => d.ReId)
                    .HasConstraintName("fk_fahrzeug_rechnung");
            });

            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.ToTable("Kunde");

                entity.Property(e => e.KundeId)
                    .ValueGeneratedNever()
                    .HasColumnName("kunde_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength();

                entity.Property(e => e.Vorname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vorname")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Rechnung>(entity =>
            {
                entity.HasKey(e => e.ReId)
                    .HasName("pk_rechnung");

                entity.ToTable("Rechnung");

                entity.Property(e => e.ReId)
                    .ValueGeneratedNever()
                    .HasColumnName("re_id");

                entity.Property(e => e.Datum)
                    .HasColumnType("date")
                    .HasColumnName("datum");

                entity.Property(e => e.KundeId).HasColumnName("kunde_id");

                entity.Property(e => e.VerkaeuferId).HasColumnName("verkaeufer_id");

                entity.HasOne(d => d.Kunde)
                    .WithMany(p => p.Rechnungs)
                    .HasForeignKey(d => d.KundeId)
                    .HasConstraintName("fk_rechnung_kunde");

                entity.HasOne(d => d.Verkaeufer)
                    .WithMany(p => p.Rechnungs)
                    .HasForeignKey(d => d.VerkaeuferId)
                    .HasConstraintName("fk_rechnung_Verkaeufer");
            });

            modelBuilder.Entity<Verkaeufer>(entity =>
            {
                entity.ToTable("Verkaeufer");

                entity.Property(e => e.VerkaeuferId)
                    .ValueGeneratedNever()
                    .HasColumnName("verkaeufer_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
