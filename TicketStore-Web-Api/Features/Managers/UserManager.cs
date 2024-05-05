
using Microsoft.AspNetCore.Identity;
using TicketStore.Logic.Interfaces.Repositories;
using TicketStore_Web_Api.Features.Interfaces;
using TicketStore.Storage.DataBase;
using TicketStore_Web_Api.Features.DtoModels.User;
using TicketStore.Logic.DtoModels.Filters;
using TicketStore.Storage.Models;
using TicketStore.Logic.Repositories;
using AutoMapper;
using TicketStore.Logic.Interfaces.Services;
namespace TicketStore_Web_Api.Features.Managers;

public class UserManager : IUserManager
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    private readonly DataContext _dataContext;

    public UserManager(IMapper mapper, IUserRepository userRepository, IUserService userService, DataContext dataContext)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userService = userService;
        _dataContext = dataContext;
    }

    public Guid Create(EditUser editUser)
    {
        var user = new User
        {
            IsnNode = editUser.IsnNode,
            ClientName = editUser.ClientName,
            ClientSurname = editUser.ClientSurname,
            ClientLastName = editUser.ClientLastName,
            ClientEmail = editUser.ClientEmail,
        };
        _userRepository.Create(_dataContext, user);
        _dataContext.SaveChanges();

        return user.IsnNode;
    }

    public void Update(EditUser editUser)
    {
        var user = _mapper.Map<User>(editUser);
        _userRepository.Update(_dataContext, user);
        _dataContext.SaveChanges();
    }

    public void Delete(Guid InsNode)
    {
        _userRepository.Delete(_dataContext, InsNode);  

    }

    public UserDto GetUser(Guid isnNode)
    {
        var user = _userRepository.GetById(_dataContext, isnNode);
        return _mapper.Map<UserDto>(user);
    }

    public UserDto[] GetListUsers(UserFilterDto userFilterDto)
    {
        var users = _userService.GetUserQueryable(_dataContext, userFilterDto, true).Select(x => new UserDto
        {
            IsnNode = x.IsnNode,
            ClientName = x.ClientName,
            ClientSurname = x.ClientSurname,
            ClientLastName = x.ClientLastName,
            ClientEmail = x.ClientEmail,
        }).ToArray();

        return users;
    }
}
