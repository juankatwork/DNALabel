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
    public partial class FrmAssemblyLineInformation : Form
    {
        private DatabaseClass m_dataClass = new DatabaseClass();
        FrmAddAssemblyLineInfo m_frmAssemblyLineInfo = null;
        public FrmAssemblyLineInformation()
        {
            InitializeComponent();
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FrmAssemblyLineInformation_Load(object sender, EventArgs e)
        {
            LoadAssemblyLineInfo();
        }
       

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            LoadInputForm();
        }
        private void LoadAssemblyLineInfo()
        {
            dataGridView1.DataSource = m_dataClass.LoadAssemblyLineInfo();
        }
        private void LoadInputForm()
        {
            if (m_frmAssemblyLineInfo == null || m_frmAssemblyLineInfo.IsDisposed)
            {
                m_frmAssemblyLineInfo = new FrmAddAssemblyLineInfo();

                m_frmAssemblyLineInfo.MdiParent = this.MdiParent;
                m_frmAssemblyLineInfo.OnOkClicked += M_frmAssemblyLineInfo_OnOkClicked;

            }
            m_frmAssemblyLineInfo.Focus();
        }

        private void M_frmAssemblyLineInfo_OnOkClicked(object sender, EventArgs e)
        {
            m_frmAssemblyLineInfo.Close();
            dataGridView1.DataSource = m_dataClass.LoadAssemblyLineInfo();
        }

        private void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgRow in dataGridView1.Rows)
                {
                    AssemblyLineInformation ali = (AssemblyLineInformation)dgRow.DataBoundItem;
                    m_dataClass.UpdateAssemblyLineInfo(ali);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
