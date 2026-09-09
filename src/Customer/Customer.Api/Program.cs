using Customer.Business.Services;
using Customer.Contracts.Interfaces;
using Customer.Data.Persistence;
using Customer.Data.Repositories;
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

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
