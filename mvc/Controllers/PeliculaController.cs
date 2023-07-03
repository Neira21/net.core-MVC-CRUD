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
        
        

    }
}
