using PLAutoMapper.Commands;
using PLAutoMapper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PLAutoMapper.ViewModels
{
    public class EPIMainViewModel : ViewModelBase
    {
        private readonly IViewService _viewService;

        public EPIMainViewModel(IViewService viewService)
        {
            _viewService = viewService;
        }
    }
}
