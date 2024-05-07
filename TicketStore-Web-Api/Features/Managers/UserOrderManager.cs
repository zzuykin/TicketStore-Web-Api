
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
    }
}
