using Domain.Abstractions;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICustomerRepository, InMemoryCustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var getCustomers = (ICustomerRepository repository) => Results.Ok(repository.GetAll());

app.MapGet("/api/customers", (ICustomerRepository repository) => getCustomers);

app.Run();

