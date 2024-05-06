
using Microsoft.AspNetCore.Mvc;
using TicketStore.Storage.Models;
using TicketStore_Web_Api.Features.DtoModels.Order;
using TicketStore_Web_Api.Features.Interfaces.Managers;
namespace TicketStore_Web_Api.Controllers;


[Route("Orders")]
public class OrdersController : Controller
{
    public const string Orders = "Orders";

    private readonly IOrdersManager _orderManager;

    public OrdersController(IOrdersManager orderManager)
    {
        _orderManager = orderManager;
    }

    [HttpGet(nameof(Order), Name = nameof(Order))]
    public async Task <ActionResult> Order(Guid UserId)
    {
        var editOrder = new EditOrder
        {
            IsnUser = UserId
        };
        return View(editOrder);
    }

    [HttpGet(nameof(CreateOrder))]
    public IActionResult CreateOrder(Guid UserId)
    {
        var editOrder = new EditOrder
        {
            IsnUser = UserId,
        };
        return View(editOrder);
    }

    [HttpPost(nameof(CreateOrderView),Name = nameof(CreateOrderView))]
    public async Task <ActionResult> CreateOrderView(EditOrder order)
    {
        //if (!ModelState.IsValid)
        //{
        //    return View(nameof(Order), order);
        //}
        try
        {
            Guid OrderId = _orderManager.Create(order);
            return RedirectToAction(nameof(UserOrderController.UserOrderInfo), "UserOrder", new { orderId = OrderId });
        }
        catch(Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(nameof(CreateOrderView), order);
        }
    }
}

