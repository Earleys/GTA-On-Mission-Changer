using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAOnMissionChanger
{
    public class Update
    {
        public Version Version { get; set; }
        public string Url { get; set; }
        public Version Mandatory { get; set; }
        public string About { get; set; }
    }
}
