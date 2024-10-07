using Cliente_REST_Alimentos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Cliente_REST_Alimentos.Controllers
{
    public class AlimentosController : Controller
    {
        //Inyectando el servicio HttpClient
        private readonly HttpClient _httpClient;

        public AlimentosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:63877/api");
        }

        //Metodo que muestra la la lista entera de alimentos
        public async Task<IActionResult> Index()
        {
            List<AlimentosCl>? lsAlimentos = new List<AlimentosCl>();

            HttpResponseMessage request = await _httpClient.GetAsync("api/Alimentos/listar_todo");
            
            if(request.IsSuccessStatusCode)
            {
                string result = await request.Content.ReadAsStringAsync();
                lsAlimentos = JsonConvert.DeserializeObject<List<AlimentosCl>>(result);
            }
            else
            {
                throw new Exception("Error de comunicacion");
            }

            return View(lsAlimentos);

        }

    }
}
