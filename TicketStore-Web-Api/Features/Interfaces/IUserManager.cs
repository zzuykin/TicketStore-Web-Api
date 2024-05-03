﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Logic.DtoModels.Filters;
using TicketStore_Web_Api.Features.DtoModels.User;

namespace TicketStore_Web_Api.Features.Interfaces
{
    public interface IUserManager
    {
        void Create(EditUser editUser);

        void Update(EditUser editUser);

        void Delete(Guid InsNode);

        UserDto GetUser(Guid isnNode);

        UserDto[] GetListUsers(UserFilterDto userFilterDto);
    }
}
