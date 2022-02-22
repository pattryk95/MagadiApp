using MagadiApp.Web.Models;
using MagadiApp.Web.Services.IServices;

namespace MagadiApp.Web.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CategoryService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateCategoryAsync<T>(CategoryDto categoryDto)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = categoryDto,
                Url = SD.ProductAPIBase + "/api/categories",
                AccessToken = ""

            });   
        }

        public async Task<T> DeleteCategoryAsync<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/categories" + id,
                AccessToken = ""

            });
        }

        public async Task<T> GetAllCategoriesAsync<T>()   
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/categories",
                AccessToken = ""

            });
        }

        public async Task<T> GetCategoryByIdAsync<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/categories" + id,
                AccessToken = ""

            });
        }

        public async Task<T> UpdateCategoryAsync<T>(CategoryDto categoryDto)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.ProductAPIBase + "/api/categories",
                AccessToken = ""

            });
        }
    }
}
