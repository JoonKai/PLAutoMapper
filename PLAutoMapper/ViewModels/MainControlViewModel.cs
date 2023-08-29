using PLAutoMapper.Commands;
using PLAutoMapper.Services;
using System.Windows;
using System.Windows.Input;

namespace PLAutoMapper.ViewModels
{
    public class MainControlViewModel : ViewModelBase
    {
        private readonly IViewService _services;


        public MainControlViewModel(IViewService services)
        {
            this._services = services;
        }
        public ICommand SusOpen =>new RelayCommand<object>(OpenSus);

        private void OpenSus(object _)
        {
            MessageBox.Show("손준석 최고");
        }
    }
}
