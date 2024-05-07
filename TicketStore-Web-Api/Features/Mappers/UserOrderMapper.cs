

using AutoMapper;
using TicketStore.Storage.Models;
using TicketStore_Web_Api.Features.DtoModels.UserOrder;

namespace TicketStore_Web_Api.Features.Mappers;

public class UserOrderMapper : Profile
{
    public UserOrderMapper()
    {
        CreateMap<Orders, EditUserOrder>()
        .ForMember(dest => dest.IsnUser, opt => opt.MapFrom(src => src.IsnUser))
        .ForMember(dest => dest.OrderNum, opt => opt.MapFrom(src => src.OrderNum))
        .ForMember(dest => dest.ConcertName, opt => opt.MapFrom(src => src.ConcertName))
        .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus));

        CreateMap<User, EditUserOrder>()
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.ClientName))
            .ForMember(dest => dest.ClientSurname, opt => opt.MapFrom(src => src.ClientSurname))
            .ForMember(dest => dest.ClientEmail, opt => opt.MapFrom(src => src.ClientEmail))
            .ForMember(dest => dest.ClientLastName, opt => opt.MapFrom(src => src.ClientLastName));

        CreateMap<Concert, EditUserOrder>().ForMember(dest => dest.TicketPrice, opt => opt.MapFrom(scr => scr.TicketPrice));
    }
}
