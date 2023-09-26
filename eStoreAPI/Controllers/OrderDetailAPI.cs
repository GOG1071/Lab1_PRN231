namespace eStoreAPI.Controllers;

using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailAPI : ControllerBase
{
    private readonly OrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
    
    [HttpGet]
    public ActionResult<IEnumerable<OrderDetail>> GetOrderDetails()
    {
        return this._orderDetailRepository.GetAllOrderDetails();
    }
    
    [HttpPut]
    public ActionResult<OrderDetail> UpdateOrderDetail(OrderDetail orderDetail)
    {
        var ord = this._orderDetailRepository.GetOrderDetailById(orderDetail.OrderId, orderDetail.ProductId);
        if (ord == null)
        {
            return NotFound();
        }
        this._orderDetailRepository.UpdateOrderDetail(orderDetail);
        return NoContent();
    }
    
    [HttpPost]
    public ActionResult<OrderDetail> AddOrderDetail(OrderDetail orderDetail)
    {
        var ord = this._orderDetailRepository.GetOrderDetailById(orderDetail.OrderId, orderDetail.ProductId);
        if (ord != null)
        {
            return Conflict();
        }
        this._orderDetailRepository.AddOrderDetail(orderDetail);
        return this.NoContent();
    }
    
    [HttpDelete("Oid={Oid}&Pid={Pid}")]
    public ActionResult<OrderDetail> DeleteOrderDetail(int Oid, int Pid)
    {
        var ord = this._orderDetailRepository.GetOrderDetailById(Oid, Pid);
        if (ord == null)
        {
            return NotFound();
        }
        this._orderDetailRepository.DeleteOrderDetail(ord);
        return NoContent();
    }
    
    
}