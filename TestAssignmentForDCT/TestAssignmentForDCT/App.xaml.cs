using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using TestAssignmentForDCT;
using TestAssignmentForDCT.Config;
using TestAssignmentForDCT.Services.Abstractions;
using TestAssignmentForDCT.Services;
using TestAssignmentForDCT.ViewModels;

namespace Wpf_Using_ViewModels_in_MVVM
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            });

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            services.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));
            services.AddTransient<IHttpClientService, HttpClientService>();
            services.AddTransient<ICoinService, CoinService>();
            services.AddSingleton<MainWindowViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = _serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }
    }
}
