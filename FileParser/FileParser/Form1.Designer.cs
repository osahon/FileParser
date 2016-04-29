namespace FileParser
{
	partial class Form1
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
            this.lblCountry = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.ofdInputFile = new System.Windows.Forms.OpenFileDialog();
            this.lblInputFfile = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.txtOutPutFilePath = new System.Windows.Forms.TextBox();
            this.lblOutPutFilePath = new System.Windows.Forms.Label();
            this.btnStartProcessing = new System.Windows.Forms.Button();
            this.btnBrowseOutputPath = new System.Windows.Forms.Button();
            this.btnBrowseInputFile = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(27, 35);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 0;
            this.lblCountry.Text = "Country";
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(117, 31);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(259, 21);
            this.cmbCountry.TabIndex = 1;
            // 
            // ofdInputFile
            // 
            this.ofdInputFile.FileName = "openFileDialog1";
            // 
            // lblInputFfile
            // 
            this.lblInputFfile.AutoSize = true;
            this.lblInputFfile.Location = new System.Drawing.Point(27, 76);
            this.lblInputFfile.Name = "lblInputFfile";
            this.lblInputFfile.Size = new System.Drawing.Size(50, 13);
            this.lblInputFfile.TabIndex = 2;
            this.lblInputFfile.Text = "Input File";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(117, 72);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(259, 20);
            this.txtInputFile.TabIndex = 3;
            // 
            // txtOutPutFilePath
            // 
            this.txtOutPutFilePath.Location = new System.Drawing.Point(117, 112);
            this.txtOutPutFilePath.Name = "txtOutPutFilePath";
            this.txtOutPutFilePath.Size = new System.Drawing.Size(259, 20);
            this.txtOutPutFilePath.TabIndex = 5;
            // 
            // lblOutPutFilePath
            // 
            this.lblOutPutFilePath.AutoSize = true;
            this.lblOutPutFilePath.Location = new System.Drawing.Point(27, 117);
            this.lblOutPutFilePath.Name = "lblOutPutFilePath";
            this.lblOutPutFilePath.Size = new System.Drawing.Size(83, 13);
            this.lblOutPutFilePath.TabIndex = 4;
            this.lblOutPutFilePath.Text = "Output File Path";
            // 
            // btnStartProcessing
            // 
            this.btnStartProcessing.Location = new System.Drawing.Point(301, 198);
            this.btnStartProcessing.Name = "btnStartProcessing";
            this.btnStartProcessing.Size = new System.Drawing.Size(75, 23);
            this.btnStartProcessing.TabIndex = 6;
            this.btnStartProcessing.Text = "Start";
            this.btnStartProcessing.UseVisualStyleBackColor = true;
            // 
            // btnBrowseOutputPath
            // 
            this.btnBrowseOutputPath.Location = new System.Drawing.Point(382, 110);
            this.btnBrowseOutputPath.Name = "btnBrowseOutputPath";
            this.btnBrowseOutputPath.Size = new System.Drawing.Size(46, 23);
            this.btnBrowseOutputPath.TabIndex = 7;
            this.btnBrowseOutputPath.Text = "Browse";
            this.btnBrowseOutputPath.UseVisualStyleBackColor = true;
            this.btnBrowseOutputPath.Click += new System.EventHandler(this.btnBrowseOutputPath_Click);
            // 
            // btnBrowseInputFile
            // 
            this.btnBrowseInputFile.Location = new System.Drawing.Point(382, 69);
            this.btnBrowseInputFile.Name = "btnBrowseInputFile";
            this.btnBrowseInputFile.Size = new System.Drawing.Size(46, 23);
            this.btnBrowseInputFile.TabIndex = 8;
            this.btnBrowseInputFile.Text = "Browse";
            this.btnBrowseInputFile.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(382, 198);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 252);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBrowseInputFile);
            this.Controls.Add(this.btnBrowseOutputPath);
            this.Controls.Add(this.btnStartProcessing);
            this.Controls.Add(this.txtOutPutFilePath);
            this.Controls.Add(this.lblOutPutFilePath);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.lblInputFfile);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.lblCountry);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblCountry;
		private System.Windows.Forms.ComboBox cmbCountry;
		private System.Windows.Forms.OpenFileDialog ofdInputFile;
		private System.Windows.Forms.Label lblInputFfile;
		private System.Windows.Forms.TextBox txtInputFile;
		private System.Windows.Forms.TextBox txtOutPutFilePath;
		private System.Windows.Forms.Label lblOutPutFilePath;
		private System.Windows.Forms.Button btnStartProcessing;
        private System.Windows.Forms.Button btnBrowseOutputPath;
        private System.Windows.Forms.Button btnBrowseInputFile;
        private System.Windows.Forms.Button btnClose;
    }
}

