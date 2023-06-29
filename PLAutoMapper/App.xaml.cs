using Microsoft.Extensions.DependencyInjection;
using PLAutoMapper.Services;
using PLAutoMapper.ViewModels;
using PLAutoMapper.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PLAutoMapper
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _services = null;
        private IServiceProvider ConfigurationService()
        {
            IServiceCollection services = new ServiceCollection();

            //Views
            services.AddSingleton<EPIMainView>();
            services.AddTransient<EPISettingView>();
            services.AddTransient<MainScreen>();

            //Service
            services.AddSingleton<IViewService, ViewService>();

            //ViewModel
            services.AddSingleton<EPIMainViewModel>();
            services.AddTransient<EPISettingViewModel>();
            services.AddTransient<MainScreenViewModel>();

            return services.BuildServiceProvider();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var viewService = (IViewService)_services.GetService(typeof(IViewService));
            viewService.ShowMainView();
        }

        public App()
        {
            _services = ConfigurationService();
        }

    }
}
