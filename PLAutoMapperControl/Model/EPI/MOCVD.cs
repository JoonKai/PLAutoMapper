using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAutoMapperControl.Model
{
    public class MOCVD
    {
        public string MOCVDID { get; set; }
        public string MOCVDName { get; set; }
        public string MOCVDSite { get; set; }  
        
    }
    public class LocationList
    {
        public List<string> MOCVDLocation { get; set; }
    }
}
