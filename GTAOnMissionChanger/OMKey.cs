using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTAOnMissionChanger
{
    public partial class OMKey : Form
    {
        Keys OmKey = GTAOnMissionChanger.Properties.Settings.Default.OMButton;
        public OMKey()
        {
            InitializeComponent();
        }

        private void OMKey_Load(object sender, EventArgs e)
        {
            txtKey.Text = GTAOnMissionChanger.Properties.Settings.Default.OMButton.ToString();
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            txtKey.Text = "";
            txtKey.Text = e.KeyData.ToString();
            OmKey = e.KeyData;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKey.Text = Keys.F6.ToString();
            OmKey = Keys.F6;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GTAOnMissionChanger.Properties.Settings.Default.OMButton = OmKey;
            GTAOnMissionChanger.Properties.Settings.Default.Save();
            this.Close();
            DialogResult dr = MessageBox.Show("A restart is required in order to apply the changes. Would you like to restart this application now?", "GTA On Mission Changer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Restart();
            }


        }
    }
}
