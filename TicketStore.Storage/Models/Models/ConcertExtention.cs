
namespace TicketStore.Storage.Models.Models;

public static class ConcertExtention
{
    public static string GetConcertName(this Concert concert)
    {
        if (concert.ConcertName != string.Empty)
        {
            return concert.ConcertName;
        }
        return string.Empty;
    }

    public static int GetNumOfAvailableTickets(this Concert concert)
    {
        return concert.AvailableTickets;
    }

    public static int GetTicketPrice(this Concert concert)
    {
        return concert.TicketPrice;
    }
}
