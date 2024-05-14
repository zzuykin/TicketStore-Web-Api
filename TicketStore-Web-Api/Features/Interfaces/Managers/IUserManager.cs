using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Logic.DtoModels.Filters;
using TicketStore_Web_Api.Features.DtoModels.User;

namespace TicketStore_Web_Api.Features.Interfaces.Managers
{
    public interface IUserManager
    {
        Guid Create(EditUser editUser);

        void Update(EditUser editUser);

        void Delete(Guid InsNode);

        EditUser GetUser(Guid isnNode);

        UserDto[] GetListUsers(UserFilterDto userFilterDto);
    }
}
