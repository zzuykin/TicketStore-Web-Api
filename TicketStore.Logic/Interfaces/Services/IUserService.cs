
using TicketStore.Logic.DtoModels.Filters;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Interfaces.Services;

public interface IUserService
{
    IQueryable<User> GetUserQueryble(DataContext dataContext, UserFilterDto filter, bool asNoTracking);
}
