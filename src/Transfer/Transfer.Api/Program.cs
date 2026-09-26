using Microsoft.EntityFrameworkCore;
using Transfer.Application.Commands.CreateTransfer;
using Transfer.Application.Interfaces;
using Transfer.Infrastructure.Persistence;
using Transfer.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TransferDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("TransferDatabase");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ITransferRepository, TransferRepository>();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(
        typeof(CreateTransferCommandHandler).Assembly
    );
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
