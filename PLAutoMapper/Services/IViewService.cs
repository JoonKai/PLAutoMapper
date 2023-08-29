using System.ComponentModel;
using System.Windows;

namespace PLAutoMapper.Services
{
    public interface IViewService
    {
        void ShowView<TView, TViewModel>(object parameter =null)
            where TView : Window
            where TViewModel : INotifyPropertyChanged;
        void ShowPLMapper();
        void ShowPLMapperSetting();

    }
}
