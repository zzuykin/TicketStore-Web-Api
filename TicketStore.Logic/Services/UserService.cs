using Microsoft.EntityFrameworkCore;
using TicketStore.Logic.DtoModels.Filters;
using TicketStore.Logic.Interfaces.Services;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;
namespace TicketStore.Logic.Services
{
    public class UserService: IUserService
    {
		public IQueryable<User> GetUserQueryable(DataContext context, UserFilterDto filter, bool asNoTracking = true)
		{
			IQueryable<User> query = context.Users;

			if (asNoTracking)
			{
				query = query.AsNoTracking();
			}
			return query;
		}
	}
}
