using System.Globalization;
using Apitest.Dtos;
using Apitest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apitest.Controllers;

[ApiController]
[Route("api/orderitems")]
public class OrderItemsController(IOrderItemService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<OrderItemDto>>> GetAll(int page = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var result = await service.GetAllAsync(page, pageSize, ct);
        Response.Headers["X-Total-Count"] = result.TotalCount.ToString(CultureInfo.InvariantCulture);
        return Ok(result.Items);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderItemDto>> GetById(int id, CancellationToken ct) =>
        Ok(await service.GetByIdAsync(id, ct));

    [HttpPost]
    public async Task<ActionResult<OrderItemDto>> Create(CreateOrderItemDto dto, CancellationToken ct)
    {
        var created = await service.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.OrderItemId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateOrderItemDto dto, CancellationToken ct)
    {
        await service.UpdateAsync(id, dto, ct);
        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchOrderItemDto dto, CancellationToken ct)
    {
        await service.PatchAsync(id, dto, ct);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await service.DeleteAsync(id, ct);
        return NoContent();
    }
}
