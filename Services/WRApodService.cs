using Newtonsoft.Json;
using WRApiNasa.Models;

namespace WRApiNasa.Services
{
    public class WRApodService
    {
        public async Task<WRApod> GetImage(DateTime dt)
        {
            WRApod dto = null;
            HttpResponseMessage response;
            string requestUrl = $"https://api.nasa.gov/planetary/apod?date={dt.ToString("yyyy-MM-dd")}&api_key=vzemV2BKM7LT9MHLd50MoGFUY4A8Y0yaOcm5w2UA\r\n";
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                HttpClient client = new HttpClient();
                response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dto = JsonConvert.DeserializeObject<WRApod>(json);
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
