using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPracticaII.Client.Models;

public partial class Motored01Context : DbContext
{
    public Motored01Context()
    {
    }

    public Motored01Context(DbContextOptions<Motored01Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Motocicleta> Motocicletas { get; set; }

    public virtual DbSet<Opinione> Opiniones { get; set; }

    public virtual DbSet<ReportesOpinione> ReportesOpiniones { get; set; }

    public virtual DbSet<Taller> Tallers { get; set; }

    public virtual DbSet<TallerTop> TallerTops { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source=DESKTOP-DFG8PLB\\SQLEXPRESS05; Initial Catalog=Motored01; Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Motocicleta>(entity =>
        {
            entity.HasKey(e => e.IdMoto).HasName("PK__Motocicl__C0D1CACF584CC891");

            entity.Property(e => e.IdMoto).HasColumnName("idMoto");
            entity.Property(e => e.Aseguradora)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Patente)
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Motocicleta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_moto");
        });

        modelBuilder.Entity<Opinione>(entity =>
        {
            entity.HasKey(e => e.IdOpinion).HasName("PK__opinione__2F8F71D7CB0B9203");

            entity.ToTable("opiniones");

            entity.Property(e => e.Comentario)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fecha)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.IdTallerNavigation).WithMany(p => p.Opiniones)
                .HasForeignKey(d => d.IdTaller)
                .HasConstraintName("fk_IdTallerr");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Opiniones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_IdUsuarioO");
        });

        modelBuilder.Entity<ReportesOpinione>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK__Reportes__F9561136C9B2406A");

            entity.Property(e => e.Comentario)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("comentario");
            entity.Property(e => e.Fecha)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuarioRc).HasColumnName("IdUsuarioRC");
            entity.Property(e => e.Motivo)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdOpinionNavigation).WithMany(p => p.ReportesOpiniones)
                .HasForeignKey(d => d.IdOpinion)
                .HasConstraintName("fk_IdOpinion");
        });

        modelBuilder.Entity<Taller>(entity =>
        {
            entity.HasKey(e => e.IdTaller).HasName("PK__Taller__AC44FFD633AC2651");

            entity.ToTable("Taller");

            entity.Property(e => e.Direccion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Horarios)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LinksMapa)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Localidad)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreTaller)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.País)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Estado)
               .HasMaxLength(20)
               .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tallers)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_IdUsuario");
        });

        modelBuilder.Entity<TallerTop>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TallerTop");

            entity.Property(e => e.LinkTaller)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.IdTallerNavigation).WithMany()
                .HasForeignKey(d => d.IdTaller)
                .HasConstraintName("fk_IdTaller");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97E5CC0B2D");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
