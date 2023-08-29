using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PLAutoMapper.Services
{
    public interface IViewService
    {
        void ShowView<TView, TViewModel>(object parameter =null)
            where TView : Window
            where TViewModel : INotifyPropertyChanged;
        void SetControl<TView, TViewModel>(object parameter = null)
            where TView : UserControl
            where TViewModel : INotifyPropertyChanged;

        void ShowPLMapper();
        void ShowPLMapperSetting();

    }
}
