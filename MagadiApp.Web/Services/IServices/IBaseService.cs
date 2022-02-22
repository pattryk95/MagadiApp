using MagadiApp.Web.Models;
using MagadiApp.Web.Models;

namespace MagadiApp.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
