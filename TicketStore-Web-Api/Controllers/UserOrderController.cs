

using Microsoft.AspNetCore.Mvc;
using TicketStore_Web_Api.Features.DtoModels.User;
using TicketStore_Web_Api.Features.Interfaces.Managers;

namespace TicketStore_Web_Api.Controllers;

[Route("UserOrder")]
public class UserOrderController : Controller
{
    public const string UserOrder = "UserOrder";
    private readonly IUserOrderManager userOrderManager;

    public UserOrderController(IUserOrderManager userOrderManager)
    {
        this.userOrderManager = userOrderManager;
    }

    [HttpGet(nameof(UserOrderInfo), Name = nameof(UserOrderInfo))]
    public async Task<ActionResult> UserOrderInfo(Guid OrderId)
    {
        var editUserOrder = userOrderManager.CreateInfo(OrderId);
        return View(editUserOrder);
    }

    [HttpPost(nameof(UserOrderInfoView), Name = nameof(UserOrderInfoView))]
    public async Task<ActionResult> UserOrderInfoView()
    {
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}
