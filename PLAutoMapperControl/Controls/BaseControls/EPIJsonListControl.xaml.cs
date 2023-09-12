using PLAutoMapperLib.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace PLAutoMapperControl.Controls.BaseControls
{
    /// <summary>
    /// EPIJsonListControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EPIJsonListControl : UserControl
    {
        public EPIJsonListControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        public string RootFolder { get => @AppDomain.CurrentDomain.BaseDirectory + "\\" + FolName + "\\"; }
        public string RootFile { get => @RootFolder + "\\" + FilName + ".Json"; }

        public string Title { get; set; }
        public string ListviewColTitle1 { get; set; }
        public string ListviewColTitle2 { get; set; }
        public string FolName { get; set; }
        public string FilName { get; set; }

        public List<UserItems> Uitems = new List<UserItems>();
        #region 이벤트
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(RootFolder);
            if (!di.Exists) di.Create();
            FileInfo fi = new FileInfo(RootFile);

            if (fi.Exists)
            {
                List<UserItems> jsonList = Helper.PJson.GetJsonFileList<UserItems>(RootFile);
                lsvList.ItemsSource = jsonList;
                cbItems.ItemsSource = jsonList;
                cbItems.SelectedIndex = 0;
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(RootFile))
                Uitems = Helper.PJson.GetJsonFileList<UserItems>(RootFile);
            Uitems.Add(new UserItems { Item1 = txbText1.Text.ToString(), Item2 = txbText2.Text.ToString() });
            lsvList.ItemsSource = Uitems;
            cbItems.ItemsSource = Uitems;
            Helper.PJson.SaveToJsonFile(Uitems, RootFile);

            txbText1.Text = "";
            txbText2.Text = "";
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            List<string> Items = GetListViewItems();
            if (lsvList.SelectedIndex >= 0)
            {
                Items.RemoveAt(lsvList.SelectedIndex);
                lsvList.ItemsSource = null;
                lsvList.Items.Clear();
                lsvList.ItemsSource = Items;
                cbItems.ItemsSource = Items;
                Helper.PJson.SaveToJsonFile(Items, RootFile);
            }
        }
        #endregion
        #region 메소드
        private List<string> GetListViewItems()
        {
            var IDummy = new List<string>();
            if (lsvList.Items.Count == 0)
            {
                return IDummy;
            }
            else
            {
                foreach (var item in lsvList.Items)
                {
                    IDummy.Add(item.ToString());
                }
            }
            return IDummy;
        }
        #endregion
    }
    public class UserItems
    {
        public string Item1 { get; set; }
        public string Item2 { get; set; }
    }
}
