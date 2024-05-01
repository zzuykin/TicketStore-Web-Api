
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Interfaces.Repositories;

public interface IOrdersRepository
{
    Orders Create(DataContext dataContext, Orders order);
    void Delete(DataContext dataContext, Guid Isnode);
    Orders GetById(DataContext dataContext, Guid IsnNode);
    Orders Update(DataContext dataContext, Orders order);

}
