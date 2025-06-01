using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNALabelSync
{
    public partial class FrmSettings : Form
    {
        public event System.EventHandler OnOkButtonClicked;
        GlobalSettings _settingsProps;
        GlobalSettingsMgr _settingsMgr = null;
       
        public FrmSettings()
        {
            InitializeComponent();
            _settingsMgr = new GlobalSettingsMgr();
            try
            {
                _settingsMgr.ReadSettings(ref _settingsProps);

                if (null == _settingsProps)
                {
                    _settingsProps = new GlobalSettings();
                }

                propertyGrid1.SelectedObject = _settingsProps;
            }
            catch (Exception) { }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.Escape) this.Close();
                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return false;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            _settingsProps = (GlobalSettings)propertyGrid1.SelectedObject;
            _settingsMgr.SaveSettings(_settingsProps);
            System.EventArgs ea = new EventArgs();
            OnOkButtonClicked(this, ea);
            Close();
        }

        private void toolStripButtonSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _settingsProps = (GlobalSettings)propertyGrid1.SelectedObject;
                _settingsMgr.SaveSettings(_settingsProps, sfd.FileName);
                System.EventArgs ea = new EventArgs();
            }
            Close();
        }

        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _settingsMgr.ReadSettings(ref _settingsProps, ofd.FileName);

                    if (null == _settingsProps)
                    {
                        _settingsProps = new GlobalSettings();
                    }

                    propertyGrid1.SelectedObject = _settingsProps;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmSettings_Load(object sender, EventArgs e)
        {

        }

       
    }
}
