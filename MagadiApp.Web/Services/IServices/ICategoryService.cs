using MagadiApp.Web.Models;

namespace MagadiApp.Web.Services.IServices
{
    public interface ICategoryService : IBaseService
    {
        Task<T> GetAllCategoriesAsync<T>();
        Task<T> GetCategoryByIdAsync<T>(int id);
        Task<T> CreateCategoryAsync<T>(CategoryDto categoryDto);
        Task<T> UpdateCategoryAsync<T>(CategoryDto categoryDto);
        Task<T> DeleteCategoryAsync<T>(int id);
    }
}
