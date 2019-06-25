
using CBV.Core.Domain.Shared;
using System.Threading.Tasks;

namespace CBV.Core.Application.Interfaces.Handle
{
    public interface IHttpHandle
    {
        Task<HttpResponse> GetTokenBasic(HttpRequestToken requestToken);
        Task<HttpResponse> PostAsync(string url, object content, string token = null);
        Task<HttpResponse> GetAsync(string url, string token = null);
    }
}
