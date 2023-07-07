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
    [Route("api/generos")]
    public class GeneroController : ControllerBase
    {
        private readonly AplicationContext _context;
        private readonly IMapper _mapper;
        public GeneroController(AplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> Get(){
            return await _context.Generos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post (GeneroCreacionDTO generoCreacion){
            
            var yaExisteGeneroConEsteNombre = await _context.Generos.AnyAsync(g => g.Nombre == generoCreacion.Nombre);

            if(yaExisteGeneroConEsteNombre){
                return BadRequest($"Ya existe un genero con el nombre {generoCreacion.Nombre}");
            }

            var genero = _mapper.Map<Genero>(generoCreacion);
            _context.Add(genero);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPost("varios")]
        public async Task<ActionResult> Post (GeneroCreacionDTO[] generosCreacionDTO){
            var generos = _mapper.Map<Genero[]>(generosCreacionDTO);
            _context.AddRange(generos);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}/nombre2")]
        public async Task<ActionResult> Put(int id, GeneroCreacionDTO generoCreacion){
            var genero = await _context.Generos.FirstOrDefaultAsync(g => g.Id == id);
            
            if(genero is null){
                return NotFound();
            }

            genero.Nombre = generoCreacion.Nombre;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put2(int id, GeneroCreacionDTO generoCreacion){
            var genero = _mapper.Map<Genero>(generoCreacion);
            genero.Id = id;
            _context.Update(genero);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("/otraforma/{id:int}")]
        public async Task<ActionResult> Put3(int id, GeneroCreacionDTO generoCreacion){
            var genero = _mapper.Map<Genero>(generoCreacion);
            genero.Id = id;
            _context.Entry(genero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}/moderna")]
        public async Task <ActionResult> Delete(int id){
            var existe = await _context.Generos.AnyAsync(g => g.Id == id);
            if(!existe){
                return NotFound();
            }
            _context.Remove(new Genero(){Id = id});
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}/moderna2")]
        public async Task <ActionResult> Delete2(int id){
            var filasAlteradas = await _context.Generos.Where(g => g.Id == id).ExecuteDeleteAsync();
            if(filasAlteradas == 0){
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:int}/vieja")]
        public async Task <ActionResult> DeleteAnterior(int id){
            var genero = await _context.Generos.FirstOrDefaultAsync(g => g.Id == id);
            if(genero is null){
                return NotFound();
            }
            _context.Remove(genero);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
