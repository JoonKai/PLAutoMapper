using System.Windows;
using System.Windows.Controls;

namespace PLAutoMapperControl.Controls.BaseControls
{
    /// <summary>
    /// EPINumericUpDown.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EPINumericUpDown : UserControl
    {
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
