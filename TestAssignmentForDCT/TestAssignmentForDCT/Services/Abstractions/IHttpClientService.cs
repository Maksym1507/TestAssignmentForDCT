using System.Net.Http;
using System.Threading.Tasks;

namespace TestAssignmentForDCT.Services.Abstractions
{
    public interface IHttpClientService
    {
        TResponse Send<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null)
        where TRequest : class;
    }
}
