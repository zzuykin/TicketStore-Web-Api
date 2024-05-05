

using TicketStore.Storage.DataBase;

namespace TicketStore.Logic.Interfaces.Services;

public interface IConcertService
{
    int GetAvaible(DataContext dataContext, int Number);

    int GetTicketPrice(DataContext dataContext, int Number);
}
