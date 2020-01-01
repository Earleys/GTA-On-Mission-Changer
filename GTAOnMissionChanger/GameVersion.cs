using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GTAOnMissionChanger
{
    public class GameVersion
    {
        public Process Process { get; set; }
        public string GameName { get; set; }
        public int Offset { get; set; }
        public int OMMemAddress { get; set; }

        public GameVersion(Process process, string gameName, int offset, int omMemAddress)
        {
            this.Process = process;
            this.GameName = gameName;
            this.OMMemAddress = omMemAddress;
            this.Offset = offset;
        }

        public GameVersion(Process process, GameVersion gameVersion, int omMemAddress)
        {
            this.Process = process;
            this.GameName = gameVersion.GameName;
            this.Offset = gameVersion.Offset;
            this.OMMemAddress = omMemAddress;
        }

        public GameVersion(string gameName, int offset)
        {
            this.GameName = gameName;
            this.Offset = offset;
        }

        public GameVersion()
        {

        }
    }
}
