using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using GymApp.API;

namespace GymApp.API
{
    internal class ConsumirApi
    {
        private readonly HttpClient _client;

        public ConsumirApi()
        {
            _client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30) 
            };
        }

        public async Task<string> SearchByKeywordAsync(string keyword)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://myfitnesspal2.p.rapidapi.com/searchByKeyword?keyword={Uri.EscapeDataString(keyword)}"),
                Headers =
        {
            { "x-rapidapi-key", "4a383d5357msh046062d17f97c98p1991b6jsn9775d188d2a4" },
            { "x-rapidapi-host", "myfitnesspal2.p.rapidapi.com" },
        },
            };

            using (var response = await _client.SendAsync(request))
            {
                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error: {response.StatusCode} - {errorMessage}");
                }

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
} 