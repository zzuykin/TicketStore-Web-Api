
using AutoMapper;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;
using TicketStore_Web_Api.Features.DtoModels.UserOrder;
using TicketStore_Web_Api.Features.Interfaces.Managers;

namespace TicketStore_Web_Api.Features.Managers
{
    public class UserOrderManager : IUserOrderManager
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public UserOrderManager(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public EditUserOrder CreateInfo(Guid OrderId)
        {
            var order = _dataContext.Order.FirstOrDefault(x => x.IsnNode == OrderId);
            var user = _dataContext.Users.FirstOrDefault(x => x.IsnNode == order.IsnUser);
            var concert = _dataContext.Concerts.FirstOrDefault(x => x.ConcertName == order.ConcertName);

            var editUserOrder = _mapper.Map<EditUserOrder>(order);
            _mapper.Map(user, editUserOrder);
            _mapper.Map(concert, editUserOrder);
            return editUserOrder;
        }

        public EditUserOrder CreateForCheck(EditUserOrder editUserOrder)
        {
            var order = _dataContext.Order.FirstOrDefault(x => x.OrderNum == editUserOrder.OrderNum);
            if (order != null)
            {
                var user = _dataContext.Users.FirstOrDefault(x => x.IsnNode == order.IsnUser);
                if(editUserOrder.ClientEmail == user.ClientEmail)
                {
					var infoUserOrder = _mapper.Map<EditUserOrder>(order);
                    _mapper.Map(user, editUserOrder);
                    return infoUserOrder;
                }
			}
            return null;
        }

        public string GetInfo(EditUserOrder editUserOrder)
        {
            string result;
            if (editUserOrder != null)
            {
                result = $"Статус заказа {editUserOrder.OrderNum}: концерт {editUserOrder.ConcertName} - {editUserOrder.OrderStatus}";
            }
            else
            {
                result = "Не найдено такого заказа :(";
            }
            return result;
        }
    }
}
