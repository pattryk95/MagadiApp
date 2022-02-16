using MagadiApp.Web.Models;
using MagadiApp.Web.Models.Dto;

namespace MagadiApp.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
