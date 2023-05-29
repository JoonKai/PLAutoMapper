using PLAutoMapperControl.Model.EPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PLAutoMapper.ViewModels
{
    public class SettingViewModel : DependencyObject
    {
        #region DependencyProperty
        public ObservableCollection<PL> PLNameList
        {
            get { return (ObservableCollection<PL>)GetValue(PLNameListProperty); }
            set { SetValue(PLNameListProperty, value); }
        }
        public static readonly DependencyProperty PLNameListProperty =
            DependencyProperty.Register("PLNameList", typeof(ObservableCollection<PL>), typeof(SettingViewModel), new PropertyMetadata(new ObservableCollection<PL>()));

        public ObservableCollection<NetworkDriver> NetworkDriverList
        {
            get { return (ObservableCollection<NetworkDriver>)GetValue(NetworkDriverListProperty); }
            set { SetValue(NetworkDriverListProperty, value); }
        }
        public static readonly DependencyProperty NetworkDriverListProperty =
            DependencyProperty.Register("NetworkDriverList", typeof(ObservableCollection<NetworkDriver>), typeof(SettingViewModel), new PropertyMetadata(new ObservableCollection<NetworkDriver>()));


        #endregion
    }
}
