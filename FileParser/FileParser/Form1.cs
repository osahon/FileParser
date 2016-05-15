using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using FileParser.Models;
using FileParser.Extensions;

namespace FileParser
{
	public partial class Form1 : Form
	{
		private List<CountryConfig> ConfigList => LoadCountryVariables();
		private CountryConfig SelectedCountryConfig ;
		private List<TobaccoData> ValidOTOBDataList = new List<TobaccoData>();
        private List<TobaccoData> ValidCTOBDataList = new List<TobaccoData>();
        private List<TobaccoData> ValidCSMOKERDataList = new List<TobaccoData>();
        public Form1()
		{
			InitializeComponent();
			
		}

		private void BindCountryComboBox()
		{
			var listToBind = ConfigList.OrderBy(cl => cl.Country).ToList();
			listToBind.Insert(0, new CountryConfig { AgeVarialbe = String.Empty, Country = "Select Country", Year = string.Empty, Filename = string.Empty, CSmoker = string.Empty, CTOB = String.Empty, OTOB = string.Empty, SexVariable = String.Empty, LevelVariable = String.Empty});
			cmbCountry.DataSource = listToBind;
			cmbCountry.DisplayMember = "Country";
			cmbCountry.ValueMember = "Country";
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private List<CountryConfig> LoadCountryVariables()
		{
			string configFile = ConfigurationManager.AppSettings["CountryVariableList"];
            if (File.Exists(configFile))
			{
				using (var csv = new CsvReader(File.OpenText(configFile)))
				{
					csv.Configuration.RegisterClassMap<CountryConfigMap>();
					return csv.GetRecords<CountryConfig>().ToList();
				}
			}
			else
			{
				MessageBox.Show("Exception: Country Variable CSV Not Found", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return null;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			BindCountryComboBox();
			this.cmbCountry.SelectedValueChanged += CmbCountry_SelectedValueChanged;
			rtbInfoBox.Text = "";
			rtbInfoBox.TextChanged += RtbInfoBox_TextChanged;
		}

		private void RtbInfoBox_TextChanged(object sender, EventArgs e)
		{
			RichTextBox currentTextBox = (RichTextBox) sender;
			currentTextBox.ScrollToCaret();
		}

		private void CmbCountry_SelectedValueChanged(object sender, EventArgs e)
		{
			var senderComboBox = (ComboBox)sender;
			SelectedCountryConfig = (CountryConfig) senderComboBox.SelectedItem;
			
			var yearDataSourceList = ConfigList.Where(cl => cl.Country == SelectedCountryConfig.Country).Select(cl => cl.Year).ToList();
			yearDataSourceList.Insert(0, "Select Year");
			cmbYear.DataSource = yearDataSourceList;


		}

        private void btnBrowseOutputPath_Click(object sender, EventArgs e)
        {
	        if (fbdOutputFilePath.ShowDialog() == DialogResult.OK)
	        {
		        txtOutPutFilePath.Text = fbdOutputFilePath.SelectedPath;
	        }
        }

		private void btnBrowseInputFile_Click(object sender, EventArgs e)
		{
			if (ofdInputFile.ShowDialog() == DialogResult.OK)
			{
				txtInputFile.Text = ofdInputFile.FileName;
			}
		}

		private void btnStartProcessing_Click(object sender, EventArgs e)
		{
			if (IsValid())
			{
				try
                {
                    if (cblVariables.GetItemChecked(0))
                        ParseVariable(SelectedCountryConfig.CTOB, ConfigField.CTOB);

                    if (cblVariables.GetItemChecked(1))
                        ParseVariable(SelectedCountryConfig.CSmoker, ConfigField.CSMOKER);

                    if (cblVariables.GetItemChecked(2))
                        ParseVariable(SelectedCountryConfig.OTOB, ConfigField.OTOB);

                }
                catch (Exception)
				{
					rtbInfoBox.AppendTextColor(Environment.NewLine + txtInputFile.Text + " NOT processed!", Color.Red);
				}
				
			}
			else
			{
				MessageBox.Show("Error: Invalid input selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

        private void ParseVariable(string variableToParseFor, ConfigField inputConfigField)
        {
            var parserObject = new PreferredTableParser(txtInputFile.Text, SelectedCountryConfig);
            var parsedData = parserObject.Parse(variableToParseFor);
            switch (parserObject.Status)
            {
                case ParseStatus.Sucess:
                    LoadCorrectList(inputConfigField, parsedData);
                    rtbInfoBox.AppendTextColor(Environment.NewLine + txtInputFile.Text + " processed for " + variableToParseFor.ToString() + "!", Color.Black);
                    break;
                case ParseStatus.SuccessWithNulls:
                    LoadCorrectList(inputConfigField, parsedData);
                    rtbInfoBox.AppendTextColor(Environment.NewLine + txtInputFile.Text + " processed for " + variableToParseFor.ToString() + "! Empty Data Found", Color.Yellow);
                    break;
                default:
                    rtbInfoBox.AppendTextColor(Environment.NewLine + txtInputFile.Text + " NOT processed for " + variableToParseFor.ToString() + "!", Color.Red);
                    break;
            }
        }

	    private void LoadCorrectList(ConfigField configParam, TobaccoData dataToAdd)
	    {
	        switch (configParam)
	        {
                case ConfigField.CSMOKER:
                    ValidCSMOKERDataList.Add(dataToAdd);
	                break;
                case ConfigField.CTOB:
                    ValidCTOBDataList.Add(dataToAdd);
	                break;
                case ConfigField.OTOB:
                    ValidOTOBDataList.Add(dataToAdd);
	                break;
                default:
                    throw new InvalidDataException("Unkown config parameter " + configParam);
	                break;
	        }
	    }
        private bool IsValid()
		{
			if (cmbCountry.SelectedIndex == 0)
				return false;

			if (cmbYear.SelectedIndex == 0)
				return false;

			if (txtInputFile.Text.Trim().Length == 0)
				return false;

			if (txtOutPutFilePath.Text.Trim().Length == 0)
				return false;
			return true;
		}

		private void btnSaveData_Click(object sender, EventArgs e)
		{
            if (cblVariables.GetItemChecked(0))
                WriteToFile(SelectedCountryConfig.CTOB, ValidCTOBDataList);

            if (cblVariables.GetItemChecked(1))
                WriteToFile(SelectedCountryConfig.CSmoker, ValidCSMOKERDataList);

            if (cblVariables.GetItemChecked(2))
                WriteToFile(SelectedCountryConfig.OTOB, ValidOTOBDataList);
        }

	    private void WriteToFile(string variable, List<TobaccoData> validDataList)
	    {
            string outputFileName = txtOutPutFilePath.Text + "\\" + variable + "_" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ".csv";
            var csvConfig = new CsvConfiguration
            {
                DetectColumnCountChanges = true,
                ThrowOnBadData = true,
                Encoding = Encoding.UTF8
            };
            using (var fileStream = File.Open(outputFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            using (TextWriter textWriter = new StreamWriter(fileStream, new UTF8Encoding(false)))
            using (var csv = new CsvWriter(textWriter, csvConfig))
            {
                csv.Configuration.RegisterClassMap<TobaccoDataMap>();
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.ThrowOnBadData = false;
                csv.WriteRecords(validDataList);
            }
            MessageBox.Show("File(s) Saved: " + outputFileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 myAboutBox1 = new AboutBox1();
            myAboutBox1.Show();
        }

       
    }
}
