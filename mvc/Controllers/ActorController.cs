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
    [Route("api/actores")]
    public class ActorController : ControllerBase
    {
        private readonly AplicationContext _context;
        private readonly IMapper _mapper;
        public ActorController(AplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(){
            return await _context.Actores.OrderByDescending(a => a.FechaNacimiento).ToListAsync();
        }

        [HttpGet("nombre")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string nombre){
            //version1
            return await _context.Actores
                    .Where(a=>a.Nombre == nombre)
                    .OrderBy(a=>a.Nombre)
                        .ThenBy(a=>a.FechaNacimiento)
                    .ToListAsync();
        }

        [HttpGet("nombre/v2")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetV2(string nombre){
            //version2 : Contiene
            return await _context.Actores.Where(a=>a.Nombre.Contains(nombre)).ToListAsync();
        }

        [HttpGet("fechaNacimiento/rango")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(DateTime fechaInicio, DateTime fechaFin){
            //version2 : Contiene
            return await _context.Actores
                    .Where(a=>a.FechaNacimiento >= fechaInicio && a.FechaNacimiento <= fechaFin)
                    .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> Get(int id){
            //version2 : Contiene
            var actor = await _context.Actores.FirstOrDefaultAsync(a=>a.Id ==id);
            if(actor is null){
                return NotFound();
            }
            return actor;
        }

        [HttpGet("idynombre")]
        public async Task<ActionResult<Actor>> Getidynombre(){
            //version2 : Contiene
            var actores = await _context.Actores.Select(a=> new {a.Id, a.Nombre}).ToListAsync();
            return Ok(actores);
        }

        [HttpPost]
        public async Task<ActionResult> Post (ActorCreacionDTO ActorCreacion){
            var actor = _mapper.Map<Actor>(ActorCreacion);
            _context.Add(actor);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
