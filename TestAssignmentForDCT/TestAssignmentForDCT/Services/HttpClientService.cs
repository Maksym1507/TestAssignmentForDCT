using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using TestAssignmentForDCT.Services.Abstractions;

namespace TestAssignmentForDCT.Services
{
    public class HttpClientService : IHttpClientService
    {
        public TResponse Send<TResponse, TRequest>(string url, HttpMethod method, TRequest? content = null) where TRequest : class
        {
            using (var client = new HttpClient())
            {
                var httpMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = method
                };

                if (content != null)
                {
                    httpMessage.Content =
                        new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                }

                var result = client.Send(httpMessage);

                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
                    return response!;
                }

                return default(TResponse)!;
            }
        }
    }
}
