using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Rent.Shared.Dto;
using Rent.Shared.Models;

namespace Rent.Server.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Realty, RealtyDto>();
            CreateMap<City, CityDto>();
            CreateMap<IdentityUser, AppUserDto>();
            CreateMap<AppUser, AppUserDto>();
        }
    }
    
}