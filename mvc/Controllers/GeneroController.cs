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

    }
}
