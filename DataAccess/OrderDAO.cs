namespace DataAccess;

using BusinessObject;

public class OrderDAO
{
    public static List<Order> GetAllOrders()
    {
        List<Order> orders = new();
        try
        {
            using var context = new EStoreDbContext();
            orders = context.Orders.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return orders;
    }
    
    public static Order GetOrderById(int id)
    {
        Order order = null;
        try
        {
            using var context = new EStoreDbContext();
            order = context.Orders.Find(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return order;
    }
    
    public static void AddOrder(Order order)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.Orders.Add(order);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void UpdateOrder(Order order)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.Orders.Update(order);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void DeleteOrder(Order order)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.Orders.Remove(order);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}