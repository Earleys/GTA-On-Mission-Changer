using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSplitInfo;

namespace GTAOnMissionChanger
{
    public class GameVersionDetector
    {

        public static GameVersion getGameInformation(Process process)
        {
            // this is based on Lighnat0r's GameVersionCheck script ( https://github.com/Lighnat0r/Files/blob/master/Lib/GameVersionCheck.ahk )
            GameVersion version;
            try
            {
                if (isProcessActive(process))
                {
                    if (process.ProcessName == "gta-vc")
                    {
                        byte value = (byte)Memory.getMemoryResultInt(process, 0x00608578, 4);

                        if (value == 0x5D)
                        {
                           version = new GameVersion("Gta: Vice City (Retail 1.0)", 0); //1.0
                        }
                        else if (value == 0x81)
                        {
                            version = new GameVersion("GTA: Vice City (1.1)", 0x81); // 1.1
                        }
                        else if (value == 0x5B)
                        {
                            version = new GameVersion("Gta: Vice City (Steam)", -0xFF8); // steam
                        }
                        else if (value == 0x44)
                        {
                            version = new GameVersion("GTA: Vice City (Japanese)", -0x2FF8); // japanese
                        }
                        else
                        {
                            //     System.Windows.Forms.MessageBox.Show("Test");
                           version = new GameVersion("Gta: Vice City (Unknown)", 0);
                        }
                    }
                    else if (!GTAOnMissionChanger.Properties.Settings.Default.newSa && process.ProcessName == "gta-sa" || !GTAOnMissionChanger.Properties.Settings.Default.newSa && process.ProcessName == "gta_sa")
                    {
                        long value = Memory.getMemoryResultInt(process, 0x0082457C, 4);
                        long value2 = Memory.getMemoryResultInt(process, 0x008245BC, 4);
                        long value3 = Memory.getMemoryResultInt(process, 0x008252FC, 4);
                        long value4 = Memory.getMemoryResultInt(process, 0x0082533C, 4);
                        long value5 = Memory.getMemoryResultInt(process, 0x0085EC4A, 4);
                        long value6 = Memory.getMemoryResultInt(process, 0x0085DEDA, 4);
                        long value7 = Memory.getMemoryResultInt(process, 0x0089BEEC, 4);
                        long value8 = Memory.getMemoryResultInt(process, 0x00826BFC, 4);
                        long value9 = Memory.getMemoryResultInt(process, 0x0085EC4A, 4);


                        if (value == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (1.0 US)", 0); // Version 1.0 US
                        }
                        else if (value2 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (1.0 EU/AUS/US/DG)", 0); // 1.0 EU/AUS or 1.0 US Hoodlum or 1.0 Downgraded
                        }
                        else if (value3 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (1.01 US)", 0x2680); // 1.01 US
                        }
                        else if (value4 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (1.01 EU/US/DEV/DG)", 0x2680); //Version 1.01 EU / AUS or 1.01 Deviance or 1.01 Downgraded
                        }
                        else if (value5 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (3.0 Steam)", 0x75130); // 3.0 Steam
                        }
                        else if (value6 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (Steam?)", 0x75770); // 1.0 Steam ?
                        }
                        else if (value7 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (3.0 Steam, latest patch)", 0x6C1934); // 0xEA7970 //0x6C1934
                        }
                        else if (value8 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (2.0 Retail)", 0x2680);
                        }
                        else if (value9 == 149) // this is probably wrong
                        {
                            version = new GameVersion("GTA: San Andreas (3.0 - latest Steam version)", 0x6C1934); // this is  probably wrong
                        }
                        else
                        {
                            //   System.Windows.Forms.MessageBox.Show("");
                            version = new GameVersion("GTA: San Andreas (Unknown)", 0x2680);
                        }
                    }
                    else if (GTAOnMissionChanger.Properties.Settings.Default.newSa && process.ProcessName == "gta-sa" || GTAOnMissionChanger.Properties.Settings.Default.newSa && process.ProcessName == "gta_sa")
                    {
                        long value = Memory.getMemoryResultInt(process, 0x0082457C, 4);
                        long value2 = Memory.getMemoryResultInt(process, 0x008245BC, 4);
                        long value3 = Memory.getMemoryResultInt(process, 0x008252FC, 4);
                        long value4 = Memory.getMemoryResultInt(process, 0x0082533C, 4);
                        long value5 = Memory.getMemoryResultInt(process, 0x0085EC4A, 4);
                        long value6 = Memory.getMemoryResultInt(process, 0x0085DEDA, 4);
                        long value8 = Memory.getMemoryResultInt(process, 0x008252FC, 4);
                        long value9 = Memory.getMemoryResultInt(process, 0x0085EC4A, 4);

                        if (value == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (1.0 US)", 0); // Version 1.0 US
                        }
                        else if (value2 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (1.0 EU/AUS/Hoodlum/DG)", 0); // 1.0 EU/AUS or 1.0 US Hoodlum or 1.0 Downgraded
                        }
                        else if (value3 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (1.01 US)", 0x2680); // 1.01 US
                        }
                        else if (value4 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (1.01 EU/US/DEV/DG)", 0x2680); //Version 1.01 EU / AUS or 1.01 Deviance or 1.01 Downgraded
                        }
                        else if (value5 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (3.0 Steam)", 0x75130); // 3.0 Steam
                        }
                        else if (value6 == 0x94BF)
                        {
                            version = new GameVersion("GTA: San Andreas (Steam?)", 0x75770); // 1.0 Steam ?
                        }
                        else if (value8 == 2385428541)
                        {
                            version = new GameVersion("GTA: San Andreas (2.0 Retail/1.01 US)", 0x2680); // 2.0 retail?
                        }
                        else if (value9 == 149) 
                        {
                            version = new GameVersion("GTA: San Andreas (3.0 - latest Steam version)", 0x6C1934);
                        }

                        else
                        {
                            //   System.Windows.Forms.MessageBox.Show("");
                            version = new GameVersion("GTA: San Andreas (Unknown)", 0x2680);
                        }
                    }
                    else if (process.ProcessName == "gta3")
                    {
                        long value = Memory.getMemoryResultInt(process, 0x005C1E70, 4);
                        long value2 = Memory.getMemoryResultInt(process, 0x005C2130, 4);
                        long value3 = Memory.getMemoryResultInt(process, 0x005C6FD0, 4);

                        if (value == 0x53E58955)
                        {
                            version = new GameVersion("GTA: III (1.0)", -0x10140); // v1.0 noCD
                        }
                        else if (value2 == 0x53E58955)
                        {
                            version = new GameVersion("GTA: III (1.1)", -0x10140); // 1.1 noCD
                        }
                        else if (value3 == 0x53E58955)
                        {
                            version = new GameVersion("GTA: III (1.1 Steam)", 0); // 1.1 Steam
                        }
                        else
                        {
                            //     System.Windows.Forms.MessageBox.Show("Test");
                            version = new GameVersion("GTA: III (Unknown)", 0);
                        }
                    }
                    else
                    {
                        version = new GameVersion(" - Game not running or unrecognized version - ", 0);
                    }


                }
                else
                {
                    version = new GameVersion(" - Game not running or unrecognized version - ", 0);
                }
            }
            catch (Exception ex)
            {
                version = new GameVersion(" - Unable to check current game - ", 0);
                Console.WriteLine(ex.Message);
            }
            return version;
        }

