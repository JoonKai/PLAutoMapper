using EMPL.data;
using EMPL.susceptor;
using Microsoft.Win32;
using PLAutoMapper.Services;
using PLAutoMapper.ViewModels;
using System;
using System.IO;
using System.Windows;
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
        }

        private void susOpen1_Click(object sender, RoutedEventArgs e)
        {
            var sus = SusFileOpen();
            susTextbox1.Text = sus;
            PutOnScreen(sus);
        }

        private void susOpen2_Click(object sender, RoutedEventArgs e)
        {
            susTextbox2.Text = SusFileOpen();
        }

        private void susOpen3_Click(object sender, RoutedEventArgs e)
        {
            susTextbox3.Text = SusFileOpen();
        }

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
