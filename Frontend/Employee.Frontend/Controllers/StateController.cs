using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Employee.Frontend.Controllers
{
    public class StateController : Controller
    {
        private readonly HttpClient _httpClient;
        public StateController(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient("EmployeeApiBase");
        public async Task<IActionResult> Index() => View(await GetAllState());
       
        public async Task<List<State>> GetAllState()
        {

            var response = await _httpClient.GetFromJsonAsync<List<State>>("State");
            return response is not null ? response : new List<State>();
        }
     
    }
}
