
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Nodes;
using TicketStore.Logic.DtoModels.Filters;
using TicketStore.Logic.Interfaces.Services;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Services
{
    public class OrdersService : IOrdersService
    {
        public IQueryable<Orders> GetOrdersQueryble(DataContext dataContext, OrderFilterDto filter)
        {
            IQueryable<Orders> query = dataContext.Order.AsNoTracking();

            if (filter.IsnUser.HasValue)
            {
                query = query.Where(x => x.IsnUser == filter.IsnUser);
            }

            return query;
        }

        //public User GetUserInfo(DataContext dataContext, Guid isnUser)
        //{
        //    var user = dataContext.Users.AsNoTracking().FirstOrDefault(x => x.IsnNode == isnUser)
        //        ?? throw new Exception($"User с индификатором {isnUser} не найден");

        //    return user;
        //}
    }
}
