using PLAutoMapper.ViewModels;
using System.Windows.Controls;

namespace PLAutoMapper.Views
{
    /// <summary>
    /// SettingsControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
            this.DataContext = new SettingsControlViewModel();
        }
    }
}
