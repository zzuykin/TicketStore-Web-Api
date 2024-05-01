

using Microsoft.Extensions.DependencyInjection;
using TicketStore.Logic.Interfaces.Repositories;
using TicketStore.Logic.Interfaces.Services;
using TicketStore.Logic.Repositories;
using TicketStore.Logic.Services;

namespace TicketStore.Logic.Extenstions;

public static class ServiceCollectionExtentions
{
    public static void AddLogicServises(this IServiceCollection services)
    {
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IOrdersService, OrdersService>();
        services.AddSingleton<IConcertService, ConcertService>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IOrdersRepository, OrdersRepository>();
        services.AddSingleton<IConcertRepository, ConcertRepository>();
    }
}
