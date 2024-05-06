

using TicketStore_Web_Api.Features.DtoModels.UserOrder;

namespace TicketStore_Web_Api.Features.Interfaces.Managers;

public interface IUserOrderManager
{
    EditUserOrder CreateInfo(Guid OrderId);
}
