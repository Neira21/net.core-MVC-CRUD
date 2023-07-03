
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.DTOs;
using mvc.Models;

namespace mvc.Controllers
{
    [ApiController]
    [Route("api/peliculas/{peliculaId:int}/comentarios")]
    public class ComentarioController : ControllerBase
    {
        private readonly AplicationContext _context;
        private readonly IMapper _mapper;
        public ComentarioController(AplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post (int peliculaId, ComentarioCreacionDTO comentarioCreacionDTO){
            var comentario = _mapper.Map<Comentario>(comentarioCreacionDTO);
            comentario.PeliculaId = peliculaId;
            _context.Add(comentario);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}