namespace DataAccess;

using BusinessObject;

public class ProductDAO
{
    public static List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        try
        {
            using var context = new EStoreDbContext();
            products = context.Products.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return products;
    }
    
    public static Product GetProductById(int id)
    {
        Product product = null;
        try
        {
            using var context = new EStoreDbContext();
            product = context.Products.Find(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return product;
    }
    
    public static void AddProduct(Product product)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.Products.Add(product);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void UpdateProduct(Product product)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.Products.Update(product);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void DeleteProduct(Product product)
    {
        try
        {
            using var context = new EStoreDbContext();
            context.Products.Remove(product);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}