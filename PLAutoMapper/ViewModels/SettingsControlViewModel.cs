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
        #endregion
        public SettingsControlViewModel() 
        {
            settings = new SettingsModel();

            Raw1 = Helper.PIni.Read("NetworkDriverPath", "Raw1");
            Raw2 = Helper.PIni.Read("NetworkDriverPath", "Raw2");
            Backup = Helper.PIni.Read("NetworkDriverPath", "Backup");
            ConnectionID = Helper.PIni.Read("Connection", "ConnectionID");
            ConnectionPassword = Helper.PIni.Read("Connection", "ConnectionPassword");
        }
        public ICommand SettingsSave => new RelayCommand<object>(SaveSettings);

        private void SaveSettings(object obj)
        {
            Helper.PIni.Write("NetworkDriverPath", "Raw1", Raw1);
            Helper.PIni.Write("NetworkDriverPath", "Raw2", Raw2);
            Helper.PIni.Write("NetworkDriverPath", "Backup", Backup);
            Helper.PIni.Write("Connection", "ConnectionID", ConnectionID);
            Helper.PIni.Write("Connection", "ConnectionPassword", ConnectionPassword);
            //Helper.PIni.Write("NetworkDriverPath","Raw1",Raw1)
            //Helper.PIni.Write("NetworkDriverPath","Raw1",Raw1)
            //Helper.PIni.Write("NetworkDriverPath","Raw1",Raw1)
            //Helper.PIni.Write("NetworkDriverPath","Raw1",Raw1)

        }
    }
}
