
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Nodes;
using TicketStore.Logic.Interfaces.Repositories;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Repositories
{
    public class ConcertRepository : IConcertRepository
    {
        public Concert GetById(DataContext dataContext, int concertId)
        {
            var concertDb = dataContext.Concerts.AsNoTracking().FirstOrDefault(x => x.Number == concertId)
                ?? throw new Exception($"Concert с индификатором {concertId} не найден");

            return concertDb;
        }

        public Concert Update(DataContext dataContext, Concert concert)
        {
            var concertDb = dataContext.Concerts.AsNoTracking().FirstOrDefault(x => x.Number == concert.Number)
                ?? throw new Exception($"Concert с индификатором {concert.Number} не найден");

            concertDb.Number = concert.Number;
            concertDb.TicketPrice = concert.TicketPrice;
            concertDb.AvailableTickets = concert.AvailableTickets;
            concertDb.ConcertName = concert.ConcertName;

            return concertDb;
        }
    }
}
