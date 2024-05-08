

using TicketStore_Web_Api.Features.DtoModels.UserOrder;

namespace TicketStore_Web_Api.Features.Interfaces.Managers;

public interface IUserOrderManager
{
    EditUserOrder CreateForCheck(EditUserOrder editUserOrder);
    EditUserOrder CreateInfo(Guid OrderId);

    string GetInfo(EditUserOrder editUserOrder);
}
