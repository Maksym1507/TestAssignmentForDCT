using Microsoft.Extensions.Options;
using System.Net.Http;
using TestAssignmentForDCT.Config;
using TestAssignmentForDCT.Models;
using TestAssignmentForDCT.Services.Abstractions;

namespace TestAssignmentForDCT.Services
{
    public class CoinService : ICoinService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiOption _options;

        public CoinService(IHttpClientService httpClientService, IOptions<ApiOption> options)
        {
            _httpClientService = httpClientService;
            _options = options.Value;
        }

        public CoinModel[] GetCertainCoinsAsync(int quantity)
        {
            var coinList = _httpClientService.Send<CoinResponse, object>(
                $"{_options.Host}assets?limit={quantity}", HttpMethod.Get);

            return coinList.Data;
        }
    }
}
