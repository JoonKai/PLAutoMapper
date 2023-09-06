using PLAutoMapper.Commands;
using PLAutoMapper.Models;
using PLAutoMapperLib.Helpers;
using System.Windows.Input;

namespace PLAutoMapper.ViewModels
{
    public class SettingsControlViewModel : ViewModelBase
    {
        #region Props
        public SettingsModel settings { get; set; }

        public string Raw1 
        { 
            get => settings.Raw1;
            set
            {
                settings.Raw1 = value;
                OnPropertyChanged("Raw1");
            } 
        }
        public string Raw2
        {
            get => settings.Raw2;
            set
            {
                settings.Raw2 = value;
                OnPropertyChanged("Raw2");
            }
        }
        public string Backup
        {
            get => settings.Backup;
            set
            {
                settings.Backup = value;
                OnPropertyChanged("Backup");
            }
        }
        public string ConnectionID
        {
            get => settings.UserId;
            set
            {
                settings.UserId = value;
                OnPropertyChanged("ConnectionID");
            }
        }
        public string ConnectionPassword
        {
            get => settings.UserPassword;
            set
            {
                settings.UserPassword = value;
                OnPropertyChanged("ConnectionPassword");
            }
        }
        public string PLID
        {
            get => settings.PLID;
            set
            {
                settings.PLID = value;
                OnPropertyChanged("PLID");
            }
        }
        public string CopyOption
        {
            get => settings.CopyOption;
            set
            {
                settings.CopyOption = value;
                OnPropertyChanged("CopyOption");
            }
        }
        public string AxisFontSize
        {
            get => settings.AxisFontSize;
            set
            {
                settings.AxisFontSize = value;
                OnPropertyChanged("AxisFontSize");
            }
        }
        public string DatabaseName
        {
            get => settings.DatabaseName;
            set
            {
                settings.DatabaseName = value;
                OnPropertyChanged("DatabaseName");
            }
        }
        public string DatabasePort
        {
            get => settings.DatabasePort;
            set
            {
                settings.DatabasePort = value;
                OnPropertyChanged("DatabasePort");
            }
        }
        public string DatabaseID
        {
            get => settings.DatabaseID;
            set
            {
                settings.DatabaseID = value;
                OnPropertyChanged("DatabaseID");
            }
        }
        public string DatabasePassword
        {
            get => settings.DatabasePassword;
            set
            {
                settings.DatabasePassword = value;
                OnPropertyChanged("DatabasePassword");
            }
        }
        #endregion
        public SettingsControlViewModel() 
        {
            settings = new SettingsModel();

            Raw1 = Helper.PIni.Read("NetworkDriverPath", "Raw1");
            Raw2 = Helper.PIni.Read("NetworkDriverPath", "Raw2");
            Backup = Helper.PIni.Read("NetworkDriverPath", "Backup");
            ConnectionID = Helper.PIni.Read("Connection", "ConnectionID");
            ConnectionPassword = Helper.PIni.Read("Connection", "ConnectionPassword");
            PLID = Helper.PIni.Read("Equipment", "PLID");
            CopyOption = Helper.PIni.Read("Etc", "CopyOption");
            AxisFontSize = Helper.PIni.Read("Etc", "AxisFontSize");
            DatabaseName = Helper.PIni.Read("DB", "DatabaseName");
            DatabasePort = Helper.PIni.Read("DB", "DatabasePort");
            DatabaseID = Helper.PIni.Read("DB", "DatabaseID");
            DatabasePassword = Helper.PIni.Read("DB", "DatabasePassword");
        }
        public ICommand SettingsSave => new RelayCommand<object>(SaveSettings);

        private void SaveSettings(object obj)
        {
            Helper.PIni.Write("NetworkDriverPath", "Raw1", Raw1);
            Helper.PIni.Write("NetworkDriverPath", "Raw2", Raw2);
            Helper.PIni.Write("NetworkDriverPath", "Backup", Backup);
            Helper.PIni.Write("Connection", "ConnectionID", ConnectionID);
            Helper.PIni.Write("Connection", "ConnectionPassword", ConnectionPassword);
            Helper.PIni.Write("Equipment", "PLID", PLID);
            Helper.PIni.Write("Etc", "CopyOption", CopyOption);
            Helper.PIni.Write("Etc", "AxisFontSize", AxisFontSize);
            Helper.PIni.Write("DB", "DatabaseName", DatabaseName);
            Helper.PIni.Write("DB", "DatabasePort", DatabasePort);
            Helper.PIni.Write("DB", "DatabaseID", DatabaseID);
            Helper.PIni.Write("DB", "DatabasePassword", DatabasePassword);

        }
    }
}
