using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Vakcina.WPF.Repositories;
using Vakcina.WPF.ViewModels;

namespace Vakcina.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // TODO: 09. XAML fájl, Login ablakkal való indítás
        public App()
        {
            Services = ConfigureServices();
            InitializeComponent();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<VakcinaContext>();
            services.AddScoped<OltasRepository>();
            services.AddScoped<FelhasznaloRepository>();

            services.AddTransient<LoginViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<OltasViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
