

using TicketStore_Web_Api.Features.DtoModels.UserOrder;

namespace TicketStore_Web_Api.Features.Interfaces.Managers;

public interface IUserOrderManager
{
    EditUserOrder CreateForCheck(EditUserOrder editUserOrder);
    EditUserOrder CreateInfo(Guid OrderId);
    EditUserOrder CreateInfo(int orderNum);
    string GetInfo(EditUserOrder editUserOrder);

    void DeleteOrder(int orderNum);
}
