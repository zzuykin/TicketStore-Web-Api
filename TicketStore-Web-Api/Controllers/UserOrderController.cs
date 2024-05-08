

using Microsoft.AspNetCore.Mvc;
using TicketStore_Web_Api.Features.DtoModels.User;
using TicketStore_Web_Api.Features.DtoModels.UserOrder;
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

    [HttpGet(nameof(CheckInfo),Name = nameof(CheckInfo))]
    public async Task<ActionResult> CheckInfo()
    {
        return View();
    }

    [HttpPost(nameof(HandleFormSubmit),Name = nameof(HandleFormSubmit))]
    public IActionResult HandleFormSubmit([FromBody] EditUserOrder editUserOrder)
    {
        var infoUserOrder = userOrderManager.CreateForCheck(editUserOrder);
        var result = userOrderManager.GetInfo(infoUserOrder);
        return Content(result);
    }

    [HttpPost(nameof(UserOrderInfoView), Name = nameof(UserOrderInfoView))]
    public async Task<ActionResult> UserOrderInfoView()
    {
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}
