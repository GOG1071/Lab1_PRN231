namespace eStoreClient.Controllers;

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly HttpClient        _httpClient       = null;
    private readonly ProductRepository productRepository = new ProductRepository();
    private          string            _baseUrl          = "";

    public ProductController()
    {
        this._httpClient = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        this._httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        this._baseUrl = "http://localhost:5172/Product";
    }

    #region GET

    public async Task<IActionResult> Index()
    {
        var list = this.productRepository.GetAllProducts();
        return View(list);
    }

    public ActionResult Detail(int? id)
    {
        if (id == null || id <= 0)
            return this.NotFound();
        var product = this.productRepository.GetProductById(id.Value);
        if (product == null)
            return this.NotFound();
        return this.View(product);
    }

    public ActionResult Edit(int id)
    {
        if (id == null || id <= 0)
            return this.NotFound();
        var product = this.productRepository.GetProductById(id);
        if (product == null)
            return this.NotFound();
        return this.View(product);
    }

    public ActionResult Delete(int id)
    {
        if (id == null || id <= 0)
            return this.NotFound();
        var product = this.productRepository.GetProductById(id);
        if (product == null)
            return this.NotFound();
        return this.View(product);
    }
    public ActionResult Create()       { return this.View(); }

    #endregion

    #region CUD

    [HttpPost] [ValidateAntiForgeryToken] public async Task<IActionResult> Create(Product product)
    {
        this.productRepository.AddProduct(product);
        return this.RedirectToAction("Index");
    }

    [HttpPost] [ValidateAntiForgeryToken] public async Task<IActionResult> Edit(Product product)
    {
        this.productRepository.UpdateProduct(product);
        return this.RedirectToAction("Index");
    }

    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Product product)
    {
        this.productRepository.DeleteProduct(product);
        return this.RedirectToAction("Index");
    }

    #endregion
}