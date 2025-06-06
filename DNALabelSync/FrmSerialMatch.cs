using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DNALabelSync
{
    public partial class FrmSerialMatch : Form
    {
        private DatabaseClass m_dataClass = new DatabaseClass();
        public GlobalSettings GlblSettings
        {
            set;
            get;
        }
        bool IsHandle = false;
        bool CanPrintLabel = false;
        bool IsDatabaseLoggedIn = false;
        public FrmSerialMatch()
        {
            InitializeComponent();
            dataGridViewLabelHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridViewLabelHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSerialTracker()
        {
            m_dataClass.Connect(GlblSettings.ConnectionString);
            dataGridViewLabelHistory.DataSource = m_dataClass.LoadSerialTracker();
        }
        private void FrmSerialMatch_Load(object sender, EventArgs e)
        {
            textBoxProductionDate.Text = DateTime.Today.ToShortDateString();
            LogMsgToRichTextBox(string.Format("Production Date set to {0}", textBoxProductionDate.Text));
            if (false == m_dataClass.Connect(GlblSettings.ConnectionString))
            {
                MessageBox.Show(m_dataClass.ErrorMessage);
                LogMsgToRichTextBox(m_dataClass.ErrorMessage);
                CanPrintLabel = false;
                IsDatabaseLoggedIn = false;
            }
            else
            {
                LogMsgToRichTextBox(string.Format("Connected to {0}", GlblSettings.ConnectionString));
                RefreshDir();
                this.ActiveControl = textBoxPreprintedBarcode;
                this.textBoxPreprintedBarcode.Focus();
                LoadSerialTracker();
                IsDatabaseLoggedIn = true;
                CanPrintLabel = true;
                lblCurrentAssemblyLine.Text = GlblSettings.AssemblyLine;
                lblCurrentModel.Text = GlblSettings.ModelNumber;
            }

        }
       

     

        private bool ValidatePreprintedLabel(string labelText)
        {
            if (m_dataClass.SerialNoExist(labelText))
            {
                return true;
            }
            return false;
        }
        private bool ValidateEngineLabel(string LabelText,ref string serialNo,ref string modelNo, ref string upc, ref string description)
        {
            string ErrorMessage  = string.Empty;
            string preprintedBarcode = textBoxPreprintedBarcode.Text.Replace("\r", "").Replace("\n", "");

            serialNo = new string(LabelText.Skip(6).Take(13).ToArray());
            LogMsgToRichTextBox(string.Format("Serial No '{0}",serialNo));
            modelNo = new string(LabelText.Skip(21).Take(12).ToArray());
            LogMsgToRichTextBox(string.Format("Model No. '{0}'",modelNo));

            string serialNoIdentifier = m_dataClass.GetItemMasterSerialIdentifierAndUPC(GlblSettings.ModelNumber, ref upc,ref description);
            if (checkBoxTestMode.Checked) { return true; }

            
            if (serialNoIdentifier != string.Empty)
            {
                if (serialNoIdentifier != modelNo)
                {
                    ErrorMessage = string.Format("Model {0}, does not match SerialNoIdentifier '{1}' from database Model '{2}",
                               modelNo, serialNoIdentifier, GlblSettings.ModelNumber);
                    LogMsgToRichTextBox(ErrorMessage);
                    MessageBox.Show(ErrorMessage);
                    return false;

                }
                else
                {
                    return true;

                }
            }
            else 
                return false;
        }

      

       

       
        private void GenerateLabel(string modelNo, string serialNo, string departmentNo, string engineSerial, string upc,string description)
        {
            string LabelPath = string.Empty;
            try
            {
                
                string fileName = string.Format(@"{0}\{1}", GlblSettings.WorkDirectory, engineSerial);
                Util u = new Util();

                LabelPath = m_dataClass.GetLabelPath(int.Parse(GlblSettings.AssemblyLine));
                if (string.Empty != LabelPath )
                {
                    u.SetLabelPathAndType(LabelPath,GlblSettings.CurrentLabelOutput);
                }
               
                u.GlblSettings = GlblSettings;
                u.GetLabel(fileName, modelNo, departmentNo, serialNo,upc, description);
                ClearForm();
                Serial_No__Tracker slt = new Serial_No__Tracker();
                slt.Assembly_Line_No_ = int.Parse(GlblSettings.AssemblyLine);
                slt.Item_Model_Number = GlblSettings.ModelNumber;
                slt.Location = "";
                slt.Engine_Serial_No_ = engineSerial;
                slt.Serial_No_ = serialNo;
                slt.Production_Date_Time = DateTime.Parse(textBoxProductionDate.Text);
                if (!m_dataClass.InsertSerialInfo(slt))
                    throw (new Exception(m_dataClass.ErrorMessage));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearForm()
        {
            textBoxPreprintedBarcode.Text = string.Empty;
            textBoxEngineBarcode.Text = string.Empty;
            textBoxModelNo.Text = string.Empty;
            IsHandle = false;
            if (IsDatabaseLoggedIn)
            {
                CanPrintLabel = true;
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDir();
        }
        private void RefreshDir()
        {
            try
            {
                if (!string.IsNullOrEmpty(GlblSettings.WorkDirectory) && Directory.Exists(GlblSettings.WorkDirectory))
                {
                    webBrowserLabels.Navigate(GlblSettings.WorkDirectory);
                }
                else
                {
                    richTextBoxMessages.Text += string.Format("PDF label directory '{0}' does not exist.{1}. Please set it up in options page.", GlblSettings.WorkDirectory, System.Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Set up label and work directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonClearFields_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.ActiveControl = textBoxPreprintedBarcode; 
        }

        private void toolStripButtonExportCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV();
        }

        private void textBoxPreprintedBarcode_TextChanged(object sender, EventArgs e)
        {
            IsHandle = false;
            string msg = string.Empty;
            string scanLabel = string.Empty;
            if (CanPrintLabel)
            {
                TextBox myTextBox = (TextBox)sender;
                if (myTextBox.Text.EndsWith("\r") || myTextBox.Text.EndsWith("\n"))
                {   
                    scanLabel = myTextBox.Text.Replace("\n", "").Replace("\r", "");
                    LblLastScanLabel.Text = scanLabel;
                    msg = string.Format(@"Serial No: {0} exist in database.", scanLabel);
                    LogMsgToRichTextBox(string.Format("Scan {0}", scanLabel));

                    if (ValidatePreprintedLabel(scanLabel))
                    {
                        LogMsgToRichTextBox(msg);
                        MessageBox.Show(msg, "Error Dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CanPrintLabel = false;
                    }
                    else
                    {
                        this.ActiveControl = textBoxEngineBarcode;
                        textBoxProductionDate.Text = dateTimePickerShipDate.Value.ToString();
                        
                    }
                }
            }
            else
            {
                msg = string.Format("The system can not print labels right now. Please check previous error message.");
                LogMsgToRichTextBox(msg);
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxEngineBarcode_TextChanged(object sender, EventArgs e)
        {
            string serialNo = string.Empty;
            string modelNo = string.Empty;
            string upc = string.Empty;
            string description = string.Empty;
            TextBox myTextBox = (TextBox)sender;
            string msg = string.Empty;
            string LabelText = string.Empty;
            string preprintedBarcode = string.Empty;
            if (!IsHandle)
            {
                if (CanPrintLabel)
                {
                    if (myTextBox.Text.EndsWith("\r") || myTextBox.Text.EndsWith("\n"))
                    {
                        LabelText = myTextBox.Text.Replace("\n", "").Replace("\r", "");
                        if (LabelText != string.Empty)
                        {
                            if (ValidateEngineLabel(LabelText, ref serialNo, ref modelNo, ref upc,ref description))
                            {
                                LogMsgToRichTextBox(string.Format(string.Format("Scan EngineLabel {0}", LabelText.Replace("{", string.Empty))));
                                LogMsgToRichTextBox(string.Format("Engine Serial '{0}', Engine Model '{1}'", serialNo, modelNo));
                                textBoxModelNo.Text = modelNo;
                                IsHandle = true;
                                textBoxEngineBarcode.Text = serialNo;
                               
                                preprintedBarcode = textBoxPreprintedBarcode.Text.Replace("\n", "").Replace("\r", "");
                                LogMsgToRichTextBox(string.Format("Generating Label {0}", preprintedBarcode));

                                //string modelNo, string serialNo, string departmentNo, string engineSerial, string upc,string description)
                                GenerateLabel(GlblSettings.ModelNumber, preprintedBarcode, "D25P",serialNo  ,upc, description);
                                dataGridViewLabelHistory.DataSource = m_dataClass.LoadSerialTracker();
                                dataGridViewLabelHistory.Refresh();
                                this.ActiveControl = textBoxPreprintedBarcode;
                            }
                            else
                            {
                                msg = string.Format(@"Serial No: {0} does not match Engine Serial {1}", textBoxEngineBarcode.Text, serialNo);
                                LogMsgToRichTextBox(msg);
                                MessageBox.Show(msg, "Error Dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                CanPrintLabel = false;
                            }
                            this.ActiveControl = textBoxProductionDate;
                            IsHandle = true;
                        }
                    }
                }
                else
                {
                    msg = string.Format("The system can not print labels right now. Please check previous error message.");
                    LogMsgToRichTextBox(msg);
                    MessageBox.Show(msg,"Error",   MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
        private void LogMsgToRichTextBox(string msg)
        {
            try
            {
                richTextBoxMessages.AppendText(msg);
                richTextBoxMessages.AppendText(System.Environment.NewLine);
                richTextBoxMessages.ScrollToCaret();
                string msg1 = string.Format("{0} - User='{1}' Msg='{2}{3}", DateTime.Now, Environment.UserName , msg, System.Environment.NewLine);
                File.AppendAllText(string.Format(@"{0}\DNALabelSync.log", GlblSettings.WorkDirectory), msg1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error logging information. Error='{0}'", ex.Message), "Error Dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportToCSV()
        {

        }
    }
}
