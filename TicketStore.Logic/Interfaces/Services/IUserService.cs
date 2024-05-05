
using TicketStore.Logic.DtoModels.Filters;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Interfaces.Services;

public interface IUserService
{
	IQueryable<User> GetUserQueryable(DataContext context, UserFilterDto filter, bool asNoTracking = true);
}
