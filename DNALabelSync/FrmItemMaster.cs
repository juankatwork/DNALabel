using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNALabelSync
{

    public partial class FrmItemMaster : Form
    {
        private DatabaseClass m_dataClass = new DatabaseClass();
        FrmAddItemMaster m_frmAddItemMaster = null;
        public GlobalSettings GlblSettings
        {
            set;
            get;
        }
        public FrmItemMaster()
        {
            InitializeComponent();
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FrmItemMaster_Load(object sender, EventArgs e)
        {
            m_dataClass.Connect(GlblSettings.ConnectionString);
            LoadItemMaster();
        }
        private void LoadItemMaster()
        {
           dataGridView1.DataSource =  m_dataClass.LoadMasterItems();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            
           LoadInputForm();
           
        }

        private void LoadInputForm()
        {
            if (m_frmAddItemMaster == null || m_frmAddItemMaster.IsDisposed)
            {
                m_frmAddItemMaster = new  FrmAddItemMaster();

                m_frmAddItemMaster.MdiParent = this.MdiParent;
                m_frmAddItemMaster.OnOkClicked += M_frmAddItemMaster_OnOkClicked;

            }
            m_frmAddItemMaster.Focus();
        }

        private void M_frmAddItemMaster_OnOkClicked(object sender, EventArgs e)
        {
            m_frmAddItemMaster.Close();
            dataGridView1.DataSource = m_dataClass.LoadMasterItems();
        }

        private void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgRow in dataGridView1.Rows)
                {   
                    ItemMaster im = (ItemMaster)dgRow.DataBoundItem;
                    m_dataClass.UpdateItemMaster(im);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
           DataGridViewRow dgr = dataGridView1.SelectedRows[0];
            try
            {
                ItemMaster im = (ItemMaster)dgr.DataBoundItem;
                m_dataClass.DeleteItemMaster(im);
                LoadItemMaster();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
