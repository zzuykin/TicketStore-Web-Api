

using Microsoft.AspNetCore.Mvc;
using TicketStore.Logic.DtoModels.Filters;
using TicketStore_Web_Api.Features.DtoModels.User;
using TicketStore_Web_Api.Features.Interfaces;

namespace TicketStore_Web_Api.Controllers;

[Route("Manage")]
public class ManageController: Controller
{
    private readonly IUserManager userManager;

    public ManageController(IUserManager userManager)
    {
        this.userManager = userManager;
    }

    [HttpGet(nameof(User), Name = nameof(User))]
    public async Task<ActionResult> User()
    {
        var user = userManager.GetListUsers(new UserFilterDto()).FirstOrDefault();
        return View(user);
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
    public async Task<ActionResult> CreateUserView([FromBody] EditUser user)
    {
        if (!ModelState.IsValid)
            return View(nameof(User), ModelState);
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
