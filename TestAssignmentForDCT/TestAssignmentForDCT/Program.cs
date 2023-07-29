using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TestAssignmentForDCT.Config;
using TestAssignmentForDCT.Services;
using TestAssignmentForDCT.Services.Abstractions;
using TestAssignmentForDCT.ViewModels;

namespace TestAssignmentForDCT
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));
                    services.AddSingleton<App>();
                    services.AddSingleton<MainWindow>();
                    services.AddTransient<IHttpClientService, HttpClientService>();
                    services.AddTransient<ICoinService, CoinService>();
                    services.AddTransient<MainWindowViewModel>();
                })
                .Build();

            var app = host.Services.GetService<App>();
            app?.Run();
        }
    }
}
