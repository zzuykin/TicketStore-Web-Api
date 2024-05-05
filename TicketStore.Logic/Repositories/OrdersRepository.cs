using Microsoft.EntityFrameworkCore;
using TicketStore.Logic.Interfaces.Repositories;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public Orders Create(DataContext dataContext, Orders order)
        {
            if (dataContext.Order.Any())
            {
                int maxOrderNum = dataContext.Order.Max(x => x.OrderNum);
                order.OrderNum = maxOrderNum;
            }
            else
            {
                order.OrderNum = 0;
            }
            order.IsnNode = Guid.NewGuid();
            order.OrderStatus = "Забронировано";
            dataContext.Order.Add(order);
            dataContext.SaveChanges();
            return order;
        }
        
        public void Delete(DataContext dataContext, Guid Isnode) 
        { 
            var ordeDb = dataContext.Order.FirstOrDefault(x => x.IsnNode == Isnode)
                ?? throw new Exception($"User с индификатором {Isnode} не найден");

            dataContext.Order.Remove(ordeDb);
        }

        public Orders GetById(DataContext dataContext, Guid IsnNode)
        {
            var orderDb = dataContext.Order.AsNoTracking().FirstOrDefault(x => x.IsnNode == IsnNode)
                ?? throw new Exception($"User с индификатором {IsnNode} не найден");

            return orderDb;
        }

        public Orders Update(DataContext dataContext, Orders order)
        {
            var orderDb = dataContext.Order.FirstOrDefault(x => x.IsnNode ==  order.IsnNode)
                ?? throw new Exception($"User с индификатором {order.IsnNode} не найден");

            var userDb = dataContext.Users.FirstOrDefault(x => x.IsnNode == order.IsnUser)
                ?? throw new Exception($"User с индификатором {order.IsnUser} не найден");

            orderDb.IsnUser = order.IsnUser;
            orderDb.OrderNum = order.OrderNum;
            orderDb.OrderStatus = order.OrderStatus;
            orderDb.User = userDb;

            return orderDb;
        }
    }
}
