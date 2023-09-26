namespace DataAccess;

using BusinessObject;

public class OrderRepository : IOrderRepository
{
    public void AddOrder(Order order)
    {
        OrderDAO.AddOrder(order);
    }
    
    public void UpdateOrder(Order order)
    {
        OrderDAO.UpdateOrder(order);
    }
    
    public void DeleteOrder(Order order)
    {
        OrderDAO.DeleteOrder(order);
    }
    
    public Order GetOrderById(int id)
    {
        return OrderDAO.GetOrderById(id);
    }
    
    public List<Order> GetAllOrders()
    {
        return OrderDAO.GetAllOrders();
    }
}