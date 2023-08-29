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


        public void ShowPLMapper()
        {
            ShowView<PLMapper, PLMapperViewModel>();
        }
        public void SetMainControl()
        {
            SetControl<MainControl, MainControlViewModel>();
        }

        public void ShowPLMapperSetting()
        {
            if (!ActivateView<PLMapperSettingsWindow>())
            {
                ShowView<PLMapperSettingsWindow, PLMapperSettingsWindowViewModel>();
            }
        }

        private bool ActivateView<TView>() where TView : Window
        {
            IEnumerable<TView> windows = Application.Current.Windows.OfType<TView>();

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
        #region View + ViewModel
        public void SetControl<TView, TViewModel>(object parameter = null)
            where TView : UserControl
            where TViewModel : INotifyPropertyChanged
        {
            var view = (UserControl)_serviceProvider.GetService(typeof(TView));
            var viewModel = (INotifyPropertyChanged)_serviceProvider.GetService(typeof(TViewModel));

            //매개변수 역할 확인
            if (parameter != null && viewModel is IParameterReceiver parameterReceiver)
            {
                parameterReceiver.ReceiveParameter(parameter);
            }
            view.DataContext = viewModel;
        }
        public void ShowView<TView, TViewModel>(object parameter = null)
            where TView : Window
            where TViewModel : INotifyPropertyChanged
        {
            var view = (Window)_serviceProvider.GetService(typeof(TView));
            var viewModel = (INotifyPropertyChanged)_serviceProvider.GetService(typeof(TViewModel));

            //매개변수 역할 확인
            if (parameter != null && viewModel is IParameterReceiver parameterReceiver)
            {
                parameterReceiver.ReceiveParameter(parameter);
            }


            view.DataContext = viewModel;
            view.Show();
        }

        #endregion
    }
}
