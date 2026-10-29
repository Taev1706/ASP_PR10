using Apitest.Controllers;
using Apitest.Mapping;
using Apitest.Models;
using Apitest.Repositories;
using Apitest.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Apitest;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers(options => options.Filters.Add<ServiceExceptionFilter>());
        builder.Services.AddDbContext<ShopBdContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("con")));
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        builder.Services.AddScoped<IOrderItemService, OrderItemService>();
        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<ICartService, CartService>();
        builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
        builder.Services.AddScoped<ICartItemService, CartItemService>();
        builder.Services.AddScoped<IProductReservationRepository, ProductReservationRepository>();
        builder.Services.AddScoped<IProductReservationService, ProductReservationService>();
        builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
            cfg.LicenseKey = builder.Configuration["AutoMapper:LicenseKey"];
        }, provider.GetRequiredService<ILoggerFactory>()));
        builder.Services.AddScoped<IMapper>(provider =>
            provider.GetRequiredService<MapperConfiguration>().CreateMapper(provider.GetService));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
