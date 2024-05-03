
using Microsoft.EntityFrameworkCore;
using TicketStore.Logic.Interfaces.Repositories;
using TicketStore.Storage.DataBase;
using TicketStore.Storage.Models;

namespace TicketStore.Logic.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Create(DataContext dataContext, User user)
        {
            user.IsnNode = Guid.NewGuid();
            dataContext.Users.Add(user);
            dataContext.SaveChanges();
            return user;

        }

        public User Update(DataContext dataContext, User user)
        {
            var userDb = dataContext.Users.FirstOrDefault(x => x.IsnNode == user.IsnNode)
            ?? throw new Exception($"User с индификатором {user.IsnNode} не найден");

            userDb.Code = user.Code;
            userDb.ClientEmail = user.ClientEmail;
            userDb.ClientName = user.ClientName;
            userDb.ClientSurname = user.ClientSurname;
            userDb.ClientLastName = user.ClientLastName;

            return userDb;
        }

        public void Delete(DataContext dataContext, Guid IsNode)
        {
            var userDb = dataContext.Users.FirstOrDefault(x => x.IsnNode == IsNode)
            ?? throw new Exception($"User с индификатором {IsNode} не найден");

            dataContext.Users.Remove(userDb);
        }

        public User GetById(DataContext dataContext, Guid IsnNode)
        {
            var userDb = dataContext.Users.AsNoTracking().FirstOrDefault(x => x.IsnNode == IsnNode)
                ?? throw new Exception($"User с индификатором {IsnNode} не найден");

            return userDb;
        }
    }
}
