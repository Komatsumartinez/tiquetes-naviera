using AutoMapper;
using Tiquetes.Naviera.Models;

namespace Tiquetes.Naviera.MappingProfiles
{
    public class Mappingprofile : Profile
    {
        public Mappingprofile()
        {
            CreateMap<Tiquete, TiqueteDto>().ReverseMap();
        }
    }
}
