

using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Interfaces.Services;

public interface IConcertService
{
	IQueryable<Concert> GetAllConcerts(DataContext dataContext);

	int GetAvaible(DataContext dataContext, int Number);

    int GetTicketPrice(DataContext dataContext, int Number);
}
