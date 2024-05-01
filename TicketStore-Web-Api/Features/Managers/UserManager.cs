
using Microsoft.AspNetCore.Identity;
using TicketStore.Logic.Interfaces.Repositories;
using TicketStore_Web_Api.Features.Interfaces;
using TicketStore.Storage.DataBase;
using TicketStore_Web_Api.Features.DtoModels.User;
using TicketStore.Logic.DtoModels.Filters;
namespace TicketStore_Web_Api.Features.Managers;

public class UserManager : IUserManager
{
    private readonly IUserRepository userRepository;
    private readonly IUserManager userManager;
    private readonly DataContext dataContext;

    public UserManager(IUserRepository userRepository, IUserManager userManager, DataContext dataContext)
    {
        this.userRepository = userRepository;
        this.userManager = userManager;
        this.dataContext = dataContext;
    }

    public void Create(EditUser editUser)
    {

    }

    public void Update(EditUser editUser)
    {

    }

    public void Delete(Guid InsNode)
    {

    }

    public UserDto GetUser(Guid InsNode)
    {

    }

    public UserDto[] GetListUsers(UserFilterDto)
    {

    }
}
