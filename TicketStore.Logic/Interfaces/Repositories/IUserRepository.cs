
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Interfaces.Repositories;

public interface IUserRepository
{
    User Create(DataContext dataContext, User user);
    User Update(DataContext dataContext, User user);
    void Delete(DataContext dataContext, Guid IsNode);
    User GetById(DataContext dataContext, Guid IsnNode);
}
