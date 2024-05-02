
namespace TicketStore.Storage.Models.Models;

public static class OrdersExtentions
{
    public static string GetOrderStatus(this Orders order)
    {
        return order.OrderStatus;
    }


    public static int GetOrderNum(this Orders order) {
        return order.OrderNum;
    }

    //public static string GetOrderConcertName(this Orders order)
    //{
    //    return order.ConcertName;
    //}
}
