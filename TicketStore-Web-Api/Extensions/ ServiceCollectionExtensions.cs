

using TicketStore.Logic.Extenstions;
using TicketStore_Web_Api.Features.Interfaces.Managers;
using TicketStore_Web_Api.Features.Managers;

namespace TicketStore_Web_Api.Extensions;

public  static class ServiceCollectionExtensions
{
    public static void AddWebServices(this IServiceCollection services)
    {
        services.AddLogicServises();

        services.AddTransient<IUserManager, UserManager>();
        services.AddTransient<IOrdersManager, OrderManager>();
    }
}
