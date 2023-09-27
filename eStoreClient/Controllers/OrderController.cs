namespace eStoreClient.Controllers;

using System.Net.Http.Headers;
using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

public class OrderController : Controller
{
    private readonly HttpClient _httpClient = new HttpClient();
    private          string     _baseUrl    = "http://localhost:5172/Order";

    public OrderController()
    {
        this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    private readonly OrderRepository orderRepository = new OrderRepository();

    #region GET

    public async Task<IActionResult> Index()
    {
        var list = this.orderRepository.GetAllOrders();
        return View(list);
    }

    public ActionResult Detail(int? id)
    {
        if (id == null || id <= 0)
            return this.NotFound();
        var order = this.orderRepository.GetOrderById(id.Value);
        if (order == null)
            return this.NotFound();
        return this.View(order);
    }

    public ActionResult Edit(int id)
    {
        if (id == null || id <= 0)
            return this.NotFound();
        var order = this.orderRepository.GetOrderById(id);
        if (order == null)
            return this.NotFound();
        return this.View(order);
    }

    public ActionResult Delete(int id)
    {
        if (id == null || id <= 0)
            return this.NotFound();
        var order = this.orderRepository.GetOrderById(id);
        if (order == null)
            return this.NotFound();
        return this.View(order);
    }
    public ActionResult Create() { return this.View(); }

    #endregion

    #region CUD

    [HttpPost] [ValidateAntiForgeryToken] public async Task<IActionResult> Create(Order order)
    {
        this.orderRepository.AddOrder(order);
        return this.RedirectToAction("Index");
    }

    [HttpPost] [ValidateAntiForgeryToken] public async Task<IActionResult> Edit(Order order)
    {
        this.orderRepository.UpdateOrder(order);
        return this.RedirectToAction("Index");
    }

    [HttpPost] [ValidateAntiForgeryToken] public async Task<IActionResult> Delete(Order order)
    {
        this.orderRepository.DeleteOrder(order);
        return this.RedirectToAction("Index");
    }

    #endregion
}