using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAutoMapper.Models
{
    public class SettingsModel
    {
        public string Raw1 { get; set; }
        public string Raw2 { get; set; }
        public string Backup { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public string PLID { get; set; }
        public string CopyOption { get; set; }
        public bool AutoDelete { get; set; }
        public bool SendRecycleBin { get; set; }
        public bool ETC1 { get; set; }
        public bool ETC2 { get; set; }
        public int AxisFontSize { get; set; }
        public string DatabaseName { get; set; }
        public string DatabasePort { get; set; }
        public string DatabaseID { get; set; }
        public string DatabasePassword { get; set; }
    }
}
