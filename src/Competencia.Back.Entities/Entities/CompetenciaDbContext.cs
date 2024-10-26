using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Competencia.Back.Entities.Entities;

public partial class CompetenciaDbContext : DbContext
{
    public CompetenciaDbContext()
    {
    }

    public CompetenciaDbContext(DbContextOptions<CompetenciaDbContext> options)
        : base(options)
    {
        var dbExist = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        try
        {
            if (dbExist != null)
            {
                if (!dbExist.CanConnect())
                {
                    dbExist.Create();
                }
                if (!dbExist.HasTables())
                {
                    dbExist.CreateTables();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }

    }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Oficina> Oficinas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<ReservaPersona> ReservaPersonas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__ESTADO__62EA894AF7DAB308");

            entity.ToTable("ESTADO");

            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.DescriptionEstado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descriptionEstado");
        });

        modelBuilder.Entity<Oficina>(entity =>
        {
            entity.HasKey(e => e.IdOficina).HasName("PK__OFICINA__7BFFBB0B02098359");

            entity.ToTable("OFICINA");

            entity.Property(e => e.IdOficina).HasColumnName("idOficina");
            entity.Property(e => e.NombreOficina)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreOficina");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__PERSONA__A4788141F74CD2F5");

            entity.ToTable("PERSONA");

            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.ApellidoPersona)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidoPersona");
            entity.Property(e => e.CedulaPersona)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cedulaPersona");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombrePersona)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombrePersona");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_ROL");
        });

        modelBuilder.Entity<ReservaPersona>(entity =>
        {
            entity.HasKey(e => e.IdReservaPersona).HasName("PK__RESERVA___DEA0163B7D185E8D");

            entity.ToTable("RESERVA_PERSONA");

            entity.Property(e => e.IdReservaPersona).HasColumnName("idReservaPersona");
            entity.Property(e => e.DateReserva)
                .HasColumnType("datetime")
                .HasColumnName("dateReserva");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdOficina).HasColumnName("idOficina");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.ReservaPersonas)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK_ESTADO");

            entity.HasOne(d => d.IdOficinaNavigation).WithMany(p => p.ReservaPersonas)
                .HasForeignKey(d => d.IdOficina)
                .HasConstraintName("FK_OFICINA");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.ReservaPersonas)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_PERSONA");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROL__3C872F76BDD19CBA");

            entity.ToTable("ROL");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.DescriptionRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descriptionRol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
