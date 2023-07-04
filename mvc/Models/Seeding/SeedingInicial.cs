using Microsoft.EntityFrameworkCore;

namespace mvc.Models.Seeding
{
    public class SeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var samuelJackson = new Actor(){
                Id = 3, Nombre = "Samuel L. Jackson", 
                FechaNacimiento = new DateTime(1948, 12, 21), 
                Fortuna = 300000000
                };
            var robertDowneyJunior = new Actor(){
                Id = 4, Nombre = "Robert Downey Jr.", 
                FechaNacimiento = new DateTime(1965, 4, 4), 
                Fortuna = 5000000
                };
            modelBuilder.Entity<Actor>().HasData(samuelJackson, robertDowneyJunior);

            var avengers = new Pelicula(){
                Id = 6, 
                Titulo = "Avengers: Endgame", 
                EnCines = false, 
                FechaEstreno = new DateTime(2017, 12, 2)
                };
            var SpiderManNWH = new Pelicula(){
                Id = 7, 
                Titulo = "Spiderman: No Way Hom", 
                EnCines = false, 
                FechaEstreno = new DateTime(2018, 11, 25)
                };
            var SpiderManSpiderVerse2 = new Pelicula(){
                Id = 8, 
                Titulo = "Spiderman SpiderVerse 2", 
                EnCines = false, 
                FechaEstreno = new DateTime(2019, 4, 26)
                };
            modelBuilder.Entity<Pelicula>().HasData(avengers, SpiderManNWH, SpiderManSpiderVerse2);

            var ComentarioAvengers = new Comentario(){
                Id = 2, 
                PeliculaId = avengers.Id, 
                Contenido = "Excelente Película", 
                Recomendar = true
                };
            var ComentarioAvengers2 = new Comentario(){
                Id = 3, 
                PeliculaId = avengers.Id, 
                Contenido = "No me gustó", 
                Recomendar = false
                };
            var ComentarioSpiderManNWH = new Comentario(){
                Id = 4, 
                PeliculaId = SpiderManNWH.Id, 
                Contenido = "Muy buena Película, JAJAJA", 
                Recomendar = true
                };
            var ComentarioSpiderManSpiderVerse2 = new Comentario(){
                Id = 5, 
                PeliculaId = SpiderManSpiderVerse2.Id, 
                Contenido = "No debieron traer startalents a la película, horrible doblaje", 
                Recomendar = false
                };
            modelBuilder.Entity<Comentario>().HasData(ComentarioAvengers, ComentarioAvengers2, ComentarioSpiderManNWH, ComentarioSpiderManSpiderVerse2);

            //muchos a muchos
            var tablaGeneroPelicula = "GeneroPelicula";
            var generoIdPropiedad = "GenerosId";
            var peliculaIdPropiedad = "PeliculasId";

            var cienciaFiccion = 5;
            var animacion = 6;

            modelBuilder.Entity(tablaGeneroPelicula).HasData(
                new Dictionary<string, object> 
                    { 
                        [generoIdPropiedad] = cienciaFiccion, 
                        [peliculaIdPropiedad] =  avengers.Id 
                    },
                new Dictionary<string, object> 
                    { 
                        [generoIdPropiedad] = cienciaFiccion, 
                        [peliculaIdPropiedad] =  SpiderManNWH.Id 
                    },
                new Dictionary<string, object> 
                    { 
                        [generoIdPropiedad] = animacion, 
                        [peliculaIdPropiedad] =  SpiderManSpiderVerse2.Id 
                    }
            );
            
            //muchos a muchos sin salto (peliculas actores)
            var samuelJacksonSpiderManNWH = new PeliculaActor(){
                ActorId = samuelJackson.Id, 
                PeliculaId = SpiderManNWH.Id, 
                Orden = 1,
                Personaje = "Nick Fury"
            };
            var samuelJacksonAvengers = new PeliculaActor(){
                ActorId = samuelJackson.Id, 
                PeliculaId = avengers.Id, 
                Orden = 2,
                Personaje = "Nick Fury"
            };
            var robertDowneyJuniorAvengers = new PeliculaActor(){
                ActorId = robertDowneyJunior.Id, 
                PeliculaId = avengers.Id, 
                Orden = 1,
                Personaje = "Iron Man"
            };
            modelBuilder.Entity<PeliculaActor>().HasData(samuelJacksonSpiderManNWH, samuelJacksonAvengers, robertDowneyJuniorAvengers);

        }

    }

}
