
using AutoMapper;
using TicketStore.Logic.Interfaces.Repositories;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;
using TicketStore_Web_Api.Features.DtoModels.UserOrder;
using TicketStore_Web_Api.Features.Interfaces.Managers;

namespace TicketStore_Web_Api.Features.Managers
{
    public class UserOrderManager : IUserOrderManager
    {
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _ordersRepository;
        private readonly DataContext _dataContext;

		public UserOrderManager(IMapper mapper, IOrdersRepository ordersRepository, DataContext dataContext)
		{
			_mapper = mapper;
			_ordersRepository = ordersRepository;
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

        public EditUserOrder CreateInfo(int orderNum)
        {
            var order = _dataContext.Order.FirstOrDefault(x => x.OrderNum == orderNum);
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

        public void DeleteOrder(int orderNum)
        {
            _ordersRepository.Delete(_dataContext, orderNum);
        }
    }
}
