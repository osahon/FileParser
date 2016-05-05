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
			this.fbdOutputFilePath = new System.Windows.Forms.FolderBrowserDialog();
			this.lblYear = new System.Windows.Forms.Label();
			this.cmbYear = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblCountry
			// 
			this.lblCountry.AutoSize = true;
			this.lblCountry.Location = new System.Drawing.Point(54, 67);
			this.lblCountry.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblCountry.Name = "lblCountry";
			this.lblCountry.Size = new System.Drawing.Size(87, 25);
			this.lblCountry.TabIndex = 0;
			this.lblCountry.Text = "Country";
			// 
			// cmbCountry
			// 
			this.cmbCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbCountry.FormattingEnabled = true;
			this.cmbCountry.Location = new System.Drawing.Point(234, 60);
			this.cmbCountry.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.cmbCountry.Name = "cmbCountry";
			this.cmbCountry.Size = new System.Drawing.Size(246, 33);
			this.cmbCountry.TabIndex = 1;
			// 
			// ofdInputFile
			// 
			this.ofdInputFile.FileName = "openFileDialog1";
			// 
			// lblInputFfile
			// 
			this.lblInputFfile.AutoSize = true;
			this.lblInputFfile.Location = new System.Drawing.Point(54, 146);
			this.lblInputFfile.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblInputFfile.Name = "lblInputFfile";
			this.lblInputFfile.Size = new System.Drawing.Size(100, 25);
			this.lblInputFfile.TabIndex = 2;
			this.lblInputFfile.Text = "Input File";
			// 
			// txtInputFile
			// 
			this.txtInputFile.Location = new System.Drawing.Point(234, 138);
			this.txtInputFile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.txtInputFile.Name = "txtInputFile";
			this.txtInputFile.Size = new System.Drawing.Size(514, 31);
			this.txtInputFile.TabIndex = 3;
			// 
			// txtOutPutFilePath
			// 
			this.txtOutPutFilePath.Location = new System.Drawing.Point(234, 215);
			this.txtOutPutFilePath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.txtOutPutFilePath.Name = "txtOutPutFilePath";
			this.txtOutPutFilePath.Size = new System.Drawing.Size(514, 31);
			this.txtOutPutFilePath.TabIndex = 5;
			// 
			// lblOutPutFilePath
			// 
			this.lblOutPutFilePath.AutoSize = true;
			this.lblOutPutFilePath.Location = new System.Drawing.Point(54, 225);
			this.lblOutPutFilePath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblOutPutFilePath.Name = "lblOutPutFilePath";
			this.lblOutPutFilePath.Size = new System.Drawing.Size(167, 25);
			this.lblOutPutFilePath.TabIndex = 4;
			this.lblOutPutFilePath.Text = "Output File Path";
			// 
			// btnStartProcessing
			// 
			this.btnStartProcessing.Location = new System.Drawing.Point(548, 381);
			this.btnStartProcessing.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnStartProcessing.Name = "btnStartProcessing";
			this.btnStartProcessing.Size = new System.Drawing.Size(150, 44);
			this.btnStartProcessing.TabIndex = 6;
			this.btnStartProcessing.Text = "Start";
			this.btnStartProcessing.UseVisualStyleBackColor = true;
			this.btnStartProcessing.Click += new System.EventHandler(this.btnStartProcessing_Click);
			// 
			// btnBrowseOutputPath
			// 
			this.btnBrowseOutputPath.Location = new System.Drawing.Point(764, 212);
			this.btnBrowseOutputPath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnBrowseOutputPath.Name = "btnBrowseOutputPath";
			this.btnBrowseOutputPath.Size = new System.Drawing.Size(106, 44);
			this.btnBrowseOutputPath.TabIndex = 7;
			this.btnBrowseOutputPath.Text = "Browse";
			this.btnBrowseOutputPath.UseVisualStyleBackColor = true;
			this.btnBrowseOutputPath.Click += new System.EventHandler(this.btnBrowseOutputPath_Click);
			// 
			// btnBrowseInputFile
			// 
			this.btnBrowseInputFile.Location = new System.Drawing.Point(764, 133);
			this.btnBrowseInputFile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnBrowseInputFile.Name = "btnBrowseInputFile";
			this.btnBrowseInputFile.Size = new System.Drawing.Size(106, 44);
			this.btnBrowseInputFile.TabIndex = 8;
			this.btnBrowseInputFile.Text = "Browse";
			this.btnBrowseInputFile.UseVisualStyleBackColor = true;
			this.btnBrowseInputFile.Click += new System.EventHandler(this.btnBrowseInputFile_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(718, 381);
			this.btnClose.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(150, 44);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lblYear
			// 
			this.lblYear.AutoSize = true;
			this.lblYear.Location = new System.Drawing.Point(506, 71);
			this.lblYear.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(58, 25);
			this.lblYear.TabIndex = 9;
			this.lblYear.Text = "Year";
			// 
			// cmbYear
			// 
			this.cmbYear.FormattingEnabled = true;
			this.cmbYear.Location = new System.Drawing.Point(576, 60);
			this.cmbYear.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.cmbYear.Name = "cmbYear";
			this.cmbYear.Size = new System.Drawing.Size(172, 33);
			this.cmbYear.TabIndex = 10;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(972, 485);
			this.Controls.Add(this.cmbYear);
			this.Controls.Add(this.lblYear);
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
			this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.Name = "Form1";
			this.Text = " ";
			this.Load += new System.EventHandler(this.Form1_Load);
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
		private System.Windows.Forms.FolderBrowserDialog fbdOutputFilePath;
		private System.Windows.Forms.Label lblYear;
		private System.Windows.Forms.ComboBox cmbYear;
	}
}

