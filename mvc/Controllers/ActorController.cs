using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<ActionResult> Post (ActorCreacionDTO ActorCreacion){
            var actor = _mapper.Map<Actor>(ActorCreacion);
            _context.Add(actor);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
