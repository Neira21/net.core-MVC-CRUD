using AutoMapper;
using mvc.DTOs;
using mvc.Models;

namespace mvc.Utilidades{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<ActorCreacionDTO, Actor>();
        }
    }
}

