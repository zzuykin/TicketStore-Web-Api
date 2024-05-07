
using Microsoft.EntityFrameworkCore;
using TicketStore.Logic.Interfaces.Services;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Services
{
    public class ConcertService: IConcertService
    {

		public IQueryable<Concert> GetAllConcerts(DataContext dataContext)
		{
			IQueryable<Concert> query = dataContext.Concerts.AsNoTracking();
			return query;
		}


		public int GetAvaible(DataContext dataContext,int Number)
        {
            var concert = dataContext.Concerts.FirstOrDefault(x => x.Number == Number);
            if (concert != null)
            {
                return concert.AvailableTickets;
            }
            return -1;
        }

        public int GetTicketPrice(DataContext dataContext, int Number)
        {
            var concert = dataContext.Concerts.FirstOrDefault(x => x.Number == Number);
            if (concert != null)
            {
                return concert.TicketPrice;
            }
            return -1;
        }
    }
}
