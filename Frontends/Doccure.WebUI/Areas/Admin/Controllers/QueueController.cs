using Doccure.WebUI.Dtos.QueueDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QueueController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public QueueController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7012/api/Queues");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPatientQueueDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultPatientQueueDto>());
        }
    }
}
