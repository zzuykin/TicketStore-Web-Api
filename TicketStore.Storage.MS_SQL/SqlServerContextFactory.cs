﻿using TicketStore.Storage.DataBase;

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace TicketStore.Storage.MS_SQL;

public class SqlServerContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    private const string DbContextString = "Server=localhost,1433;Database=TicketStore;User ID=sa;Password=<YourStrong@Passw0rd>;MultipleActiveResultSets=true;TrustServerCertificate=True";
    public DataContext CreateDbContext(string[] args) {
        var optionBulder = new DbContextOptionsBuilder<DataContext>();
        optionBulder.UseSqlServer(DbContextString, b => b.MigrationsAssembly(typeof(SqlServerContextFactory).Namespace));
        return new DataContext(optionBulder.Options);
    }
    
}
