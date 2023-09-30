using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace Employee.Frontend.Controllers;

public class EmployeeController : Controller
{
    private readonly HttpClient _httpClient;
    public EmployeeController(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient("EmployeeApiBase");

    public async Task<IActionResult> Index() => View(await GetAllEmployee());
   
    public async Task<List<Employeest>> GetAllEmployee()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Employeest>>("Employee");
        return response is not null? response : new List<Employeest>();
    }

    



}
