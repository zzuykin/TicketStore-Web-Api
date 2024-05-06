

using TicketStore.Logic.Interfaces.Services;
using TicketStore.Storage.DataBase;
using TicketStore_Web_Api.Features.DtoModels.Order;
using TicketStore_Web_Api.Features.DtoModels.User;
using TicketStore_Web_Api.Features.Interfaces.Managers;

namespace TicketStore_Web_Api.Features.Managers;

public class ConcertManager : IConcertManager
{
	private readonly DataContext _dataContext;
	private readonly IConcertService _concertService;

	public ConcertManager(DataContext dataContext, IConcertService concertService)
	{
		_dataContext = dataContext;
		_concertService = concertService;
	}

	public EditOrder GetEditOrderForMakeOrder(Guid UserId)
	{
		var editOrder = new EditOrder
		{
			IsnUser = UserId,
			concerts = _concertService.GetAllConcerts(_dataContext).ToList(),
		};

		return editOrder;
	}

}
