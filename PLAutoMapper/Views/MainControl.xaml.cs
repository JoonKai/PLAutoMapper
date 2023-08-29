using PLAutoMapper.Services;
using PLAutoMapper.ViewModels;
using System.Windows.Controls;

namespace PLAutoMapper.Views
{
    /// <summary>
    /// MainControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainControl : UserControl
    {

        public MainControl()
        {
            InitializeComponent();
            this.DataContext = new MainControlViewModel();
        }
    }
}
