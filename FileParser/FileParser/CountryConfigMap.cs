using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using FileParser.Models;

namespace FileParser
{
	public sealed class CountryConfigMap : CsvClassMap<CountryConfig>
	{
		public CountryConfigMap()
		{
			Map(m => m.Country).Name("Country");
			Map(m => m.Year).Name("Year");
			Map(m => m.Filename).Name("filename");
			Map(m => m.SexVariable).Name("sex variable");
			Map(m => m.AgeVarialbe).Name("age variable");
			Map(m => m.LevelVariable).Name("level variable");
			Map(m => m.CTOB).Name("CTOB");
			Map(m => m.OTOB).Name("OTOB");
			Map(m => m.CSmoker).Name("CSMOKER");
		}
	}
}
