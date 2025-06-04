
namespace DNALabelSync
{
    partial class FrmSerialMatch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSerialMatch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblLastScanLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonClearFields = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProductionDate = new System.Windows.Forms.TextBox();
            this.textBoxModelNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPreprintedBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEngineBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxTestMode = new System.Windows.Forms.CheckBox();
            this.dateTimePickerShipDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControlResult = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.richTextBoxMessages = new System.Windows.Forms.RichTextBox();
            this.tabPageLabels = new System.Windows.Forms.TabPage();
            this.webBrowserLabels = new System.Windows.Forms.WebBrowser();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridViewLabelHistory = new System.Windows.Forms.DataGridView();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonExportCSV = new System.Windows.Forms.ToolStripButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurrentAssemblyLine = new System.Windows.Forms.Label();
            this.lblCurrentModel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tabControlResult.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPageLabels.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLabelHistory)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip3);
            this.splitContainer1.Panel2.Controls.Add(this.tabControlResult);
            this.splitContainer1.Size = new System.Drawing.Size(1468, 560);
            this.splitContainer1.SplitterDistance = 684;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.LblLastScanLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonClearFields);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxProductionDate);
            this.groupBox1.Controls.Add(this.textBoxModelNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxPreprintedBarcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxEngineBarcode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 403);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Label Information";
            // 
            // LblLastScanLabel
            // 
            this.LblLastScanLabel.AutoSize = true;
            this.LblLastScanLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLastScanLabel.Location = new System.Drawing.Point(180, 299);
            this.LblLastScanLabel.Name = "LblLastScanLabel";
            this.LblLastScanLabel.Size = new System.Drawing.Size(65, 26);
            this.LblLastScanLabel.TabIndex = 14;
            this.LblLastScanLabel.Text = "Label";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Last Label";
            // 
            // buttonClearFields
            // 
            this.buttonClearFields.Location = new System.Drawing.Point(570, 352);
            this.buttonClearFields.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClearFields.Name = "buttonClearFields";
            this.buttonClearFields.Size = new System.Drawing.Size(85, 41);
            this.buttonClearFields.TabIndex = 12;
            this.buttonClearFields.Text = "&Clear fields";
            this.buttonClearFields.UseVisualStyleBackColor = true;
            this.buttonClearFields.Click += new System.EventHandler(this.buttonClearFields_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Production Date:";
            // 
            // textBoxProductionDate
            // 
            this.textBoxProductionDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProductionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProductionDate.Location = new System.Drawing.Point(133, 250);
            this.textBoxProductionDate.Name = "textBoxProductionDate";
            this.textBoxProductionDate.Size = new System.Drawing.Size(530, 23);
            this.textBoxProductionDate.TabIndex = 10;
            // 
            // textBoxModelNo
            // 
            this.textBoxModelNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxModelNo.Enabled = false;
            this.textBoxModelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxModelNo.Location = new System.Drawing.Point(133, 177);
            this.textBoxModelNo.Multiline = true;
            this.textBoxModelNo.Name = "textBoxModelNo";
            this.textBoxModelNo.Size = new System.Drawing.Size(532, 48);
            this.textBoxModelNo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Model No.";
            // 
            // textBoxPreprintedBarcode
            // 
            this.textBoxPreprintedBarcode.AcceptsReturn = true;
            this.textBoxPreprintedBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPreprintedBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPreprintedBarcode.Location = new System.Drawing.Point(133, 65);
            this.textBoxPreprintedBarcode.Multiline = true;
            this.textBoxPreprintedBarcode.Name = "textBoxPreprintedBarcode";
            this.textBoxPreprintedBarcode.Size = new System.Drawing.Size(532, 48);
            this.textBoxPreprintedBarcode.TabIndex = 0;
            this.textBoxPreprintedBarcode.TextChanged += new System.EventHandler(this.textBoxPreprintedBarcode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Product Rating Barcode";
            // 
            // textBoxEngineBarcode
            // 
            this.textBoxEngineBarcode.AcceptsReturn = true;
            this.textBoxEngineBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEngineBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEngineBarcode.Location = new System.Drawing.Point(133, 118);
            this.textBoxEngineBarcode.Multiline = true;
            this.textBoxEngineBarcode.Name = "textBoxEngineBarcode";
            this.textBoxEngineBarcode.Size = new System.Drawing.Size(531, 45);
            this.textBoxEngineBarcode.TabIndex = 1;
            this.textBoxEngineBarcode.TextChanged += new System.EventHandler(this.textBoxEngineBarcode_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Engine Barcode:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblCurrentModel);
            this.groupBox2.Controls.Add(this.lblCurrentAssemblyLine);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.checkBoxTestMode);
            this.groupBox2.Controls.Add(this.dateTimePickerShipDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 127);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shipper";
            // 
            // checkBoxTestMode
            // 
            this.checkBoxTestMode.AutoSize = true;
            this.checkBoxTestMode.Location = new System.Drawing.Point(570, 18);
            this.checkBoxTestMode.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTestMode.Name = "checkBoxTestMode";
            this.checkBoxTestMode.Size = new System.Drawing.Size(77, 17);
            this.checkBoxTestMode.TabIndex = 34;
            this.checkBoxTestMode.Text = "Test Mode";
            this.checkBoxTestMode.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerShipDate
            // 
            this.dateTimePickerShipDate.Location = new System.Drawing.Point(107, 22);
            this.dateTimePickerShipDate.Name = "dateTimePickerShipDate";
            this.dateTimePickerShipDate.Size = new System.Drawing.Size(179, 20);
            this.dateTimePickerShipDate.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Production Date:";
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripSeparator9});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(780, 31);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonRefresh.ForeColor = System.Drawing.Color.Blue;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(79, 28);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 31);
            // 
            // tabControlResult
            // 
            this.tabControlResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlResult.Controls.Add(this.tabPage7);
            this.tabControlResult.Controls.Add(this.tabPageLabels);
            this.tabControlResult.Controls.Add(this.tabPage6);
            this.tabControlResult.Location = new System.Drawing.Point(3, 34);
            this.tabControlResult.Name = "tabControlResult";
            this.tabControlResult.SelectedIndex = 0;
            this.tabControlResult.Size = new System.Drawing.Size(773, 526);
            this.tabControlResult.TabIndex = 1;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.richTextBoxMessages);
            this.tabPage7.ImageIndex = 0;
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(765, 500);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Messages";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // richTextBoxMessages
            // 
            this.richTextBoxMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxMessages.ForeColor = System.Drawing.Color.Blue;
            this.richTextBoxMessages.Location = new System.Drawing.Point(0, 3);
            this.richTextBoxMessages.Name = "richTextBoxMessages";
            this.richTextBoxMessages.Size = new System.Drawing.Size(897, 520);
            this.richTextBoxMessages.TabIndex = 0;
            this.richTextBoxMessages.Text = "";
            // 
            // tabPageLabels
            // 
            this.tabPageLabels.Controls.Add(this.webBrowserLabels);
            this.tabPageLabels.ImageIndex = 2;
            this.tabPageLabels.Location = new System.Drawing.Point(4, 22);
            this.tabPageLabels.Name = "tabPageLabels";
            this.tabPageLabels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLabels.Size = new System.Drawing.Size(753, 428);
            this.tabPageLabels.TabIndex = 2;
            this.tabPageLabels.Text = "Labels";
            this.tabPageLabels.UseVisualStyleBackColor = true;
            // 
            // webBrowserLabels
            // 
            this.webBrowserLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserLabels.Location = new System.Drawing.Point(3, 3);
            this.webBrowserLabels.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserLabels.Name = "webBrowserLabels";
            this.webBrowserLabels.Size = new System.Drawing.Size(747, 422);
            this.webBrowserLabels.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dataGridViewLabelHistory);
            this.tabPage6.Controls.Add(this.toolStrip4);
            this.tabPage6.ImageIndex = 3;
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(753, 428);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Label History";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLabelHistory
            // 
            this.dataGridViewLabelHistory.AllowUserToAddRows = false;
            this.dataGridViewLabelHistory.AllowUserToDeleteRows = false;
            this.dataGridViewLabelHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLabelHistory.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLabelHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLabelHistory.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewLabelHistory.Location = new System.Drawing.Point(6, 28);
            this.dataGridViewLabelHistory.Name = "dataGridViewLabelHistory";
            this.dataGridViewLabelHistory.ReadOnly = true;
            this.dataGridViewLabelHistory.RowHeadersWidth = 51;
            this.dataGridViewLabelHistory.Size = new System.Drawing.Size(753, 399);
            this.dataGridViewLabelHistory.TabIndex = 1;
            // 
            // toolStrip4
            // 
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonExportCSV});
            this.toolStrip4.Location = new System.Drawing.Point(3, 3);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(747, 27);
            this.toolStrip4.TabIndex = 0;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripButtonExportCSV
            // 
            this.toolStripButtonExportCSV.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExportCSV.Image")));
            this.toolStripButtonExportCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportCSV.Name = "toolStripButtonExportCSV";
            this.toolStripButtonExportCSV.Size = new System.Drawing.Size(88, 24);
            this.toolStripButtonExportCSV.Text = "Export CSV";
            this.toolStripButtonExportCSV.Click += new System.EventHandler(this.toolStripButtonExportCSV_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Assembly Line:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Model No.:";
            // 
            // lblCurrentAssemblyLine
            // 
            this.lblCurrentAssemblyLine.AutoSize = true;
            this.lblCurrentAssemblyLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAssemblyLine.Location = new System.Drawing.Point(103, 49);
            this.lblCurrentAssemblyLine.Name = "lblCurrentAssemblyLine";
            this.lblCurrentAssemblyLine.Size = new System.Drawing.Size(0, 24);
            this.lblCurrentAssemblyLine.TabIndex = 37;
            // 
            // lblCurrentModel
            // 
            this.lblCurrentModel.AutoSize = true;
            this.lblCurrentModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentModel.Location = new System.Drawing.Point(103, 85);
            this.lblCurrentModel.Name = "lblCurrentModel";
            this.lblCurrentModel.Size = new System.Drawing.Size(16, 24);
            this.lblCurrentModel.TabIndex = 38;
            this.lblCurrentModel.Text = ".";
            // 
            // FrmSerialMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 560);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSerialMatch";
            this.Text = "FrmSerialMatch";
            this.Load += new System.EventHandler(this.FrmSerialMatch_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabControlResult.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPageLabels.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLabelHistory)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEngineBarcode;
        private System.Windows.Forms.TextBox textBoxPreprintedBarcode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePickerShipDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.TabControl tabControlResult;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.RichTextBox richTextBoxMessages;
        private System.Windows.Forms.TabPage tabPageLabels;
        private System.Windows.Forms.WebBrowser webBrowserLabels;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridViewLabelHistory;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportCSV;
        private System.Windows.Forms.TextBox textBoxModelNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProductionDate;
        private System.Windows.Forms.Button buttonClearFields;
        private System.Windows.Forms.CheckBox checkBoxTestMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblLastScanLabel;
        private System.Windows.Forms.Label lblCurrentModel;
        private System.Windows.Forms.Label lblCurrentAssemblyLine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}