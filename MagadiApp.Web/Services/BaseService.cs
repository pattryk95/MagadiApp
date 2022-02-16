using MagadiApp.Web.Models;
using MagadiApp.Web.Models.Dto;
using MagadiApp.Web.Services.IServices;

namespace MagadiApp.Web.Services
{
    public class BaseService : IBaseService

    {
        public ResponseDto responseModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            throw new NotImplementedException();
        }
    }
}
