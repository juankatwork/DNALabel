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
    public partial class FrmAddAssemblyLineInfo : Form
    {
        DatabaseClass m_dataClass = new DatabaseClass();
        public event System.EventHandler OnOkClicked;
        public GlobalSettings GlblSettings
        {
            set;
            get;
        }
        public FrmAddAssemblyLineInfo()
        {
            InitializeComponent();
        }

        private void FrmAddAssemblyLineInfo_Load(object sender, EventArgs e)
        {
            try
            {
                m_dataClass.Connect(GlblSettings.ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                AssemblyLineInformation ali = new AssemblyLineInformation();
                ali.Location = textBoxLocation.Text;
                ali.Label_Path = textBoxLabelPath.Text;
                if (!m_dataClass.InsertAssemblyLineInfo(ali))
                {
                    MessageBox.Show(m_dataClass.ErrorMessage);
                }
                System.EventArgs ea = new EventArgs();
                OnOkClicked(this, ea);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSetPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                textBoxLabelPath.Text = ofd.FileName;
            }
        }
    }
}
