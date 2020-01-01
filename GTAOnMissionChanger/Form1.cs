using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCSplitInfo;
using System.Threading;


namespace GTAOnMissionChanger
{
    public partial class Form1 : Form
    {
        bool updateAvailable = false;
        bool isForced = GTAOnMissionChanger.Properties.Settings.Default.isForced;   // = forcing OM value to 0 all the time
        //bool isAutoDetect = GTAOnMissionChanger.Properties.Settings.Default.isAutoDetect; 
        Keys omKey = GTAOnMissionChanger.Properties.Settings.Default.OMButton;
        bool showUpdateMessage = false;     // this will force a message to be shown, even when no update is found (used for manual update checking)
        private KeyHandler ghk;

        Thread onMissionFlagThread;

        long currentOMMemoryValue = 0; // for beep

        Process processIII = Process.GetProcessesByName("gta3").FirstOrDefault();
        Process processVC = Process.GetProcessesByName("gta-vc").FirstOrDefault();
        Process processSA1 = Process.GetProcessesByName("gta_sa").FirstOrDefault();
        Process processSA2 = Process.GetProcessesByName("gta-sa").FirstOrDefault();

        SoundPlayer sp = new SoundPlayer(Properties.Resources.Beep);

        List<GameVersion> versionList = new List<GameVersion>(); // Contains data about EVERY game (III, VC, SA)
        GameVersion CurrentGameVersion = new GameVersion(); // saves data about the CURRENT game
        GameVersionDetector gvd = new GameVersionDetector();

        public Form1()
        {
            InitializeComponent();
            ghk = new KeyHandler(omKey, this);
            ghk.Register();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblGame.Text = "- Loading... -";
            lblisAdmin.Text = "Warning: Tool might not work properly without Admin rights!";
            lblisAdmin.Visible = false;
            if (!IsAdministrator())
            {
                lblisAdmin.Visible = true;
            }
            onMissionFlagThread = new Thread(new ThreadStart(getMissionFlag));
            onMissionFlagThread.Start();

            lblInfo.Text = "Press " + omKey + " to toggle the 'On Mission' variable";
            tsmiCheckUpdatesOnStartup.Checked = GTAOnMissionChanger.Properties.Settings.Default.isAutoUpdate;
            tsmiForceState.Checked = GTAOnMissionChanger.Properties.Settings.Default.isForced;
            playBeepWhenOMChangesToolStripMenuItem.Checked = GTAOnMissionChanger.Properties.Settings.Default.playSound;
            useNewAddressesForGTASAToolStripMenuItem.Checked = GTAOnMissionChanger.Properties.Settings.Default.newSa;

            if (GTAOnMissionChanger.Properties.Settings.Default.isAutoUpdate)
            {
                CheckForUpdates();
            }

            /*   if (!File.Exists("Beep.wav") && playBeepWhenOMChangesToolStripMenuItem.Checked)
               {
                   MessageBox.Show("File 'Beep.wav' could not be found. Please redownload the On Mission Changer if you want to use this feature. This feature has now been disabled.", "File could not be found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   playBeepWhenOMChangesToolStripMenuItem.Checked = false;
                   GTAOnMissionChanger.Properties.Settings.Default.Save();
               }*/
            tmrGameVersion.Interval = 100;

        }

        private void HandleHotkey()
        {
            Console.WriteLine("Button press triggered.");
            gvd.ChangeValue(CurrentGameVersion);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }


