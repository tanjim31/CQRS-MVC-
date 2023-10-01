using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> AddOrEdit(int Id)
        {
            var response = await _httpClient.GetAsync("Country");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var countryList = JsonConvert.DeserializeObject<List<Country>>(content);
                ViewData["countryId"] = new SelectList(countryList, "Id", "CountryName");

            }

            if (Id == 0)
            {
                //Create Form
                ViewBag.ButtonText = "Create";  //for Create Page
                return View(new State());

            }
           
            else
            {
                //Get By Id
                var data = await _httpClient.GetAsync($"State/{Id}");
                if (data.IsSuccessStatusCode)
                {
                    var result = await data.Content.ReadFromJsonAsync<State>();
                    ViewBag.ButtonText = "Save"; //for Create Page
                    return View(result);
                }
            }
            return View(new State());

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddOrEdit(int Id, State state)
        {
            if (ModelState.IsValid)
            {
                if (Id == 0) //id==0
                {
                    var result = await _httpClient.PostAsJsonAsync("State", state);
                    if (result.IsSuccessStatusCode) return RedirectToAction("Index");
                }
                else
                {
                    var result = await _httpClient.PutAsJsonAsync($"State/{Id}", state);
                    if (result.IsSuccessStatusCode) return RedirectToAction("Index");
                }
            }
            return View(new State());
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _httpClient.DeleteAsync($"State/{Id}");
            if (data.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}

