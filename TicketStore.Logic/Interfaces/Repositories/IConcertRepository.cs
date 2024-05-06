

using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Interfaces.Repositories;

public interface IConcertRepository
{
    Concert GetById(DataContext dataContext, int concertId);

    Concert Update(DataContext dataContext, Concert concert);
}
