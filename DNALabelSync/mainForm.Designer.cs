
namespace DNALabelSync
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoadSerialMatch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLoadAssemblyLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLoadItemMaster = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoadSerialMatch,
            this.toolStripSeparator1,
            this.toolStripButtonSettings,
            this.toolStripSeparator2,
            this.toolStripButtonLoadAssemblyLine,
            this.toolStripSeparator3,
            this.toolStripButtonLoadItemMaster});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1067, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLoadSerialMatch
            // 
            this.toolStripButtonLoadSerialMatch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadSerialMatch.Image")));
            this.toolStripButtonLoadSerialMatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadSerialMatch.Name = "toolStripButtonLoadSerialMatch";
            this.toolStripButtonLoadSerialMatch.Size = new System.Drawing.Size(115, 24);
            this.toolStripButtonLoadSerialMatch.Text = "Serial Match";
            this.toolStripButtonLoadSerialMatch.Click += new System.EventHandler(this.toolStripButtonLoadSerialMatch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonSettings
            // 
            this.toolStripButtonSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSettings.Image")));
            this.toolStripButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSettings.Name = "toolStripButtonSettings";
            this.toolStripButtonSettings.Size = new System.Drawing.Size(86, 28);
            this.toolStripButtonSettings.Text = "&Settings";
            this.toolStripButtonSettings.Click += new System.EventHandler(this.toolStripButtonSettings_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonLoadAssemblyLine
            // 
            this.toolStripButtonLoadAssemblyLine.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadAssemblyLine.Image")));
            this.toolStripButtonLoadAssemblyLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadAssemblyLine.Name = "toolStripButtonLoadAssemblyLine";
            this.toolStripButtonLoadAssemblyLine.Size = new System.Drawing.Size(127, 28);
            this.toolStripButtonLoadAssemblyLine.Text = "Assembly Line";
            this.toolStripButtonLoadAssemblyLine.Click += new System.EventHandler(this.toolStripButtonLoadAssemblyLine_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonLoadItemMaster
            // 
            this.toolStripButtonLoadItemMaster.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadItemMaster.Image")));
            this.toolStripButtonLoadItemMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadItemMaster.Name = "toolStripButtonLoadItemMaster";
            this.toolStripButtonLoadItemMaster.Size = new System.Drawing.Size(112, 24);
            this.toolStripButtonLoadItemMaster.Text = "Item &Master";
            this.toolStripButtonLoadItemMaster.Click += new System.EventHandler(this.toolStripButtonLoadItemMaster_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mainForm";
            this.Text = "DNA Label Match";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadSerialMatch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadAssemblyLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadItemMaster;
    }
}

