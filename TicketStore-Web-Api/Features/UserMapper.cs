

using AutoMapper;
using TicketStore.Storage.Models;
using TicketStore_Web_Api.Features.DtoModels.User;

namespace TicketStore_Web_Api.Features;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, EditUser>();
        CreateMap<EditUser, User>();
    }

}
