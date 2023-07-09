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
        public virtual DbSet<Linea> Lineas { get; set; } = null!;
        public virtual DbSet<Perdidum> Perdida { get; set; } = null!;
        public virtual DbSet<Sector> Sectors { get; set; } = null!;

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
                entity.HasKey(e => new { e.LineaId, e.FechaId, e.SectorId })
                    .HasName("PK__Consumo__0E36D85CD4AAAFD0");

                entity.ToTable("Consumo");

                entity.Property(e => e.LineaId).HasColumnName("linea_id");

                entity.Property(e => e.FechaId).HasColumnName("fecha_id");

                entity.Property(e => e.SectorId).HasColumnName("sector_id");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.Fecha)
                    .WithMany(p => p.Consumos)
                    .HasForeignKey(d => d.FechaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consumo__fecha_i__49C3F6B7");

                entity.HasOne(d => d.Linea)
                    .WithMany(p => p.Consumos)
                    .HasForeignKey(d => d.LineaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consumo__linea_i__48CFD27E");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Consumos)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consumo__sector___4AB81AF0");
            });

            modelBuilder.Entity<Costo>(entity =>
            {
                entity.HasKey(e => new { e.LineaId, e.FechaId, e.SectorId })
                    .HasName("PK__Costo__0E36D85CD5EDB411");

                entity.ToTable("Costo");

                entity.Property(e => e.LineaId).HasColumnName("linea_id");

                entity.Property(e => e.FechaId).HasColumnName("fecha_id");

                entity.Property(e => e.SectorId).HasColumnName("sector_id");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.Fecha)
                    .WithMany(p => p.Costos)
                    .HasForeignKey(d => d.FechaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Costo__fecha_id__4E88ABD4");

                entity.HasOne(d => d.Linea)
                    .WithMany(p => p.Costos)
                    .HasForeignKey(d => d.LineaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Costo__linea_id__4D94879B");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Costos)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Costo__sector_id__4F7CD00D");
            });

            modelBuilder.Entity<Fecha>(entity =>
            {
                entity.ToTable("Fecha");

                entity.Property(e => e.FechaId)
                    .ValueGeneratedNever()
                    .HasColumnName("fecha_id");

                entity.Property(e => e.Fecha1)
                    .HasColumnType("date")
                    .HasColumnName("fecha");
            });

            modelBuilder.Entity<Linea>(entity =>
            {
                entity.ToTable("Linea");

                entity.Property(e => e.LineaId)
                    .ValueGeneratedNever()
                    .HasColumnName("linea_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Perdidum>(entity =>
            {
                entity.HasKey(e => new { e.LineaId, e.FechaId, e.SectorId })
                    .HasName("PK__Perdida__0E36D85C27B77A5F");

                entity.Property(e => e.LineaId).HasColumnName("linea_id");

                entity.Property(e => e.FechaId).HasColumnName("fecha_id");

                entity.Property(e => e.SectorId).HasColumnName("sector_id");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.Fecha)
                    .WithMany(p => p.Perdida)
                    .HasForeignKey(d => d.FechaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Perdida__fecha_i__534D60F1");

                entity.HasOne(d => d.Linea)
                    .WithMany(p => p.Perdida)
                    .HasForeignKey(d => d.LineaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Perdida__linea_i__52593CB8");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Perdida)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Perdida__sector___5441852A");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.ToTable("Sector");

                entity.Property(e => e.SectorId)
                    .ValueGeneratedNever()
                    .HasColumnName("sector_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
