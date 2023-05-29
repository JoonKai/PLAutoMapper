using PLAutoMapperLib.Helpers;
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

namespace PLAutoMapperControl.Controls.BaseControls
{
    /// <summary>
    /// EPIAddItemsListControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EPIAddItemsListControl : UserControl
    {
        public EPIAddItemsListControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        #region ////////////////////////////////////////////////////Properties
        public string RootFolder { get => @AppDomain.CurrentDomain.BaseDirectory + "\\" + FolName + "\\"; }
        public string RootFile { get => @RootFolder + "\\" + FilName + ".Json"; }

        public string Title { get; set; }
        public string FolName { get; set; }
        public string FilName { get; set; }


        public static readonly DependencyProperty LWidthProperty = DependencyProperty.Register("LWidth", typeof(double), typeof(EPIAddItemsListControl), new PropertyMetadata(50.0));
        public static new readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(EPIAddItemsListControl), new PropertyMetadata(Brushes.Black));
        public static readonly DependencyProperty FontColorProperty = DependencyProperty.Register("FontColor", typeof(Brush), typeof(EPIAddItemsListControl), new PropertyMetadata(Brushes.Black));
        public static readonly DependencyProperty TBBorderBrushProperty = DependencyProperty.Register("TBBorderBrush", typeof(Brush), typeof(EPIAddItemsListControl), new PropertyMetadata(Brushes.Black));


        public Brush TBBorderBrush
        {
            get { return (Brush)GetValue(TBBorderBrushProperty); }
            set { SetValue(TBBorderBrushProperty, value); }
        }


        public double LWidth
        {
            get { return (double)GetValue(LWidthProperty); }
            set { SetValue(LWidthProperty, value); }
        }
        public new Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }
        public Brush FontColor
        {
            get { return (Brush)GetValue(FontColorProperty); }
            set { SetValue(FontColorProperty, value); }
        }



        #endregion
        #region ////////////////////////////////////////////////이벤트
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            DirectoryInfo di = new DirectoryInfo(RootFolder);
            if (!di.Exists) di.Create();
            FileInfo fi = new FileInfo(RootFile);

            if (fi.Exists)
            {
                List<string> jsonList = Helper.PJson.GetJsonFileList<string>(RootFile);
                lsbList.ItemsSource = jsonList;
                cbItems.ItemsSource = jsonList;
                cbItems.SelectedIndex = 2;
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var jsonFileName = RootFile;
            List<string> items = GetListViewItems();
            var result = AddItem(items);

            lsbList.ItemsSource = result;
            lsbList.Items.Refresh();
            Helper.PJson.SaveToJsonFile(result, jsonFileName);

            txbText.Text = "";
            cbItems.ItemsSource = result;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            List<string> Items = GetListViewItems();
            if (lsbList.SelectedIndex >= 0)
            {
                Items.RemoveAt(lsbList.SelectedIndex);
                lsbList.ItemsSource = null;
                lsbList.Items.Clear();
                lsbList.ItemsSource = Items;
                cbItems.ItemsSource = Items;
                Helper.PJson.SaveToJsonFile(Items, RootFile);
            }
        }
        #endregion
        #region ////////////////////////////////////////////메서드
        private List<string> AddItem(List<string> _items)
        {
            if (txbText.Text != "" && !_items.Contains(txbText.Text))
            {
                _items.Add(txbText.Text.ToUpper().Trim().ToString());
            }
            return _items;
        }
        private List<string> GetListViewItems()
        {
            var IDummy = new List<string>();
            if (lsbList.Items.Count == 0)
            {
                return IDummy;
            }
            else
            {
                foreach (var item in lsbList.Items)
                {
                    IDummy.Add(item.ToString());
                }
            }
            return IDummy;
        }
        #endregion
    }
}