        /// <summary>
        /// Returns if the current game is still running
        /// </summary>
        /// <param name="gv"></param>
        /// <returns>Boolean</returns>
        public bool DetectCurrentVersion(GameVersion gv)
        {
            Memory m = new Memory();

            try
            {
                if (isProcessActive(gv.Process))
                {
                    Console.WriteLine("Game: " + gv.GameName + @" --- Address: " + Memory.getMemoryResultInt(gv.Process, 0x00608578, 4));

                    if (GameVersionDetector.getGameInformation(gv.Process).GameName != null || !GameVersionDetector.getGameInformation(gv.Process).GameName.Contains("Unrecognized"))
                    {
                        //Console.WriteLine("Game: " + gv.GameName + @" ---- Address: " + Memory.getMemoryResultInt(gv.Process, 0x00608578, 4));
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool isProcessActive(Process process)
        {
            if (process == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Returns the 'On Mission' value of the current game
        /// </summary>
        /// <param name="currentGame"></param>
        /// <returns></returns>
        public long OnMissionValue(GameVersion currentGame)
        {
            try
            {
                if (isProcessActive(currentGame.Process))
                {
                    Memory m = new Memory();
                    return Memory.getMemoryResultInt(currentGame.Process, currentGame.OMMemAddress + currentGame.Offset, 4);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Toggles the current memory value to 0 or 1
        /// </summary>
        /// <param name="currentGame"></param>
        public void ChangeValue(GameVersion currentGame)
        {
            try
            {
                long memValue = Memory.getMemoryResultInt(currentGame.Process, currentGame.OMMemAddress + currentGame.Offset, 4);

                if (memValue == 0)
                {
                    Memory.writeToMemory(currentGame.Process, currentGame.OMMemAddress + currentGame.Offset, 1);
                }
                else
                {
                    Memory.writeToMemory(currentGame.Process, currentGame.OMMemAddress + currentGame.Offset, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Changes the value to 0 manually
        /// </summary>
        /// <param name="currentGame"></param>
        public void ChangeValueToZero(GameVersion currentGame)
        {
            try
            {
                long memValue = Memory.getMemoryResultInt(currentGame.Process, currentGame.OMMemAddress + currentGame.Offset, 4);


                Memory.writeToMemory(currentGame.Process, currentGame.OMMemAddress + currentGame.Offset, 0);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
