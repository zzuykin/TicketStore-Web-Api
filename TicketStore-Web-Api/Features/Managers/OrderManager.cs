using AutoMapper;
using TicketStore.Logic.DtoModels.Filters;
using TicketStore.Logic.Interfaces.Repositories;
using TicketStore.Logic.Interfaces.Services;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;
using TicketStore_Web_Api.Features.DtoModels.Order;
using TicketStore_Web_Api.Features.Interfaces.Managers;
namespace TicketStore_Web_Api.Features.Managers;

public class OrderManager : IOrdersManager
{
    private readonly IMapper _mapper;
    private readonly IOrdersRepository _orderRepository;
    private readonly IOrdersService _orderService;
    private readonly DataContext _dataContext;

    public OrderManager(IMapper mapper, IOrdersRepository orederRepository, IOrdersService orderService, DataContext dataContext)
    {
        _mapper = mapper;
        _orderRepository = orederRepository;
        _orderService = orderService;
        _dataContext = dataContext;
    }

    public void Create(EditOrder editOrder)
    {
        if (!_dataContext.Users.Any(x => x.IsnNode == editOrder.IsnUser))
        {
            throw new Exception($"Пользователь с {editOrder.IsnUser} ID не был найден");
        }
        var order = new Orders
        {
            IsnNode = editOrder.IsnNode,
            IsnUser = editOrder.IsnUser,
            OrderNum = editOrder.OrderNum,
            ConcertName = editOrder.ConcertName,
            OrderStatus = editOrder.OrderStatus,
        };
        _orderRepository.Create(_dataContext, order);
        _dataContext.SaveChanges();
    }

    public void Update(EditOrder editOrder)
    {
        var order = _mapper.Map<Orders>(editOrder);
        _orderRepository.Update(_dataContext, order);
        _dataContext.SaveChanges();
    }

    public void Delete(Guid IsnNode) { 
        _orderRepository.Delete(_dataContext, IsnNode);
    }

    public OrderDto GetOrder(Guid IsnNode)
    {
        var order = _orderRepository.GetById(_dataContext, IsnNode);
        return _mapper.Map<OrderDto>(order);
    }

    public OrderDto[] GetListOrders(OrderFilterDto orderFilterDto)
    {
        var orders = _orderService.GetOrdersQueryble(_dataContext, orderFilterDto).Select(x => new OrderDto
        {
            IsnNode = x.IsnNode,
            IsnUser = x.IsnUser,
            OrderNum = x.OrderNum,
            ConcertName = x.ConcertName,
            OrderStatus = x.OrderStatus,

        }).ToArray();
        return orders;
    }
}
