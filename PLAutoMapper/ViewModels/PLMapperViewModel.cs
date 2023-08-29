using PLAutoMapper.Commands;
using PLAutoMapper.Services;
using System;
using System.Windows.Input;

namespace PLAutoMapper.ViewModels
{
    public class PLMapperViewModel : ViewModelBase
    {
        private readonly IViewService _services;
        public PLMapperViewModel(IViewService services)
        {
            this._services = services;
        }
        #region 커맨드
        public ICommand ShowPLMapperSettingsWindow => new RelayCommand<object>(ShowSettingsWindow);
        #endregion
        #region 커맨드 메소드
        private void ShowSettingsWindow(object obj)
        {
            _services.ShowPLMapperSetting();
        }
        #endregion
    }
}
