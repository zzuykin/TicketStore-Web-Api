﻿using Microsoft.EntityFrameworkCore;
using TicketStore.Logic.DtoModels.Filters;
using TicketStore.Logic.Interfaces.Services;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;
namespace TicketStore.Logic.Services
{
    public class UserService: IUserService
    {
        public IQueryable<User> GetUserQueryble(DataContext dataContext, UserFilterDto filter, bool asNoTracking) 
        {
            IQueryable<User> query = dataContext.Users;
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (!string.IsNullOrEmpty(filter.Code))
                query = query.Where(x => x.Code == filter.Code);

            return query;
        }
    }
}
