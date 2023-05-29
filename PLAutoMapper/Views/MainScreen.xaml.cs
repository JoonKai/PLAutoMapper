using EMPL.data;
using EMPL.susceptor;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PLAutoMapper.Views
{
    /// <summary>
    /// MainScreen.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
        }
        #region 이벤트
        private void settingOpen_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow settingWindow = new SettingWindow();
            settingWindow.ShowDialog();
        }
        #endregion
        private void plplusOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PL+ files (*.PL+)|*.PL+";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                plplusTextbox.Text = openFileDialog.FileName;
                OpenPLData(openFileDialog.FileName);
            }
        }
        private void OpenPLData(string filename)
        {
            PLFactory mgrFactory = new PLFactory();
            //PL플러스 읽어들이는 코드 생성 필요.
            SusViewer.CurrentPLFactory = mgrFactory;
        }
        /// <summary>
        /// OpenSusFile
        /// </summary>
        /// <param name="fileName"></param>
        private void PutOnScreen(string filename)
        {
            if (!File.Exists(filename))
            {
                int num = (int)MessageBox.Show("Can't find file.");
            }
            else
            {
                SusceptorMgr susceptorMgr = SusceptorMgr.LoadFile(filename);
                if (susceptorMgr == null)
                    return;
                SusViewer.SetSusceptorManager(susceptorMgr);
                SusViewer.CurrentPLFactory = null;
            }
        }

        private void susOpen3_Click(object sender, RoutedEventArgs e)
        {
            susTextbox3.Text = SusFileOpen();
        }

        private void susOpen2_Click(object sender, RoutedEventArgs e)
        {
            susTextbox2.Text = SusFileOpen();
        }

        private void susOpen1_Click(object sender, RoutedEventArgs e)
        {
            var sus = SusFileOpen();
            susTextbox1.Text = sus;
            PutOnScreen(sus);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string SusFileOpen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "sus files (*.sus)|*.sus";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
                return openFileDialog.FileName;
            return "";
             
        }
    }
}