        private void tmrGameVersion_Tick(object sender, EventArgs e)
        {
            tmrGameVersion.Interval = 1000;
            lblGame.Text = "- Detecting version... -";
            versionList.Clear();

            processIII = Process.GetProcessesByName("gta3").FirstOrDefault();
            processVC = Process.GetProcessesByName("gta-vc").FirstOrDefault();
            processSA1 = Process.GetProcessesByName("gta_sa").FirstOrDefault();
            processSA2 = Process.GetProcessesByName("gta-sa").FirstOrDefault();

            GameVersion gtaiiiVersion = new GameVersion(processIII, GameVersionDetector.getGameInformation(processIII), 0x0075B6C4);
            versionList.Add(gtaiiiVersion);
            GameVersion gtavcVersion = new GameVersion(processVC, GameVersionDetector.getGameInformation(processVC), 0x00821764);
            versionList.Add(gtavcVersion);
            GameVersion gtasa1Version = new GameVersion(processSA1, GameVersionDetector.getGameInformation(processSA1), 0x00A49FC4);
            versionList.Add(gtasa1Version);
            GameVersion gtasa2Version = new GameVersion(processSA2, GameVersionDetector.getGameInformation(processSA2), 0x00D70000);
            versionList.Add(gtasa2Version);

            foreach (var game in versionList)
            {

                if (gvd.DetectCurrentVersion(game))
                {
                    lblGame.Text = game.GameName;
                    CurrentGameVersion = game;
                    tmrGameVersion.Interval = 10000;
                    return;
                }
                else
                {
                    lblGame.Text = "- Game not running or unrecognized version -";
                    // lblValue.Text = "On Mission: " + 0;
                    tmrGameVersion.Interval = 1000;
                }
            }


        }

        /// <summary>
        /// (Thread) Gets the current Memory Address value, and shows on form
        /// </summary>
        private void getMissionFlag()
        {
            try
            {
                while (true)    // Thread will always be running
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblValue.Text = "On Mission: " + gvd.OnMissionValue(CurrentGameVersion);

                    });
                    Thread.Sleep(5);    // to prevent cpu lag
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void tmrOnMission_Tick(object sender, EventArgs e)
        {

            if (currentOMMemoryValue != gvd.OnMissionValue(CurrentGameVersion) && playBeepWhenOMChangesToolStripMenuItem.Checked)
            {
                sp.Play();
            }

            currentOMMemoryValue = gvd.OnMissionValue(CurrentGameVersion);

            if (isForced) // Force value to 0
            {
                this.tmrOnMission.Interval = 25;
                gvd.ChangeValueToZero(CurrentGameVersion);
            }
            else if (!isForced)
            {
                this.tmrOnMission.Interval = 100;
            }
        }


