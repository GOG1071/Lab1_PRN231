namespace eStoreAPI.Controllers;

using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrderAPI : ControllerBase
{
    private readonly OrderRepository _orderRepository = new OrderRepository();
    
    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        return this._orderRepository.GetAllOrders();
    }
    
    [HttpPut]
    public ActionResult<Order> UpdateOrder(Order order)
    {
        var ord = this._orderRepository.GetOrderById(order.OrderId);
        if (ord == null)
        {
            return NotFound();
        }
        this._orderRepository.UpdateOrder(order);
        return NoContent();
    }
    
    [HttpPost]
    public ActionResult<Order> AddOrder(Order order)
    {
        var ord = this._orderRepository.GetOrderById(order.OrderId);
        if (ord != null)
        {
            return Conflict();
        }
        this._orderRepository.AddOrder(order);
        return this.NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult<Order> DeleteOrder(int id)
    {
        var ord = this._orderRepository.GetOrderById(id);
        if (ord == null)
        {
            return NotFound();
        }
        this._orderRepository.DeleteOrder(ord);
        return NoContent();
    }
}