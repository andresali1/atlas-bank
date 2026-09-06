using Customer.Data.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CustomerDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("CustomerDatabase"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("CustomerDatabase")
        )
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();