        private void CheckForUpdates()
        {
            try
            {
                Update update = UpdateChecker.CheckUpdate();
                Version applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                if (applicationVersion.CompareTo(update.Mandatory) < 0) // probably never gonna be used
                {
                    tmrGameVersion.Enabled = false;
                    updateAvailable = true;
                    lblGame.Text = "- Update required -";
                    DialogResult dr = MessageBox.Show("A mandatory update is required!\r\nYou are currently using version " + applicationVersion + ", and you will have to upgrade to version " + update.Version + " before you can use this application again.\r\n\r\nChangelog:\r\n" + update.About + "\r\n\r\nWould you like to update now? This will be downloaded using your default browser.", "Version " + update.Version + " is available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(update.Url);
                        }
                        catch (Exception ex)
                        { MessageBox.Show("The update could not be downloaded. Please try again later.\r\n" + ex.Message, "Error when downloading update", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        // return;
                    }
                    else
                    {
                        MessageBox.Show("This is a mandatory update and you will have to update before you can use this application again.", "Update cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Application.Exit();
                    }
                }
                else if (applicationVersion.CompareTo(update.Version) < 0)
                {
                    updateAvailable = true;
                    DialogResult dr = MessageBox.Show("There's an update available for this application!\r\nYou are currently using version " + applicationVersion + ", and can now upgrade to version " + update.Version + ".\r\n\r\nChangelog:\r\n" + update.About + "\r\n\r\nWould you like to update now? This will be downloaded using your default browser.", "Version " + update.Version + " is available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(update.Url);
                        }
                        catch (Exception ex)
                        {
                            DialogResult dr2 = MessageBox.Show("The update could not be downloaded. Please try again later.\r\n" + ex.Message, "Error when downloading update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        // return;
                    }
                }
                else if (applicationVersion.CompareTo(update.Version) >= 0 && showUpdateMessage)
                {
                    showUpdateMessage = false;
                    MessageBox.Show("No update has been found. You are already using the latest version!", "GTA On Mission Changer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to check for updates, please try again later.", "Unable to check for updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }

        }

        private void showDebugInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gameString = "";

            try
            {
                foreach (var game in versionList)
                {
                    if (GameVersionDetector.isProcessActive(game.Process))
                    {
                        gameString += Memory.getMemoryResultInt(game.Process, 0x00608578, 4) + " (" + GameVersionDetector.getGameInformation(game.Process).GameName + ")" + Environment.NewLine;
                        gameString += CurrentGameVersion.OMMemAddress + " (" + String.Format("{0:X}", CurrentGameVersion.OMMemAddress) + ") + Offset: " + GameVersionDetector.getGameInformation(game.Process).Offset.ToString() + Environment.NewLine + Environment.NewLine;
                    }
                }
                MessageBox.Show("DEBUG:\n\r\n\rUpdate available: " + updateAvailable + "\n\rRunning as Administrator: " + IsAdministrator() + "\n\r\n\r" + gameString + "\n\r", "Debug");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void forceAllMissionStateTo0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tsmiForceState.Checked)
            {
                tsmiForceState.Checked = false;
            }
            else
            {
                tsmiForceState.Checked = true;
            }

            GTAOnMissionChanger.Properties.Settings.Default.isForced = tsmiForceState.Checked;
            isForced = GTAOnMissionChanger.Properties.Settings.Default.isForced;
            GTAOnMissionChanger.Properties.Settings.Default.Save();
        }

        private void changeKeyToChangeFlagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OMKey ok = new OMKey();
            ok.ShowDialog();
        }


        private void checkforUpdatesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //UpdateChecker.Enabled = true;
            showUpdateMessage = true;
            CheckForUpdates();
        }

        private void checkForUpdatesOnStartupToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (tsmiCheckUpdatesOnStartup.Checked)
            {
                tsmiCheckUpdatesOnStartup.Checked = false;
            }
            else
            {
                tsmiCheckUpdatesOnStartup.Checked = true;
            }

            GTAOnMissionChanger.Properties.Settings.Default.isAutoUpdate = tsmiCheckUpdatesOnStartup.Checked;
            GTAOnMissionChanger.Properties.Settings.Default.Save();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("© 2015-2020\r\nMade by Earleys.\r\n\r\nMessage me on #GTA, Twitch or Discord if you need help/want things added.\r\n\r\nyesDuping\r\nyesDuping yesDuping\r\nyesDuping yesDuping yesDuping\r\nyesDuping yesDuping yesDuping yesDuping\r\nyesDuping yesDuping yesDuping\r\nyesDuping yesDuping\r\nyesDuping", "About");
        }

        private void playBeepWhenOMChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (!File.Exists("Beep.wav") && !playBeepWhenOMChangesToolStripMenuItem.Checked)
            {
                MessageBox.Show("File 'Beep.wav' could not be found. Please redownload the On Mission Changer if you want to use this feature.", "File could not be found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                playBeepWhenOMChangesToolStripMenuItem.Checked = false;
            }
            else*/
            if (playBeepWhenOMChangesToolStripMenuItem.Checked)
            {
                playBeepWhenOMChangesToolStripMenuItem.Checked = false;
            }
            else
            {
                playBeepWhenOMChangesToolStripMenuItem.Checked = true;
            }

            GTAOnMissionChanger.Properties.Settings.Default.playSound = playBeepWhenOMChangesToolStripMenuItem.Checked;
            GTAOnMissionChanger.Properties.Settings.Default.Save();
        }

        private void viewSourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Earleys/GTA-On-Mission-Changer");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void useNewAddressesForGTASAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (useNewAddressesForGTASAToolStripMenuItem.Checked)
            {
                useNewAddressesForGTASAToolStripMenuItem.Checked = false;
            } else
            {
                useNewAddressesForGTASAToolStripMenuItem.Checked = true;
            }

            GTAOnMissionChanger.Properties.Settings.Default.newSa = useNewAddressesForGTASAToolStripMenuItem.Checked;
            GTAOnMissionChanger.Properties.Settings.Default.Save();
        }
    }
}
