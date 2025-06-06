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
    public partial class FrmAddItemMaster : Form
    {
        DatabaseClass m_dataClass = new DatabaseClass();
        public event System.EventHandler OnOkClicked;
        public GlobalSettings GlblSettings
        {
            set;
            get;
        }
        public FrmAddItemMaster()
        {
            InitializeComponent();
            m_dataClass.Connect(GlblSettings.ConnectionString);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                ItemMaster im = new ItemMaster();
                im.Item_Model_Number = textBoxModelNo.Text;
                im.Description = textBoxDescription.Text;
                im.UPC_Code = textBoxUPCCode.Text;
                im.Label_Name = textBoxLabelName.Text;
                im.Engine_Serial_No__Identifier = textBoxSerialNo.Text;
                if (!m_dataClass.InserItemMaster(im))
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

        private void FrmAddItemMaster_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
