using AutoMapper;
using TicketStore.Storage.Models;
using TicketStore_Web_Api.Features.DtoModels.Order;

namespace TicketStore_Web_Api.Features.Mappers;

public class OrderMapper : Profile
{
    public OrderMapper()
    {
        CreateMap<Orders, EditOrder>();
        CreateMap<EditOrder, Orders>();
    }
}
