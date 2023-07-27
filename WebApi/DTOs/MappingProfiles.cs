using AutoMapper;
using Core.Entities;

namespace WebApi.DTOs
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles() {
            CreateMap<Producto, ProductoDTO>();
        }

    }
}
