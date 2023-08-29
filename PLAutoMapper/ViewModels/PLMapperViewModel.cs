using PLAutoMapper.Commands;
using PLAutoMapper.Services;
using System;
using System.Windows.Input;

namespace PLAutoMapper.ViewModels
{
    public class PLMapperViewModel : ViewModelBase
    {
        private readonly IViewService _services;

        public ICommand ShowPLMapperSettingsWindow => new RelayCommand<object>(ShowSettingsWindow);

        public PLMapperViewModel(IViewService services)
        {
            this._services = services;
        }
        private void ShowSettingsWindow(object obj)
        {
            _services.ShowPLMapperSetting();
        }
    }
}
