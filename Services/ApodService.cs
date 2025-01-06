using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WRApiNasa.Models;

namespace WRApiNasa.Services
{
    internal class ApodService
    {
        public async Task<Apod> GetImage(DateTime dt)
        {
            Apod dto = null;
            HttpResponseMessage response;
            string requestUrl = $"https://api.nasa.gov/planetary/apod?date={dt.ToString("2024-0106")}&api_key=vzemV2BKM7LT9MHLd50MoGFUY4A8Y0yaOcm5w2UA";
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                HttpClient client = new HttpClient();
                response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dto = JsonConvert.DeserializeObject<Apod>(json);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return dto;
        }
    }
}
