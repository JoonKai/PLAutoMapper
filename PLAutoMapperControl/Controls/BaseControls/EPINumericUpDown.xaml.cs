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



        public string TextValue
        {
            get { return (string)GetValue(TextValueProperty); }
            set { SetValue(TextValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextValueProperty =
            DependencyProperty.Register("TextValue", typeof(string), typeof(EPINumericUpDown), new FrameworkPropertyMetadata("",FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        private int numValue =0;

        public int NumValue
        {
            get { return numValue; }
            set 
            { 
                numValue = value;
                txtNum.Text = value.ToString();
            }
        }

        public EPINumericUpDown()
        {
            InitializeComponent();
            txtNum.Text = NumValue.ToString();
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtNum == null)
            {
                return;
            }
            if(!int.TryParse(txtNum.Text, out numValue))
                txtNum.Text =numValue.ToString();
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            if(NumValue > 0)
            {
                NumValue--;
            }
        }

        private void txtNum_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                NumValue++;
            }
            else if (e.Delta < 0)
            {
                if (NumValue > 0)
                {
                    NumValue--;
                }
            }
        }
    }
}
