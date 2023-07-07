using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.DTOs;
using mvc.Models;

namespace mvc.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculaController : ControllerBase
    {
        private readonly AplicationContext _context;
        private readonly IMapper _mapper;
        public PeliculaController(AplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pelicula>> Get(int id){
            var pelicula = await _context.Peliculas
                .Include(a=>a.Generos)
                .Include(a=>a.Comentarios)
                .Include(a=>a.PeliculaActores.OrderBy(pa=>pa.Orden))
                    .ThenInclude(a=>a.Actor)
                .FirstOrDefaultAsync(a=>a.Id ==id);
                
            if(pelicula is null){
                return NotFound();
            }
            return pelicula;
        }

        [HttpGet("select/{id:int}")]
        public async Task<ActionResult<Pelicula>> GetSelected(int id){
            var pelicula = await _context.Peliculas
                .Select(a=> new {
                    a.Id,
                    a.Titulo,
                    Generos = a.Generos.Select(g=>g.Nombre).ToList(),
                    Actores = a.PeliculaActores.OrderBy(pa => pa.Orden).Select(pa=> 
                        new {
                            Id = pa.ActorId,
                            pa.Actor.Nombre,
                            pa.Personaje,
                    }),
                    Comentarios = a.Comentarios.Select(g=>g.Contenido).ToList(),
                    CantidadComentarios = a.Comentarios.Count()
                })
                .FirstOrDefaultAsync(a=>a.Id ==id);
                
            if(pelicula is null){
                return NotFound();
            }
            return Ok(pelicula);
            //Se coloca OK(PELICULA) porque se proyecta a un objeto anónimo
        }

        [HttpPost]
        public async Task<ActionResult> Post (PeliculaCreacionDTO PeliculaCreacionDTO){
            var pelicula = _mapper.Map<Pelicula>(PeliculaCreacionDTO);
            if(pelicula.Generos is not null){
                foreach (var genero in pelicula.Generos)
                {
                    _context.Entry(genero).State = EntityState.Unchanged;
                }
            }
            if(pelicula.PeliculaActores is not null){
                for(int i = 0; i < pelicula.PeliculaActores.Count; i++){
                    pelicula.PeliculaActores[i].Orden = i + 1;
                }
            }
            _context.Add(pelicula);
            await _context.SaveChangesAsync();
            return Ok();
            
        }
        
        [HttpDelete("{id:int}/moderna")]
        public async Task <ActionResult> Delete2(int id){
            var filasAlteradas = await _context.Peliculas.
                Where(g => g.Id == id).ExecuteDeleteAsync();
            if(filasAlteradas == 0){
                return NotFound();
            }
            return NoContent();
        }

        

    }
}
