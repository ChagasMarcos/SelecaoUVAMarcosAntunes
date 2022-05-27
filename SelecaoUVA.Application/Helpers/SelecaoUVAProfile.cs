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

            CreateMap<UserViewDTO, User>().ReverseMap()
                .ForMember(to => to.CreationDate, opt => opt.MapFrom(from => from.CreationDate.ToShortTimeString()));
            
            CreateMap<User, UserViewDTO>().ReverseMap()
                 .ForMember(to => to.CreationDate, opt => opt.MapFrom(from => from.CreationDate.ToShortTimeString()));

            CreateMap<User, UserUpdateDTO>().ReverseMap();
        }
    }
}
