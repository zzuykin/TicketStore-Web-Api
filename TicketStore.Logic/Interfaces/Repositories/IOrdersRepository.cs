
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Interfaces.Repositories;

public interface IOrdersRepository
{
    Orders Create(DataContext dataContext, Orders order);
    void Delete(DataContext dataContext, Guid Isnode);

    void Delete(DataContext dataContext, int orderNum);
	Orders GetById(DataContext dataContext, Guid IsnNode);
    Orders Update(DataContext dataContext, Orders order);

}
