using Doccure.WebUI.Dtos.MedicineDtos;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Doccure.WebUI.Services.MedicineServices
{
    public class MedicineService : IMedicineService
    {
        private readonly HttpClient _httpClient;
        public MedicineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateMedicineAsync(CreateMedicineDto createMedicineDto)
        {
            var jsonData = JsonConvert.SerializeObject(createMedicineDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:7294/api/Medicines", stringContent);
        }
        public async Task DeleteMedicineAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"https://localhost:5000/api/Medicinees?id={id}");
        }
        public async Task<List<ResultMedicineDto>> GetAllMedicinesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7294/api/Medicines");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMedicineDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdMedicineDto> GetMedicineByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"https://localhost:5000/api/Medicinees/GetMedicine?id={id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetByIdMedicineDto>(jsonData);
            return values;
        }
        public async Task UpdateMedicineAsync(UpdateMedicineDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto); StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:5000/api/Medicinees", stringContent);
        }
    }
}
