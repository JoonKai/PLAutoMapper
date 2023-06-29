using PLAutoMapper.Commands;
using PLAutoMapper.Services;
using System;
using System.Windows.Input;

namespace PLAutoMapper.ViewModels
{
    public class MainScreenViewModel : ViewModelBase
    {
        private readonly IViewService _viewService;
        public string TestItem { get; set; }
        public MainScreenViewModel(IViewService viewService)
        {
            TestItem = "손준석";
            _viewService = viewService;
        }
        public ICommand ShowSettingViewCommand => new RelayCommand<object>(ShowSettingView);

        private void ShowSettingView(object _)
        {
            _viewService.ShowSettingView();
        }
    }
}
