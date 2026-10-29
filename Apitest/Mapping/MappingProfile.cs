using AutoMapper;
using Apitest.Models;
using Apitest.Dtos;

namespace Apitest.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Role, RoleDto>();

        CreateMap<Role, RoleSummaryDto>();

        CreateMap<CreateRoleDto, Role>()
            .ForMember(d => d.RoleId, o => o.Ignore())
            .ForMember(d => d.Users, o => o.Ignore());

        CreateMap<UpdateRoleDto, Role>()
            .ForMember(d => d.RoleId, o => o.Ignore())
            .ForMember(d => d.Users, o => o.Ignore());

        CreateMap<PatchRoleDto, Role>()
            .ForMember(d => d.RoleId, o => o.Ignore())
            .ForMember(d => d.Users, o => o.Ignore())
            .ForMember(d => d.RoleName, o => o.PreCondition(s => s.RoleName != null));

        CreateMap<Category, CategoryDto>();

        CreateMap<Category, CategorySummaryDto>();

        CreateMap<CreateCategoryDto, Category>()
            .ForMember(d => d.CategoryId, o => o.Ignore())
            .ForMember(d => d.Products, o => o.Ignore());

        CreateMap<UpdateCategoryDto, Category>()
            .ForMember(d => d.CategoryId, o => o.Ignore())
            .ForMember(d => d.Products, o => o.Ignore());

        CreateMap<PatchCategoryDto, Category>()
            .ForMember(d => d.CategoryId, o => o.Ignore())
            .ForMember(d => d.Products, o => o.Ignore())
            .ForMember(d => d.CategoryName, o => o.PreCondition(s => s.CategoryName != null));

        CreateMap<User, UserDto>();

        CreateMap<User, UserSummaryDto>();

        CreateMap<CreateUserDto, User>()
            .ForMember(d => d.UserId, o => o.Ignore())
            .ForMember(d => d.Cart, o => o.Ignore())
            .ForMember(d => d.Orders, o => o.Ignore())
            .ForMember(d => d.Role, o => o.Ignore());

        CreateMap<UpdateUserDto, User>()
            .ForMember(d => d.UserId, o => o.Ignore())
            .ForMember(d => d.Cart, o => o.Ignore())
            .ForMember(d => d.Orders, o => o.Ignore())
            .ForMember(d => d.Role, o => o.Ignore());

        CreateMap<PatchUserDto, User>()
            .ForMember(d => d.UserId, o => o.Ignore())
            .ForMember(d => d.Cart, o => o.Ignore())
            .ForMember(d => d.Orders, o => o.Ignore())
            .ForMember(d => d.Role, o => o.Ignore())
            .ForMember(d => d.Login, o => o.PreCondition(s => s.Login != null))
            .ForMember(d => d.PasswordHash, o => o.PreCondition(s => s.PasswordHash != null))
            .ForMember(d => d.RoleId, o => o.PreCondition(s => s.RoleId != null))
            .ForMember(d => d.UserName, o => o.PreCondition(s => s.UserName != null))
            .ForMember(d => d.IsActive, o => o.PreCondition(s => s.IsActive != null));

        CreateMap<Product, ProductDto>();

        CreateMap<Product, ProductSummaryDto>();

        CreateMap<CreateProductDto, Product>()
            .ForMember(d => d.ProductId, o => o.Ignore())
            .ForMember(d => d.CartItems, o => o.Ignore())
            .ForMember(d => d.Category, o => o.Ignore())
            .ForMember(d => d.OrderItems, o => o.Ignore())
            .ForMember(d => d.Reservations, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.RowVersion, o => o.Ignore());

        CreateMap<UpdateProductDto, Product>()
            .ForMember(d => d.ProductId, o => o.Ignore())
            .ForMember(d => d.CartItems, o => o.Ignore())
            .ForMember(d => d.Category, o => o.Ignore())
            .ForMember(d => d.OrderItems, o => o.Ignore())
            .ForMember(d => d.Reservations, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.RowVersion, o => o.Ignore());

        CreateMap<PatchProductDto, Product>()
            .ForMember(d => d.ProductId, o => o.Ignore())
            .ForMember(d => d.CartItems, o => o.Ignore())
            .ForMember(d => d.Category, o => o.Ignore())
            .ForMember(d => d.OrderItems, o => o.Ignore())
            .ForMember(d => d.Reservations, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.RowVersion, o => o.Ignore())
            .ForMember(d => d.ProductName, o => o.PreCondition(s => s.ProductName != null))
            .ForMember(d => d.Price, o => o.PreCondition(s => s.Price != null))
            .ForMember(d => d.CategoryId, o => o.PreCondition(s => s.CategoryId != null))
            .ForMember(d => d.ImagePath, o => o.PreCondition(s => s.ImagePath != null))
            .ForMember(d => d.StockQuantity, o => o.PreCondition(s => s.StockQuantity != null));

        CreateMap<Order, OrderDto>();

        CreateMap<Order, OrderSummaryDto>();

        CreateMap<CreateOrderDto, Order>()
            .ForMember(d => d.OrderId, o => o.Ignore())
            .ForMember(d => d.OrderItems, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore());

        CreateMap<UpdateOrderDto, Order>()
            .ForMember(d => d.OrderId, o => o.Ignore())
            .ForMember(d => d.OrderItems, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore());

        CreateMap<PatchOrderDto, Order>()
            .ForMember(d => d.OrderId, o => o.Ignore())
            .ForMember(d => d.OrderItems, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore())
            .ForMember(d => d.UserId, o => o.PreCondition(s => s.UserId != null))
            .ForMember(d => d.OrderDate, o => o.PreCondition(s => s.OrderDate != null))
            .ForMember(d => d.Status, o => o.PreCondition(s => s.Status != null))
            .ForMember(d => d.TotalAmount, o => o.PreCondition(s => s.TotalAmount != null));

        CreateMap<OrderItem, OrderItemDto>();

        CreateMap<CreateOrderItemDto, OrderItem>()
            .ForMember(d => d.OrderItemId, o => o.Ignore())
            .ForMember(d => d.Order, o => o.Ignore())
            .ForMember(d => d.Product, o => o.Ignore());

        CreateMap<UpdateOrderItemDto, OrderItem>()
            .ForMember(d => d.OrderItemId, o => o.Ignore())
            .ForMember(d => d.Order, o => o.Ignore())
            .ForMember(d => d.Product, o => o.Ignore());

        CreateMap<PatchOrderItemDto, OrderItem>()
            .ForMember(d => d.OrderItemId, o => o.Ignore())
            .ForMember(d => d.Order, o => o.Ignore())
            .ForMember(d => d.Product, o => o.Ignore())
            .ForMember(d => d.OrderId, o => o.PreCondition(s => s.OrderId != null))
            .ForMember(d => d.ProductId, o => o.PreCondition(s => s.ProductId != null))
            .ForMember(d => d.Quantity, o => o.PreCondition(s => s.Quantity != null))
            .ForMember(d => d.UnitPrice, o => o.PreCondition(s => s.UnitPrice != null));

        CreateMap<Cart, CartDto>();

        CreateMap<Cart, CartSummaryDto>();

        CreateMap<CreateCartDto, Cart>()
            .ForMember(d => d.CartId, o => o.Ignore())
            .ForMember(d => d.CartItems, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore());

        CreateMap<UpdateCartDto, Cart>()
            .ForMember(d => d.CartId, o => o.Ignore())
            .ForMember(d => d.CartItems, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore());

        CreateMap<PatchCartDto, Cart>()
            .ForMember(d => d.CartId, o => o.Ignore())
            .ForMember(d => d.CartItems, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore())
            .ForMember(d => d.UserId, o => o.PreCondition(s => s.UserId != null));

        CreateMap<CartItem, CartItemDto>();

        CreateMap<CreateCartItemDto, CartItem>()
            .ForMember(d => d.CartItemId, o => o.Ignore())
            .ForMember(d => d.Cart, o => o.Ignore())
            .ForMember(d => d.Product, o => o.Ignore());

        CreateMap<UpdateCartItemDto, CartItem>()
            .ForMember(d => d.CartItemId, o => o.Ignore())
            .ForMember(d => d.Cart, o => o.Ignore())
            .ForMember(d => d.Product, o => o.Ignore());

        CreateMap<PatchCartItemDto, CartItem>()
            .ForMember(d => d.CartItemId, o => o.Ignore())
            .ForMember(d => d.Cart, o => o.Ignore())
            .ForMember(d => d.Product, o => o.Ignore())
            .ForMember(d => d.CartId, o => o.PreCondition(s => s.CartId != null))
            .ForMember(d => d.ProductId, o => o.PreCondition(s => s.ProductId != null))
            .ForMember(d => d.Quantity, o => o.PreCondition(s => s.Quantity != null));

        CreateMap<ProductReservation, ProductReservationDto>();

        CreateMap<CreateProductReservationDto, ProductReservation>()
            .ForMember(d => d.ProductReservationId, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.CancelledAt, o => o.Ignore())
            .ForMember(d => d.RowVersion, o => o.Ignore())
            .ForMember(d => d.Product, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore());

        CreateMap<UpdateProductReservationDto, ProductReservation>()
            .ForMember(d => d.ProductReservationId, o => o.Ignore())
            .ForMember(d => d.ProductId, o => o.Ignore())
            .ForMember(d => d.UserId, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.CancelledAt, o => o.Ignore())
            .ForMember(d => d.RowVersion, o => o.Ignore())
            .ForMember(d => d.Product, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore());

        CreateMap<PatchProductReservationDto, ProductReservation>()
            .ForMember(d => d.ProductReservationId, o => o.Ignore())
            .ForMember(d => d.ProductId, o => o.Ignore())
            .ForMember(d => d.UserId, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.CancelledAt, o => o.Ignore())
            .ForMember(d => d.RowVersion, o => o.Ignore())
            .ForMember(d => d.Product, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore())
            .ForMember(d => d.Quantity, o => o.PreCondition(s => s.Quantity.HasValue));
    }
}
