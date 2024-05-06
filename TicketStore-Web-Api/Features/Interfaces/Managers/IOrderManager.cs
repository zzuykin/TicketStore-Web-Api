

using TicketStore.Logic.DtoModels.Filters;
using TicketStore_Web_Api.Features.DtoModels.Order;

namespace TicketStore_Web_Api.Features.Interfaces.Managers;

public interface IOrdersManager
{
    Guid Create(EditOrder editOrder);

    void Update(EditOrder editOrder);

    void Delete(Guid IsnNode);

    OrderDto GetOrder(Guid IsnNode);

    OrderDto[] GetListOrders(OrderFilterDto orderFilterDto);
}
