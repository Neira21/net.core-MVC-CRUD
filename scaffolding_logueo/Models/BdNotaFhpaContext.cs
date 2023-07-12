using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace scaffolding_logueo.Models;

public partial class BdNotaFhpaContext : DbContext
{

    public BdNotaFhpaContext(DbContextOptions<BdNotaFhpaContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Anio> Anios { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Bimestre> Bimestres { get; set; }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Tema> Temas { get; set; }

    public virtual DbSet<TemaAlumno> TemaAlumnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        
    }
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=DESKTOP-8OAHJGT;Database=BD_Nota_FHPA;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__ALUMNO__43FBBAC7A201390D");

            entity.ToTable("ALUMNO", "colegio");

            entity.Property(e => e.IdAlumno)
                .ValueGeneratedNever()
                .HasColumnName("idAlumno");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellidoMaterno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellidoPaterno");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Nombres)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombres");
        });

        modelBuilder.Entity<Anio>(entity =>
        {
            entity.HasKey(e => e.IdAnio).HasName("PK__ANIO__77F6CE5551BDDE27");

            entity.ToTable("ANIO", "colegio");

            entity.Property(e => e.IdAnio)
                .ValueGeneratedNever()
                .HasColumnName("idAnio");
            entity.Property(e => e.Anio1).HasColumnName("anio");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsignatura).HasName("PK__ASIGNATU__DD251214E1F9CA2C");

            entity.ToTable("ASIGNATURA", "colegio");

            entity.Property(e => e.IdAsignatura)
                .ValueGeneratedNever()
                .HasColumnName("idAsignatura");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreAsignatura");
        });

        modelBuilder.Entity<Bimestre>(entity =>
        {
            entity.HasKey(e => e.IdBimestre).HasName("PK__BIMESTRE__D27A3F260DF25EEC");

            entity.ToTable("BIMESTRE", "colegio");

            entity.Property(e => e.IdBimestre)
                .ValueGeneratedNever()
                .HasColumnName("idBimestre");
            entity.Property(e => e.IdAnio).HasColumnName("idAnio");
            entity.Property(e => e.NombreBimestre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombreBimestre");

            entity.HasOne(d => d.IdAnioNavigation).WithMany(p => p.Bimestres)
                .HasForeignKey(d => d.IdAnio)
                .HasConstraintName("FK_BIMESTRE_ANIO");
        });

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => new { e.IdGrupo, e.IdAsignatura, e.IdProfesor });

            entity.ToTable("CLASE", "colegio");

            entity.Property(e => e.IdGrupo).HasColumnName("idGrupo");
            entity.Property(e => e.IdAsignatura).HasColumnName("idAsignatura");
            entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.Clases)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLASE_ASIGNATURA");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Clases)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLASE_GRUPO");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Clases)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLASE_PROFESOR");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__GRUPO__EC597A871F26CABF");

            entity.ToTable("GRUPO", "colegio");

            entity.Property(e => e.IdGrupo)
                .ValueGeneratedNever()
                .HasColumnName("idGrupo");
            entity.Property(e => e.Grado).HasColumnName("grado");
            entity.Property(e => e.IdAnio).HasColumnName("idAnio");
            entity.Property(e => e.Seccion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("seccion");

            entity.HasOne(d => d.IdAnioNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdAnio)
                .HasConstraintName("FK_GRUPO_ANIO");

            entity.HasMany(d => d.IdAlumnos).WithMany(p => p.IdGrupos)
                .UsingEntity<Dictionary<string, object>>(
                    "GrupoAlumno",
                    r => r.HasOne<Alumno>().WithMany()
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GRUPO_ALUMNO_Alumno"),
                    l => l.HasOne<Grupo>().WithMany()
                        .HasForeignKey("IdGrupo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GRUPO_ALUMNO_GRUPO"),
                    j =>
                    {
                        j.HasKey("IdGrupo", "IdAlumno");
                        j.ToTable("GRUPO_ALUMNO", "colegio");
                        j.IndexerProperty<int>("IdGrupo").HasColumnName("idGrupo");
                        j.IndexerProperty<int>("IdAlumno").HasColumnName("idAlumno");
                    });
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("PK__PROFESOR__E4BBA604028AE8DD");

            entity.ToTable("PROFESOR", "colegio");

            entity.Property(e => e.IdProfesor)
                .ValueGeneratedNever()
                .HasColumnName("idProfesor");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellidoMaterno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellidoPaterno");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombres)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Tema>(entity =>
        {
            entity.HasKey(e => e.IdTema).HasName("PK__TEMA__BCD9EB48D768684F");

            entity.ToTable("TEMA", "colegio");

            entity.Property(e => e.IdTema)
                .ValueGeneratedNever()
                .HasColumnName("idTema");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdAsignatura).HasColumnName("idAsignatura");
            entity.Property(e => e.IdBimestre).HasColumnName("idBimestre");
            entity.Property(e => e.NombreTema)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombreTema");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.Temas)
                .HasForeignKey(d => d.IdAsignatura)
                .HasConstraintName("FK_TEMA_ASIGNATURA");

            entity.HasOne(d => d.IdBimestreNavigation).WithMany(p => p.Temas)
                .HasForeignKey(d => d.IdBimestre)
                .HasConstraintName("FK_TEMA_BIMESTRE");
        });

        modelBuilder.Entity<TemaAlumno>(entity =>
        {
            entity.HasKey(e => new { e.IdTema, e.IdAlumno });

            entity.ToTable("TEMA_ALUMNO", "colegio");

            entity.Property(e => e.IdTema).HasColumnName("idTema");
            entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");
            entity.Property(e => e.Nota).HasColumnName("nota");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.TemaAlumnos)
                .HasForeignKey(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TEMA_ALUMNO_ALUMNO");

            entity.HasOne(d => d.IdTemaNavigation).WithMany(p => p.TemaAlumnos)
                .HasForeignKey(d => d.IdTema)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TEMA_ALUMNO_TEMA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
