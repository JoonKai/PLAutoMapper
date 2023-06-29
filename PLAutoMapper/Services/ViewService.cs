using PLAutoMapper.ViewModels;
using PLAutoMapper.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PLAutoMapper.Services
{
    public class ViewService : IViewService
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void ShowMainView()
        {
            ShowView<EPIMainView, EPIMainViewModel>();
            ShowUserControl<MainScreen, MainScreenViewModel>();
        }

        public void ShowSettingView()
        {
            if (!ActivateView<EPISettingView>())
            {
                ShowView<EPISettingView, EPISettingViewModel>();
            }
        }

        private bool ActivateView<TView>() where TView : Window
        {
            //창이 하나만 켜지도록 함
            IEnumerable<Window> windows = Application.Current.Windows.OfType<TView>();

            if(windows.Any())
            {
                windows.ElementAt(0).Activate();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowView<TView, TViewModel>(object parameter = null)
            where TView : Window
            where TViewModel : INotifyPropertyChanged
        {
            var viewModel = (INotifyPropertyChanged)_serviceProvider.GetService(typeof(TViewModel));
            var view = (Window)_serviceProvider.GetService(typeof(TView));

            if (parameter != null && viewModel is IParameterReceiver parameterReceiver)
            {
                parameterReceiver.ReceiveParameter(parameter);
            }

            view.DataContext = viewModel;
            view.Show();
        }

        public void ShowUserControl<TView, TViewModel>(object parameter = null)
            where TView : UserControl
            where TViewModel : INotifyPropertyChanged
        {
            var viewModel = (INotifyPropertyChanged)_serviceProvider.GetService(typeof(TViewModel));
            var view = (UserControl)_serviceProvider.GetService(typeof(TView));
            view.DataContext = viewModel;
        }
    }
}
