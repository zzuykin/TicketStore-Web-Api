using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TicketStore.Storage.DataBase;
using TicketStore_Web_Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o =>
    {
        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddWebServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Ticket-Store", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

    foreach (FileInfo file in new DirectoryInfo(AppContext.BaseDirectory).GetFiles(
                 Assembly.GetExecutingAssembly().GetName().Name! + ".xml"))
        c.IncludeXmlComments(file.FullName);

    c.EnableAnnotations(enableAnnotationsForInheritance: true,
        enableAnnotationsForPolymorphism: true
    );
});

var app = builder.Build();

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket-Store");
        options.EnableDeepLinking();
    });
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
