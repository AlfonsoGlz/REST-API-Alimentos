using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RESTAPI_Alimentos.Models
{
    public partial class API_AlimentosContext : DbContext
    {
        public API_AlimentosContext()
        {
        }

        public API_AlimentosContext(DbContextOptions<API_AlimentosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alimento> Alimentos { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Unidad> Unidads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConexionDefault");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alimento>(entity =>
            {
                entity.HasKey(e => e.IdAlimentos)
                    .HasName("PK__Alimento__9882C1B1B475C79A");

                entity.Property(e => e.Calorias).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Carbohidratos).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Fibra).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Grasas).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.NombreAlimento)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Proteinas).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Sodio).HasColumnType("decimal(7, 2)");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Alimentos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK__Alimentos__Categ__7F2BE32F");

                entity.HasOne(d => d.Unidad)
                    .WithMany(p => p.Alimentos)
                    .HasForeignKey(d => d.UnidadId)
                    .HasConstraintName("FK__Alimentos__Unida__00200768");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A108B18DCD4");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.HasKey(e => e.IdUnidad)
                    .HasName("PK__Unidad__437725E613BADCB6");

                entity.ToTable("Unidad");

                entity.Property(e => e.NombreUnidad)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
