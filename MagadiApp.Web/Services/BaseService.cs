using MagadiApp.Web.Models;
using MagadiApp.Web.Models.Dto;
using MagadiApp.Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace MagadiApp.Web.Services
{
    public class BaseService : IBaseService

    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }

        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MagadiAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data!=null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), 
                        Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.GET:
                        break;
                    case SD.ApiType.POST:
                        break;
                    case SD.ApiType.PUT:
                        break;
                    case SD.ApiType.DELETE:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
