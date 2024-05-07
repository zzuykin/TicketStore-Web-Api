
using AutoMapper;
using TicketStore.Storage.Models;
using TicketStore_Web_Api.Features.DtoModels.Concerts;

namespace TicketStore_Web_Api.Features.Mappers;

public class ConcertMapper : Profile
{
	public ConcertMapper()
	{
		CreateMap<Concert, ConcertDto>();
		CreateMap<ConcertDto, Concert>();
	}
}
