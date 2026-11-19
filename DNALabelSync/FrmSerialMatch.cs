using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DNALabelSync
{
    public partial class FrmSerialMatch : Form
    {
        private DatabaseClass m_dataClass = new DatabaseClass();
        BCConnect bc = new BCConnect();
        public GlobalSettings GlblSettings
        {
            set;
            get;
        }
        bool IsHandle = false;
        bool CanPrintLabel = false;
        bool IsDatabaseLoggedIn = false;
        int LabelCount = 0;
        public FrmSerialMatch()
        {
            InitializeComponent();
            dataGridViewLabelHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridViewLabelHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSerialTracker()
        {
            List<Serial_No__Tracker> listOfTracker = m_dataClass.LoadSerialTracker(int.Parse(GlblSettings.AssemblyLine),true);
            if (listOfTracker != null)
            {
                SortableBindingList<Serial_No__Tracker> lot = new SortableBindingList<Serial_No__Tracker>(listOfTracker);
                dataGridViewLabelHistory.DataSource = lot;
                LabelCount = lot.Count();
                labelCountToday.Text = string.Format("{0}", LabelCount);
            }
        }
        private async void FrmSerialMatch_Load(object sender, EventArgs e)
        {
            try
            {
                m_dataClass.Connect(GlblSettings.ConnectionString);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                this.ActiveControl = textBoxPreprintedBarcode;
                this.textBoxPreprintedBarcode.Focus();
                LoadSerialTracker();
                
                IsDatabaseLoggedIn = true;
                CanPrintLabel = true;
                lblCurrentAssemblyLine.Text = GlblSettings.AssemblyLine;
                lblCurrentModel.Text = GlblSettings.ModelNumber;
            }
           
            bc.GlblSettings = GlblSettings;
            if (await bc.GetAccessToken())
            {
                toolStripStatusLabel1.Text = "Access Token retrieved successfully.";
            }
            else
            {
                toolStripStatusLabel1.Text = "Failed to retrieve Access Token.";
            }

        }
       

     

        private bool ValidatePreprintedLabel(string labelText)
        {
                if (m_dataClass.SerialNoExist(labelText,GlblSettings.ModelNumber))
            {
                return true;
            }
            return false;
        }
        private bool ValidateDuplicateEngineLabel(string labelText,string ItemModel)
        {
            if (m_dataClass.EngineNoExist(labelText,ItemModel))
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

            if (checkBoxTestMode.Checked) { 
                return true; 
            }

            if (ValidateDuplicateEngineLabel(serialNo, modelNo))
            {
                ErrorMessage = string.Format("Engine SerialNo '{0}' for '{1}' exist in database.\nNo. Serial '{0}' para el articulo '{1}' del Motor existe en la base de datos.", serialNo,modelNo);
                LogMsgToRichTextBox(ErrorMessage);
                MessageBox.Show(ErrorMessage, "Error Dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CanPrintLabel = false;
                return false;

            }

            if (serialNoIdentifier != string.Empty)
            {
                if (serialNoIdentifier != modelNo)
                {
                    ErrorMessage = string.Format("Model {0}, does not match SerialNoIdentifier '{1}' from database Model '{2}\n" +
                                                 "Modelo '{0}' no coincide con Numero Serial '{1}' del Modelo {2} de la base de datos.",
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

      

       

       
        private async Task GenerateLabel(string modelNo, string serialNo, string departmentNo, string engineSerial, string upc,string description)
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
                textBoxProductionDate.Text = DateTime.Today.ToShortDateString();
                u.GlblSettings = GlblSettings;
                u.GetLabel(fileName, modelNo, departmentNo, serialNo,upc, description);
                ClearForm();
                Serial_No__Tracker slt = new Serial_No__Tracker();
                slt.Assembly_Line_No_ = int.Parse(GlblSettings.AssemblyLine);
                slt.Item_Model_Number = GlblSettings.ModelNumber;
                slt.Location = m_dataClass.GetAssemblyLineLocation((int)slt.Assembly_Line_No_);
                slt.Engine_Serial_No_ = engineSerial;
                slt.Serial_No_ = serialNo;
                slt.Production_Date_Time = DateTime.Parse(textBoxProductionDate.Text);
                lblStatus.ForeColor = Color.Black;
                if (!m_dataClass.InsertSerialInfo(slt))
                {
                    lblStatus.Text = "Failure";
                    lblStatus.ForeColor = Color.Red;
                    throw (new Exception(m_dataClass.ErrorMessage));
                }
                else
                {
                    lblStatus.ForeColor = Color.DarkGreen;
                    lblStatus.Text = "Success";
                    if (GlblSettings.SuppressPrinting)
                    {
                        lblStatus.Text = "Success - Label printing disabled.";
                    }
                    BcApiResult result = await bc.PostSerialTrackerToBusinessCentral(slt);
                    if (result.Success )
                    {
                        toolStripStatusLabel1.Text = result.Message;
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = result.Message;
                    }
                }
                
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
                    msg = string.Format(@"Serial No: {0} exist in database.\n. Numero Serial '{0}' existe en la base de datos.", scanLabel);
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
                msg = string.Format("The system can not print labels right now. Please check previous error message.\n" +
                     "El systema no puede imprimir labels en este momento. Por favor refiera al previo error.");
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
                                var r =  GenerateLabel(GlblSettings.ModelNumber, preprintedBarcode, "D25P",serialNo  ,upc, description);
                                LoadSerialTracker();
                                dataGridViewLabelHistory.Refresh();
                                this.ActiveControl = textBoxPreprintedBarcode;
                            }
                            else
                            {
                                msg = string.Format(@"Serial No: {0} does not match Engine Serial {1}." + 
                                      System.Environment.NewLine + "Numero Serial {0} no coincide con el serial del Motor '{1}'", textBoxEngineBarcode.Text, serialNo);
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

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void toolStripButtonPrinter_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                // Send a printer-specific to the printer.
                RawPrinterHelper.SendFileToPrinter(GlblSettings.PrinterName, @"C:\work\Labels\LJK.pdf");
            }
        }

        private async void toolStripButtonTransmit_Click(object sender, EventArgs e)
        {
            List<Serial_No__Tracker> listOfTracker = m_dataClass.LoadSerialTracker();
            bool AllSent = false;
            int i = 0;
            int sent = 0;
            BcApiResult result = new BcApiResult();
            if (listOfTracker != null)
            {
                foreach(Serial_No__Tracker tracker in listOfTracker)
                {
                    i++;
                   result =  await bc.PostSerialTrackerToBusinessCentral(tracker);
                    if (result.Success)
                    {
                        toolStripStatusLabel1.Text = result.Message;
                        sent++;
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = result.Message;
                    }
                }
                if (sent < i)
                {
                    MessageBox.Show("Error Sending data to BC: " + result.Message);
                }
            }

           
        }
       
    }
}
