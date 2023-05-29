using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using PLAutoMapperLib.Extensions;

namespace PLAutoMapper.Views.LayoutControl
{
    /// <summary>
    /// TitleBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TitleBar : UserControl
    {


        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TitleBar), new PropertyMetadata(""));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        private Window _parentWindow;

        public Window ParentWindow
        {
            get
            {
                if (_parentWindow == null)
                {
                    _parentWindow = this.FindParent<Window>();
                }
                return _parentWindow;
            }
            set { _parentWindow = value; }
        }
        public TitleBar()
        {
            InitializeComponent();
            btnExit.Click += BtnExit_Click;
            btnMinimize.Click += BtnMinimize_Click;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.WindowState = WindowState.Minimized;
            ParentWindow.ResizeMode = ResizeMode.CanResizeWithGrip;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.Close();
        }
    }
}
