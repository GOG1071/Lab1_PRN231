namespace eStoreClient.Controllers;

using System.Net.Http.Headers;
using System.Text.Json;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;

public class MemberController : Controller
{
    private readonly HttpClient _httpClient = new HttpClient();
    private string _baseUrl = "https://localhost:5001/Member";

    public MemberController()
    {
        this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public async Task<IActionResult> Index()
    {
        var response = await this._httpClient.GetAsync(this._baseUrl);
        var stringData = await response.Content.ReadAsStringAsync();
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        var members = JsonSerializer.Deserialize<List<Member>>(stringData, options);
        return View(members);
    }
}