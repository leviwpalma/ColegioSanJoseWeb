using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ColegioSanJoseWeb.Models;

public partial class ColegioSanJoseContext : DbContext
{
    public ColegioSanJoseContext()
    {
    }

    public ColegioSanJoseContext(DbContextOptions<ColegioSanJoseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Expediente> Expedientes { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ColegioSanJose;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.AlumnoId).HasName("PK__Alumno__90A6AA137F307E6E");

            entity.ToTable("Alumno");

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Grado).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.ExpedienteId).HasName("PK__Expedien__EBC60A3680019264");

            entity.ToTable("Expediente");

            entity.Property(e => e.NotaFinal).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Alumno).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.AlumnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expediente_Alumno");

            entity.HasOne(d => d.Materia).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.MateriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expediente_Materia");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.MateriaId).HasName("PK__Materia__0D019DE1A175F1DD");

            entity.Property(e => e.Docente).HasMaxLength(100);
            entity.Property(e => e.NombreMateria).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
