using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PLAutoMapper.Services
{
    public interface IViewService
    {
        void ShowView<TView, TViewModel>(object parameter = null)
            where TView : Window
            where TViewModel : INotifyPropertyChanged;
        void ShowUserControl<TView, TViewModel>(object parameter = null)
            where TView : UserControl
            where TViewModel : INotifyPropertyChanged;
        void ShowMainView();
        void ShowSettingView();
    }
}
