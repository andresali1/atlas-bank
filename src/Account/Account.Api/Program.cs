using Account.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    var connectionString =
        builder.Configuration.GetConnectionString("AccountDatabase");

    options.UseNpgsql(connectionString);
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
