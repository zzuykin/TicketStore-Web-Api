

using TicketStore.Logic.DtoModels.Filters;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Interfaces.Services;

public interface IOrdersService
{
    IQueryable<Orders> GetOrdersQueryble(DataContext dataContext, OrderFilterDto filter);

}
