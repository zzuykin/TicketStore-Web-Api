

using Microsoft.AspNetCore.Mvc;
using TicketStore.Logic.DtoModels.Filters;
using TicketStore_Web_Api.Features.DtoModels.User;
using TicketStore_Web_Api.Features.Interfaces.Managers;

namespace TicketStore_Web_Api.Controllers;

[Route("Manage")]
public class ManageController: Controller
{
    public const string Manage = "Manage";
    private readonly IUserManager userManager;

    public ManageController(IUserManager userManager)
    {
        this.userManager = userManager;
    }

    [HttpGet(nameof(User), Name = nameof(User))]
    public async Task<ActionResult> User()
    {
        //var user = userManager.GetListUsers(new UserFilterDto()).FirstOrDefault();
        //return View(user);
        return View();
    }

    [HttpPost(nameof(CreateUser), Name = nameof(CreateUser))]
    public async Task<ActionResult> CreateUser([FromBody] EditUser user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        userManager.Create(user);
        return Ok();
    }

    [HttpPost(nameof(CreateUserView), Name = nameof(CreateUserView))]
    public async Task<ActionResult> CreateUserView(EditUser user)
    {
        if (!ModelState.IsValid)
            return View(nameof(User), user);
        try
        {
			var UserId = userManager.Create(user);
            return RedirectToAction(nameof(OrdersController.Order), OrdersController.Orders, new { userId = UserId });
		}
		catch (Exception ex)
		{
			ModelState.AddModelError(string.Empty, ex.Message);
			return View(nameof(CreateUserView), user);
		}
		userManager.Create(user);
        return View();
    }

    [HttpPut(nameof(UpdateUser), Name = nameof(UpdateUser))]
    public async Task<ActionResult> UpdateUser([FromBody] EditUser user)
    {
        userManager.Update(user);
        return Ok();
    }

    [HttpPut(nameof(DeleteUser), Name = nameof(DeleteUser))]
    public async Task<ActionResult> DeleteUser([FromQuery] Guid IsnNode)
    {
        userManager.Delete(IsnNode);
        return Ok();
    }

    [HttpGet(nameof(GetListUsers), Name = nameof(GetListUsers))]
    public async Task<ActionResult> GetListUsers()
    {
        var users = userManager.GetListUsers(new UserFilterDto());
        return Ok(users);
    }
}
