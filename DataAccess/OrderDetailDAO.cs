namespace DataAccess;

using BusinessObject;

public class OrderDetailDAO
{
    public static List<OrderDetail> GetAllOrderDetails()
    {
        List<OrderDetail> orderDetails = new List<OrderDetail>();
        try
        {
            using var context = new EStoreDbContext();
            orderDetails = context.OrderDetails.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return orderDetails;
    }
    
    public static void AddOrderDetail(OrderDetail orderDetail)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.OrderDetails.Add(orderDetail);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void UpdateOrderDetail(OrderDetail orderDetail)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.OrderDetails.Update(orderDetail);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void DeleteOrderDetail(OrderDetail orderDetail)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.OrderDetails.Remove(orderDetail);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static OrderDetail GetOrderDetailById(int Oid,int Pid)
    {
        OrderDetail orderDetail = null;
        try
        {
            using var context = new EStoreDbContext();
            orderDetail = context.OrderDetails.First(x=>x.OrderId==Oid && x.ProductId==Pid);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return orderDetail;
    }
}