using System;
using System.Windows;
using System.Windows.Forms;

namespace PLAutoMapper
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Mapper : Window
    {
        public Mapper()
        {
            InitializeComponent();
            //SetNotification();
        }

        //private void SetNotification()
        //{
        //    NotifyIcon ni = new NotifyIcon();

        //    ni.Icon = new System.Drawing.Icon("../../flickr.ico");
        //    ni.Visible = true;

        //    // NotifyIcon에 더블 클릭 이벤트 추가
        //    ni.DoubleClick += delegate (object sender, EventArgs eventArgs)
        //    {
        //        // 화면을 최소화 상태에서 다시 보여줍니다.
        //        this.Show();
        //        // 화면 상태를 Normal로 설정합니다.
        //        this.WindowState = WindowState.Normal;
        //    };
        //    ni.ContextMenu = SetContextMenu(ni);
        //    ni.Text = "PLMapViewer";
        //}
        //private ContextMenu SetContextMenu(NotifyIcon ni)
        //{
        //    ContextMenu menu = new ContextMenu();

        //    MenuItem item1 = new MenuItem();
        //    item1.Text = "열기";
        //    item1.Click += delegate (object click, EventArgs eventArgs)
        //    {
        //        this.Show();
        //        this.WindowState = WindowState.Normal;
        //    };
        //    menu.MenuItems.Add(item1);

        //    MenuItem item2 = new MenuItem();
        //    item2.Text = "닫기";
        //    item2.Click += delegate (object click, EventArgs eventArgs)
        //    {
        //        System.Windows.Application.Current.Shutdown();
        //        ni.Dispose();
        //    };
        //    menu.MenuItems.Add(item2);

        //    return menu;
        //}
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        private void settingOpen_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
