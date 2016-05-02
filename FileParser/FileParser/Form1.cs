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
using FileParser.Models;

namespace FileParser
{
	public partial class Form1 : Form
	{
		private List<CountryConfig> ConfigList => LoadCountryVariables();
        public Form1()
		{
			InitializeComponent();
			
		}

		private void BindCountryComboBox()
		{
			cmbCountry.DataSource = ConfigList.OrderBy(cl => cl.Country).ToList();
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
		}

		private void CmbCountry_SelectedValueChanged(object sender, EventArgs e)
		{
			var senderComboBox = (ComboBox)sender;
			var selectedCountryConfig = (CountryConfig) senderComboBox.SelectedItem;
            
		}

        private void btnBrowseOutputPath_Click(object sender, EventArgs e)
        {


        }
		
	}
}
