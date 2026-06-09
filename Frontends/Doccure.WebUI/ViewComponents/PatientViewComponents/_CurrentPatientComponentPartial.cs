using Doccure.WebUI.Dtos.QueueDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Doccure.WebUI.ViewComponents.PatientViewComponents
{
    public class _CurrentPatientComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CurrentPatientComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7012/api/queues/current");
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultPatientQueueDto>(json);
            return View(value);
        }
    }
}
