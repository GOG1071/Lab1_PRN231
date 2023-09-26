namespace DataAccess;

using BusinessObject;

public interface IProductRepository
{
    void    AddProduct(Product product);
    void    UpdateProduct(Product product);
    void    DeleteProduct(Product product);
    Product GetProductById(int id);

    List<Product> GetAllProducts();
}