using Microsoft.Extensions.DependencyInjection;
using PLAutoMapper.Services;
using PLAutoMapper.ViewModels;
using PLAutoMapper.Views;
using System;
using System.Threading;
using System.Windows;

namespace PLAutoMapper
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        //Mutex mutex;
        private readonly IServiceProvider _services = null;
        public App()
        {
            _services = ConfigureService();
        }

        private IServiceProvider ConfigureService()
        {
            IServiceCollection services = new ServiceCollection();
            //Views
            services.AddSingleton<PLMapper>();
            services.AddTransient<PLMapperSettingsWindow>();
            //ViewModels
            services.AddSingleton<PLMapperViewModel>();
            services.AddTransient<PLMapperSettingsWindowViewModel>();
            //Services
            services.AddSingleton<IViewService, ViewService>();

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var viewService = (IViewService)_services.GetService(typeof(IViewService));
            viewService.ShowPLMapper();

            //string mutexName = "program";
            //bool createNew;

            //mutex = new Mutex(true, mutexName, out createNew);

            //if (!createNew)
            //{
            //    Shutdown();
            //}
        }
    }
}
