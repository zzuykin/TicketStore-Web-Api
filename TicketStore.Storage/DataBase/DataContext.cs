using TicketStore.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketStore.Storage.DataBase;
public class DataContext: DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Orders> Order { get; set; }    

    public virtual DbSet<Concert> Concerts { get; set; }

}
