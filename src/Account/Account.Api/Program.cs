using Account.Api.Middleware;
using Account.Application;
using Account.Application.Interfaces;
using Account.Infrastructure.Persistence;
using Account.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    var connectionString =
        builder.Configuration.GetConnectionString("AccountDatabase");

    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<CreateAccount>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
