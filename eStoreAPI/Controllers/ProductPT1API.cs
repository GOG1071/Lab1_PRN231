using AutoMapper;
using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers;

[ApiController]
[Route("api/Product/get-product-by-id/{id:int}")]
public class ProductPT1API : ControllerBase
{
    private readonly ProductRepository productRepository = new ProductRepository();
    
    [HttpGet]
    public ActionResult<ProductPT> GetProductById(int id)
    {
        var config = new MapperConfiguration(cfg => 
            cfg.CreateMap<Product, ProductPT>().ForMember(
                dest=>dest.CategoryName, 
                opt=>opt.MapFrom(src => CategoryDAO.GetCategoryByID(src.CategoryId).CategoryName))
            );
        var mapper = new Mapper(config);
        var pro = this.productRepository.GetProductById(id);
        if (pro == null)
        {
            return NotFound();
        }

        var productPT = mapper.Map<ProductPT>(pro);
        
        return productPT;
    }

    public class ProductPT
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
[ApiController]
[Route("api/Product/{startPrice:float}/{endPrice:float}")]
public class ProductPT2API : ControllerBase
{
    private readonly ProductRepository productRepository = new ProductRepository();
    [HttpGet]public ActionResult<List<ProductPT1API.ProductPT>> GetList(float startPrice, float endPrice)
    {
        var config = new MapperConfiguration(cfg => 
            cfg.CreateMap<Product, ProductPT1API.ProductPT>().ForMember(
                dest=>dest.CategoryName, 
                opt=>opt.MapFrom(src => CategoryDAO.GetCategoryByID(src.CategoryId).CategoryName))
        );
        var mapper = new Mapper(config);
        if (startPrice > endPrice) return BadRequest();
        var list = this.productRepository.GetAllProducts()
            .Where(x => x.UnitPrice >= (decimal)startPrice && x.UnitPrice <= (decimal)endPrice).ToList();
        if (list.Count <= 0) return NotFound();
        var listPT = new List<ProductPT1API.ProductPT>();
        listPT = mapper.Map<List<ProductPT1API.ProductPT>>(list);
        // list.ForEach(x=> listPT.Add(mapper.Map<ProductPT1API.ProductPT>(x)));
        return listPT;
    }
}