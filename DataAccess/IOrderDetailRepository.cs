namespace DataAccess;

using BusinessObject;

public interface IOrderDetailRepository
{
    void AddOrderDetail(OrderDetail orderDetail);
    void UpdateOrderDetail(OrderDetail orderDetail);
    void DeleteOrderDetail(OrderDetail orderDetail);
    OrderDetail GetOrderDetailById(int Oid, int Pid);
    
    List<OrderDetail> GetAllOrderDetails();
}