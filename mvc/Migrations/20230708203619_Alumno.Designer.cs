﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvc.Data;

#nullable disable

namespace mvc.Migrations
{
    [DbContext(typeof(AplicationContext))]
    [Migration("20230708203619_Alumno")]
    partial class Alumno
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.Property<int>("GenerosId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculasId")
                        .HasColumnType("int");

                    b.HasKey("GenerosId", "PeliculasId");

                    b.HasIndex("PeliculasId");

                    b.ToTable("GeneroPelicula");

                    b.HasData(
                        new
                        {
                            GenerosId = 5,
                            PeliculasId = 6
                        },
                        new
                        {
                            GenerosId = 5,
                            PeliculasId = 7
                        },
                        new
                        {
                            GenerosId = 6,
                            PeliculasId = 8
                        });
                });

            modelBuilder.Entity("mvc.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<decimal>("Fortuna")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Actores");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            FechaNacimiento = new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fortuna = 300000000m,
                            Nombre = "Samuel L. Jackson"
                        },
                        new
                        {
                            Id = 4,
                            FechaNacimiento = new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fortuna = 5000000m,
                            Nombre = "Robert Downey Jr."
                        });
                });

            modelBuilder.Entity("mvc.Models.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("mvc.Models.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contenido")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<bool>("Recomendar")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PeliculaId");

                    b.ToTable("Comentarios");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Contenido = "Excelente Película",
                            PeliculaId = 6,
                            Recomendar = true
                        },
                        new
                        {
                            Id = 3,
                            Contenido = "No me gustó",
                            PeliculaId = 6,
                            Recomendar = false
                        },
                        new
                        {
                            Id = 4,
                            Contenido = "Muy buena Película, JAJAJA",
                            PeliculaId = 7,
                            Recomendar = true
                        },
                        new
                        {
                            Id = 5,
                            Contenido = "No debieron traer startalents a la película, horrible doblaje",
                            PeliculaId = 8,
                            Recomendar = false
                        });
                });

            modelBuilder.Entity("mvc.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Nombre = "Ciencia Ficción"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Animación"
                        });
                });

            modelBuilder.Entity("mvc.Models.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<bool>("EnCines")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaEstreno")
                        .HasColumnType("date");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Peliculas");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            Duracion = 0,
                            EnCines = false,
                            FechaEstreno = new DateTime(2017, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titulo = "Avengers: Endgame"
                        },
                        new
                        {
                            Id = 7,
                            Duracion = 0,
                            EnCines = false,
                            FechaEstreno = new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titulo = "Spiderman: No Way Hom"
                        },
                        new
                        {
                            Id = 8,
                            Duracion = 0,
                            EnCines = false,
                            FechaEstreno = new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titulo = "Spiderman SpiderVerse 2"
                        });
                });

            modelBuilder.Entity("mvc.Models.PeliculaActor", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Personaje")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ActorId", "PeliculaId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("PeliculasActores");

                    b.HasData(
                        new
                        {
                            ActorId = 3,
                            PeliculaId = 7,
                            Orden = 1,
                            Personaje = "Nick Fury"
                        },
                        new
                        {
                            ActorId = 3,
                            PeliculaId = 6,
                            Orden = 2,
                            Personaje = "Nick Fury"
                        },
                        new
                        {
                            ActorId = 4,
                            PeliculaId = 6,
                            Orden = 1,
                            Personaje = "Iron Man"
                        });
                });

            modelBuilder.Entity("mvc.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.HasOne("mvc.Models.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mvc.Models.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("PeliculasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mvc.Models.Comentario", b =>
                {
                    b.HasOne("mvc.Models.Pelicula", "Pelicula")
                        .WithMany("Comentarios")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("mvc.Models.PeliculaActor", b =>
                {
                    b.HasOne("mvc.Models.Actor", "Actor")
                        .WithMany("PeliculaActores")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mvc.Models.Pelicula", "Pelicula")
                        .WithMany("PeliculaActores")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("mvc.Models.Actor", b =>
                {
                    b.Navigation("PeliculaActores");
                });

            modelBuilder.Entity("mvc.Models.Pelicula", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("PeliculaActores");
                });
#pragma warning restore 612, 618
        }
    }
}
