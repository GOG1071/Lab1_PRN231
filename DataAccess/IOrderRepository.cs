namespace DataAccess;

using BusinessObject;

public interface IOrderRepository
{
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(Order order);
    Order GetOrderById(int id);
    
    List<Order> GetAllOrders();
}