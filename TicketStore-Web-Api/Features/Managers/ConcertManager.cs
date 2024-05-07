

using Microsoft.EntityFrameworkCore;
using System;
using TicketStore.Logic.Interfaces.Repositories;
using TicketStore.Logic.Interfaces.Services;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;
using TicketStore_Web_Api.Features.DtoModels.Concerts;
using TicketStore_Web_Api.Features.DtoModels.Order;
using TicketStore_Web_Api.Features.DtoModels.User;
using TicketStore_Web_Api.Features.Interfaces.Managers;

namespace TicketStore_Web_Api.Features.Managers;

public class ConcertManager : IConcertManager
{
	private readonly DataContext _dataContext;
	private readonly IConcertService _concertService;
	private readonly IConcertRepository _concertRepository;

	public ConcertManager(DataContext dataContext, IConcertService concertService, IConcertRepository concertRepository)
	{
		_dataContext = dataContext;
		_concertService = concertService;
		_concertRepository = concertRepository;
	}

	public EditOrder GetEditOrderForMakeOrder(Guid UserId)
	{
		var editOrder = new EditOrder
		{
			IsnUser = UserId,
			concerts = _concertService.GetAllConcerts(_dataContext).ToList(),
			AvaibleTicetNow = new List<int> { }
		};
		//костыль
		for(int i = 0; i < editOrder.concerts.Count;i++)
		{
			var avaible = _dataContext.Order.Count(x => x.ConcertName == editOrder.concerts[i].ConcertName);
			editOrder.AvaibleTicetNow.Add(editOrder.concerts[i].AvailableTickets - avaible);
		}
		return editOrder;
	}

	public List<ConcertDto> GetListConcerts()
	{
		var concerts = _concertService.GetAllConcerts(_dataContext).Select(x => new ConcertDto
		{
			ConcertName = x.ConcertName,
			//костыль
			AvailableTickets = x.AvailableTickets - _dataContext.Order.Count(t => t.ConcertName == x.ConcertName),
			TicketPrice = x.TicketPrice,
			Number = x.Number,
		}).ToList();
		return concerts;
	}

	public void ChangeCountOfAvaible(EditOrder editOrder, bool minus = true)
	{
		var concert = _dataContext.Concerts.FirstOrDefault(x => x.ConcertName == editOrder.ConcertName);
		if (concert != null && concert.AvailableTickets > 0)
		{
			if (minus)
			{
				concert.AvailableTickets--;
			}
			else
			{
				concert.AvailableTickets++;
			}
			_concertRepository.Update(_dataContext, concert);
		}
	}

}
