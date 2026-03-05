using Microsoft.EntityFrameworkCore;
using ShoppingCart;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Infrastructure.Data;
using ShoppingCart.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShoppingCartContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingCartConnection")));

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();