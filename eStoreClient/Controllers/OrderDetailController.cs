namespace eStoreClient.Controllers;

using System.Net.Http.Headers;
using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

public class OrderDetailController : Controller
{
    private readonly HttpClient _httpClient = new HttpClient();
    private          string     _baseUrl    = "http://localhost:5172/OrderDetail";
    
    public OrderDetailController()
    {
        this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    #region GET

    private readonly OrderDetailRepository orderRepository = new OrderDetailRepository();
    
    public async Task<IActionResult> Index(int? id)
    {
        var list = this.orderRepository.GetAllOrderDetails().Where(x=>x.OrderId == id).ToList();

        if (list.Count <= 0) return this.NotFound();
        Console.WriteLine("AAAAAAAAAAAA");
        return View(list);
    }

    public ActionResult Detail(int? Oid, int? Pid)
    {
        Console.WriteLine(Oid + " " + Pid);
        if (Oid == null || Oid <= 0 || Pid == null || Pid <= 0)
            return this.NotFound();
        var order = this.orderRepository.GetOrderDetailById(Oid.Value, Pid.Value);
        if (order == null)
            return this.NotFound();
        return this.View(order);
    }

    public ActionResult Edit(int? Oid, int? Pid)
    {
        if (Oid == null || Oid <= 0 || Pid == null || Pid <= 0)
            return this.NotFound();
        var order = this.orderRepository.GetOrderDetailById(Oid.Value, Pid.Value);
        if (order == null)
            return this.NotFound();
        return this.View(order);
    }

    public ActionResult Delete(int? Oid, int? Pid)
    {
        if (Oid == null || Oid <= 0 || Pid == null || Pid <= 0)
            return this.NotFound();
        var order = this.orderRepository.GetOrderDetailById(Oid.Value, Pid.Value);
        if (order == null)
            return this.NotFound();
        return this.View(order);
    }
    public ActionResult Create() { return this.View(); }

    #endregion

    #region CUD

    [HttpPost] [ValidateAntiForgeryToken] public async Task<IActionResult> Create(OrderDetail order)
    {
        this.orderRepository.AddOrderDetail(order);
        return this.RedirectToAction("Index");
    }

    [HttpPost] [ValidateAntiForgeryToken] public async Task<IActionResult> Edit(OrderDetail order)
    {
        this.orderRepository.UpdateOrderDetail(order);
        return this.RedirectToAction("Index");
    }

    [HttpPost] [ValidateAntiForgeryToken] public async Task<IActionResult> Delete(OrderDetail order)
    {
        this.orderRepository.DeleteOrderDetail(order);
        return this.RedirectToAction("Index");
    }

    #endregion
}