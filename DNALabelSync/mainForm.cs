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
    public partial class mainForm : Form
    {
        FrmSerialMatch m_frmSerialMatch = null;
        FrmSettings m_frmSettins = null;
        FrmAssemblyLineInformation m_frmAssemblyLine = null;
        FrmItemMaster m_frmItemMaster = null;

        GlobalSettingsMgr m_GlobalSettingsMgr = new GlobalSettingsMgr();
        GlobalSettings m_GlobalSettings = new GlobalSettings();

        public mainForm()
        {
            InitializeComponent();
            m_GlobalSettingsMgr.ReadSettings(ref m_GlobalSettings);
        }

        private void toolStripButtonLoadSerialMatch_Click(object sender, EventArgs e)
        {
            LoadSerialMatch();
        }
        private void LoadSerialMatch()
        {
            try
            {
                if (m_frmSerialMatch == null || m_frmSerialMatch.IsDisposed)
                {
                    m_frmSerialMatch = new FrmSerialMatch();

                    m_frmSerialMatch.MdiParent = this;
                    m_frmSerialMatch.GlblSettings = m_GlobalSettings;
                    m_frmSerialMatch.Show();
                }
                m_frmSerialMatch.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void LoadItemMaster()
        {
            try
            {
                if (m_frmItemMaster == null || m_frmItemMaster.IsDisposed)
                {
                    m_frmItemMaster = new  FrmItemMaster();
                    m_frmItemMaster.GlblSettings = m_GlobalSettings;
                    m_frmItemMaster.MdiParent = this;
                    m_frmItemMaster.Show();
                }
                m_frmItemMaster.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadAssemblyLine()
        {
            try
            {
                if (m_frmAssemblyLine == null || m_frmAssemblyLine.IsDisposed)
                {
                    m_frmAssemblyLine = new FrmAssemblyLineInformation();
                    m_frmAssemblyLine.GlblSettings = m_GlobalSettings;
                    m_frmAssemblyLine.MdiParent = this;
                    m_frmAssemblyLine.Show();
                }
                m_frmAssemblyLine.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void LoadSettings()
        {
            try
            {
                if (m_frmSettins == null || m_frmSettins.IsDisposed)
                {
                    m_frmSettins = new FrmSettings();

                    m_frmSettins.MdiParent = this;
                    m_frmSettins.OnOkButtonClicked += M_frmSettins_OnOkButtonClicked;
                    m_frmSettins.Show();
                }
                m_frmSettins.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void M_frmSettins_OnOkButtonClicked(object sender, EventArgs e)
        {
            m_GlobalSettingsMgr.ReadSettings(ref m_GlobalSettings);

            /* Close all open forms */
            DialogResult dr = MessageBox.Show("This action will close all open forms. Do you want to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (Form mdic in this.MdiChildren)
                {
                    if (mdic != null && !mdic.IsDisposed)
                    {
                        mdic.Close();
                    }
                }
            }
            m_frmSettins.Close();
        }

        private void toolStripButtonSettings_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void toolStripButtonLoadAssemblyLine_Click(object sender, EventArgs e)
        {
            LoadAssemblyLine();
        }

        private void toolStripButtonLoadItemMaster_Click(object sender, EventArgs e)
        {
            LoadItemMaster();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
           
            about.MdiParent = this;
            about.Show();
        }
    }
}
