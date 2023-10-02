using Employee.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public async Task<IActionResult> AddOrEdit(int Id)
    {
        var response= await _httpClient.GetAsync("Country");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var countryList= JsonConvert.DeserializeObject<List<Country>>(content);
            ViewData["countryId"] = new SelectList(countryList, "Id", "CountryName");
        }
        var response2 = await _httpClient.GetAsync("State");
        if (response.IsSuccessStatusCode)
        {
            var content= await response2.Content.ReadAsStringAsync();
            var countryList= JsonConvert.DeserializeObject<List<State>>(content);
            ViewData["stateId"] = new SelectList(countryList, "Id", "StateName");

        }


        if (Id == 0)
        {
            //Create Form
            ViewBag.ButtonText = "Create";  //for showing indicate message on frontend view
            return View(new Employeest());
        }
        else
        {
            //Get By Id
            var data = await _httpClient.GetAsync($"Employee/{Id}");
            if (data.IsSuccessStatusCode)
            {
                var result = await data.Content.ReadFromJsonAsync<Employeest>();
                ViewBag.ButtonText = "Save"; //for showing indicate message on frontend view
                return View(result);
            }
        }
        return View(new Employeest());


    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> AddOrEdit(int Id, Employeest employee)
    {
        if (ModelState.IsValid)
        {
            if (Id == 0) //id==0
            {
                var result = await _httpClient.PostAsJsonAsync("Employee", employee);
                if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            }
            else
            {
                var result = await _httpClient.PutAsJsonAsync($"Employee/{Id}", employee);
                if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            }
        }
        return View(new Employeest());
    }

    public async Task<IActionResult> Delete(int Id)
    {
        var data = await _httpClient.DeleteAsync($"Employee/{Id}");
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
