

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

    [HttpGet(nameof(ChangeOrder), Name = nameof(ChangeOrder))]
    public async Task<ActionResult> ChangeOrder()
    {
        return View();
    }

    [HttpPost(nameof(SendOrderToChange), Name = nameof(SendOrderToChange))]
    public async Task<ActionResult> SendOrderToChange(EditUserOrder editUserOrder)
    {
        var infoUserOrder = userOrderManager.CreateForCheck(editUserOrder);
        if (infoUserOrder == null)
        {
            return RedirectToAction(nameof(UserOrderController.NotFoundToChange), UserOrderController.UserOrder);
        }
        return RedirectToAction(nameof(UserOrderController.ChooseToChange), UserOrderController.UserOrder, new { orderNum = infoUserOrder.OrderNum });
    }

    [HttpGet(nameof(ChooseToChange), Name = nameof(ChooseToChange))]
    public async Task<ActionResult> ChooseToChange(int orderNum)
    {
        var editUserOrder = userOrderManager.CreateInfo(orderNum);
        return View(editUserOrder);
    }

    [HttpGet(nameof(NotFoundToChange), Name = nameof(NotFoundToChange))]
    public async Task<ActionResult> NotFoundToChange()
    {
        return View();
    }

	[HttpPost(nameof(DeleteOrderBtn), Name = nameof(DeleteOrderBtn))]
	public async Task<ActionResult> DeleteOrderBtn(EditUserOrder editUserOrder)
    {
  //      userOrderManager.DeleteOrder(editUserOrder.OrderNum);
		//return RedirectToAction(nameof(HomeController.Index), "Home");
        return RedirectToAction(nameof(UserOrderController.CheckEmailView), UserOrderController.UserOrder, editUserOrder);
	}

	[HttpGet(nameof(CheckEmailView), Name = nameof(CheckEmailView))]
	public async Task<ActionResult> CheckEmailView(EditUserOrder editUserOrder)
    {
        return View(editUserOrder);
    }

	[HttpPost(nameof(CheckEmail), Name = nameof(CheckEmail))]
	public async Task<ActionResult> CheckEmail(EditUserOrder editUserOrder, string code)
    {
        if (code == "2222")
        {
			userOrderManager.DeleteOrder(editUserOrder.OrderNum);
            return RedirectToAction(nameof(UserOrderController.SuccesDel), UserOrderController.UserOrder);
		}
		return RedirectToAction(nameof(UserOrderController.CheckEmailView), UserOrderController.UserOrder, editUserOrder);
	}

	[HttpGet(nameof(SuccesDel), Name = nameof(SuccesDel))]
	public async Task<ActionResult> SuccesDel()
    {
        return View();
    }

	//[HttpPost(nameof(SendOrderToChange), Name = nameof(SendOrderToChange))]
	//public IActionResult SendOrderToChange([FromBody] EditUserOrder editUserOrder)
	//{
	//    var infoUserOrder = userOrderManager.CreateForCheck(editUserOrder);
	//    var orderNum = editUserOrder.OrderNum;
	//    // return RedirectToAction(nameof(UserOrderController.ChangeOrderView), UserOrderController.UserOrder, infoUserOrder);
	//    var url = Url.Action("ChangeOrderView", "UserOrder", editUserOrder);
	//    return Content(url);
	//}

	//[HttpGet(nameof(ChangeOrderView), Name = nameof(ChangeOrderView))]
	//public async Task<ActionResult> ChangeOrderView(EditUserOrder editUserOrder)
	//{
	//    return View();
	//}

	[HttpPost(nameof(UserOrderInfoView), Name = nameof(UserOrderInfoView))]
    public async Task<ActionResult> UserOrderInfoView()
    {
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}


//            @using (Html.BeginForm(nameof(UserOrderController.SendOrderToChange), UserOrderController.UserOrder, FormMethod.Post))