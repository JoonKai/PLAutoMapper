using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLAutoMapper.Views.LayoutControl
{
    /// <summary>
    /// StatusBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatusBar : UserControl
    {
        public static new readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(StatusBar), new UIPropertyMetadata(Brushes.Transparent));
        public static readonly DependencyProperty DigitalTimeProperty = DependencyProperty.Register("DigitalTime", typeof(DateTime), typeof(StatusBar), new FrameworkPropertyMetadata(DateTime.Now));
        public DateTime DigitalTime
        {
            get { return (DateTime)GetValue(DigitalTimeProperty); }
            set { SetValue(DigitalTimeProperty, value); }
        }


        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }



        public StatusBar()
        {
            InitializeComponent();
        }
    }
}
