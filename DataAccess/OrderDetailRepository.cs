namespace DataAccess;

using BusinessObject;

public class OrderDetailRepository : IOrderDetailRepository
{
    public void AddOrderDetail(OrderDetail orderDetail)
    {
        OrderDetailDAO.AddOrderDetail(orderDetail);
    }
    
    public void UpdateOrderDetail(OrderDetail orderDetail)
    {
        OrderDetailDAO.UpdateOrderDetail(orderDetail);
    }
    
    public void DeleteOrderDetail(OrderDetail orderDetail)
    {
        OrderDetailDAO.DeleteOrderDetail(orderDetail);
    }
    
    public OrderDetail GetOrderDetailById(int Oid, int Pid)
    {
        return OrderDetailDAO.GetOrderDetailById(Oid, Pid);
    }
    
    public List<OrderDetail> GetAllOrderDetails()
    {
        return OrderDetailDAO.GetAllOrderDetails();
    }
}