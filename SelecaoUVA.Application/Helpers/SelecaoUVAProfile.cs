using AutoMapper;
using SelecaoUVA.Application.DTOs;
using SelecaoUVA.Domain.Entities;

namespace SelecaoUVA.Application.Helpers
{
    class SelecaoUVAProfile : Profile
    {

        public SelecaoUVAProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserViewDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
        }
    }
}
