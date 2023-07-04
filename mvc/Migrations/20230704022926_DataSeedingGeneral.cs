using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mvc.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingGeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actores",
                columns: new[] { "Id", "FechaNacimiento", "Fortuna", "Nombre" },
                values: new object[,]
                {
                    { 3, new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 300000000m, "Samuel L. Jackson" },
                    { 4, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000000m, "Robert Downey Jr." }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Id", "Duracion", "EnCines", "FechaEstreno", "Titulo" },
                values: new object[,]
                {
                    { 6, 0, false, new DateTime(2017, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers: Endgame" },
                    { 7, 0, false, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spiderman: No Way Hom" },
                    { 8, 0, false, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spiderman SpiderVerse 2" }
                });

            migrationBuilder.InsertData(
                table: "Comentarios",
                columns: new[] { "Id", "Contenido", "PeliculaId", "Recomendar" },
                values: new object[,]
                {
                    { 2, "Excelente Película", 6, true },
                    { 3, "No me gustó", 6, false },
                    { 4, "Muy buena Película, JAJAJA", 7, true },
                    { 5, "No debieron traer startalents a la película, horrible doblaje", 8, false }
                });

            migrationBuilder.InsertData(
                table: "GeneroPelicula",
                columns: new[] { "GenerosId", "PeliculasId" },
                values: new object[,]
                {
                    { 5, 6 },
                    { 5, 7 },
                    { 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "PeliculasActores",
                columns: new[] { "ActorId", "PeliculaId", "Orden", "Personaje" },
                values: new object[,]
                {
                    { 3, 6, 2, "Nick Fury" },
                    { 3, 7, 1, "Nick Fury" },
                    { 4, 6, 1, "Iron Man" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comentarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comentarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comentarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comentarios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosId", "PeliculasId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosId", "PeliculasId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosId", "PeliculasId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
