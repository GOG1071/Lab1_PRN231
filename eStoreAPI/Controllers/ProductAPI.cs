namespace eStoreAPI.Controllers;

using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductAPI : ControllerBase
{
    private readonly ProductRepository _productRepository = new ProductRepository();
    
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return this._productRepository.GetAllProducts();
    }
    
    [HttpPut]
    public ActionResult<Product> UpdateProduct(Product product)
    {
        var pro = this._productRepository.GetProductById(product.ProductId);
        if (pro == null)
        {
            return NotFound();
        }
        this._productRepository.UpdateProduct(product);
        return NoContent();
    }
    
    [HttpPost]
    public ActionResult<Product> AddProduct(Product product)
    {
        var pro = this._productRepository.GetProductById(product.ProductId);
        if (pro != null)
        {
            return Conflict();
        }
        this._productRepository.AddProduct(product);
        return this.NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult<Product> DeleteProduct(int id)
    {
        var pro = this._productRepository.GetProductById(id);
        if (pro == null)
        {
            return NotFound();
        }
        this._productRepository.DeleteProduct(pro);
        return NoContent();
    }
}