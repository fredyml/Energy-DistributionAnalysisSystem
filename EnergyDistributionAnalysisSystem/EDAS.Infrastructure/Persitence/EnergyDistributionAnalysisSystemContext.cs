using EDAS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EDAS.Infrastructure.Persitence
{
    public partial class EnergyDistributionAnalysisSystemContext : DbContext
    {
        public EnergyDistributionAnalysisSystemContext()
        {
        }

        public EnergyDistributionAnalysisSystemContext(DbContextOptions<EnergyDistributionAnalysisSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consumo> Consumos { get; set; } = null!;
        public virtual DbSet<Costo> Costos { get; set; } = null!;
        public virtual DbSet<Fecha> Fechas { get; set; } = null!;
        public virtual DbSet<Perdidum> Perdida { get; set; } = null!;
        public virtual DbSet<Tramo> Tramos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer(string.Empty);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consumo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Consumo");

                entity.Property(e => e.Comercial).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FechaId).HasColumnName("FechaID");

                entity.Property(e => e.Industrial).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Residencial).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TramoId).HasColumnName("TramoID");

                entity.HasOne(d => d.Fecha)
                    .WithMany()
                    .HasForeignKey(d => d.FechaId)
                    .HasConstraintName("FK__Consumo__FechaID__286302EC");

                entity.HasOne(d => d.Tramo)
                    .WithMany()
                    .HasForeignKey(d => d.TramoId)
                    .HasConstraintName("FK__Consumo__TramoID__276EDEB3");
            });

            modelBuilder.Entity<Costo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Costo");

                entity.Property(e => e.Comercial).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FechaId).HasColumnName("FechaID");

                entity.Property(e => e.Industrial).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Residencial).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TramoId).HasColumnName("TramoID");

                entity.HasOne(d => d.Fecha)
                    .WithMany()
                    .HasForeignKey(d => d.FechaId)
                    .HasConstraintName("FK__Costo__FechaID__2B3F6F97");

                entity.HasOne(d => d.Tramo)
                    .WithMany()
                    .HasForeignKey(d => d.TramoId)
                    .HasConstraintName("FK__Costo__TramoID__2A4B4B5E");
            });

            modelBuilder.Entity<Fecha>(entity =>
            {
                entity.ToTable("Fecha");

                entity.Property(e => e.FechaId)
                    .ValueGeneratedNever()
                    .HasColumnName("FechaID");

                entity.Property(e => e.Fecha1)
                    .HasColumnType("date")
                    .HasColumnName("Fecha");
            });

            modelBuilder.Entity<Perdidum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Comercial).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FechaId).HasColumnName("FechaID");

                entity.Property(e => e.Industrial).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Residencial).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TramoId).HasColumnName("TramoID");

                entity.HasOne(d => d.Fecha)
                    .WithMany()
                    .HasForeignKey(d => d.FechaId)
                    .HasConstraintName("FK__Perdida__FechaID__2E1BDC42");

                entity.HasOne(d => d.Tramo)
                    .WithMany()
                    .HasForeignKey(d => d.TramoId)
                    .HasConstraintName("FK__Perdida__TramoID__2D27B809");
            });

            modelBuilder.Entity<Tramo>(entity =>
            {
                entity.ToTable("Tramo");

                entity.Property(e => e.TramoId)
                    .ValueGeneratedNever()
                    .HasColumnName("TramoID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
