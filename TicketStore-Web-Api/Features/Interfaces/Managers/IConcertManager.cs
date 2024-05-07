

using TicketStore_Web_Api.Features.DtoModels.Concerts;
using TicketStore_Web_Api.Features.DtoModels.Order;

namespace TicketStore_Web_Api.Features.Interfaces.Managers;

public interface IConcertManager
{
	EditOrder GetEditOrderForMakeOrder(Guid UserId);

	void ChangeCountOfAvaible(EditOrder editOrder, bool minus = true);

	List<ConcertDto> GetListConcerts();
}
