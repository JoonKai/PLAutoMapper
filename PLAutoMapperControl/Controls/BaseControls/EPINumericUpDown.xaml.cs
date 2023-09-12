using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PLAutoMapperControl.Controls.BaseControls
{
    /// <summary>
    /// EPINumericUpDown.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EPINumericUpDown : UserControl
    {


        public Brush FontColor
        {
            get { return (Brush)GetValue(FontColorProperty); }
            set { SetValue(FontColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontColorProperty =
            DependencyProperty.Register("FontColor", typeof(Brush), typeof(EPINumericUpDown), new UIPropertyMetadata(Brushes.Black));



        public int TextValue
        {
            get { return (int)GetValue(TextValueProperty); }
            set { SetValue(TextValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextValueProperty =
            DependencyProperty.Register("TextValue", typeof(int), typeof(EPINumericUpDown), new FrameworkPropertyMetadata(0,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public EPINumericUpDown()
        {
            InitializeComponent();
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            int outValue;
            if(txtNum == null)
            {
                return;
            }
            if(!int.TryParse(txtNum.Text, out outValue))
                txtNum.Text =TextValue.ToString();
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            TextValue++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            if(TextValue > 0)
            {
                TextValue--;
            }
        }

        private void txtNum_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                TextValue++;
            }
            else if (e.Delta < 0)
            {
                if (TextValue > 0)
                {
                    TextValue--;
                }
            }
        }
    }
}
