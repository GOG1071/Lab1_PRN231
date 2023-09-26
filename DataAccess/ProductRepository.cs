namespace DataAccess;

using BusinessObject;

public class ProductRepository : IProductRepository
{
    public void AddProduct(Product product)
    {
        ProductDAO.AddProduct(product);
    }
    
    public void UpdateProduct(Product product)
    {
        ProductDAO.UpdateProduct(product);
    }
    
    public void DeleteProduct(Product product)
    {
        ProductDAO.DeleteProduct(product);
    }
    
    public Product GetProductById(int id)
    {
        return ProductDAO.GetProductById(id);
    }
    
    public List<Product> GetAllProducts()
    {
        return ProductDAO.GetAllProducts();
    }
}