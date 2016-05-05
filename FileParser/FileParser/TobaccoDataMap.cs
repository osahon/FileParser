using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using FileParser.Models;

namespace FileParser
{
	public sealed class TobaccoDataMap : CsvClassMap<TobaccoData>
	{
		public TobaccoDataMap()
		{
			Map(m => m.PercentTotal).Name("Total Percent");
			Map(m => m.PercentMale).Name("Male");
			Map(m => m.PercentFemale).Name("Female");
			Map(m => m.Percent13).Name("13 Years");
			Map(m => m.Percent14).Name("14 Years");
			Map(m => m.Percent15).Name("15 Years");

			Map(m => m.LowerNintyFivePercentTotal).Name("Lower 95 Total Percent");
			Map(m => m.LowerNintyFivePercentMale).Name("Lower 95 Male");
			Map(m => m.LowerNintyFivePercentFemale).Name("Lower 95 Female");
			Map(m => m.LowerNintyFivePercent13).Name("Lower 95 13 Years");
			Map(m => m.LowerNintyFivePercent14).Name("Lower 95 14 Years");
			Map(m => m.LowerNintyFivePercent15).Name("Lower 95 15 Years");

			Map(m => m.UpperNintyFivePercentTotal).Name("Upper 95 Total Percent");
			Map(m => m.UpperNintyFivePercentMale).Name("Upper 95 Male");
			Map(m => m.UpperNintyFivePercentFemale).Name("Upper 95 Female");
			Map(m => m.UpperNintyFivePercent13).Name("Upper 95 13 Years");
			Map(m => m.UpperNintyFivePercent14).Name("Upper 95 14 Years");
			Map(m => m.UpperNintyFivePercent15).Name("Upper 95 15 Years");

			Map(m => m.TotalN).Name("N Total Percent");
			Map(m => m.NMale).Name("N Male");
			Map(m => m.NFemale).Name("N Female");
			Map(m => m.N13).Name("N 13 Years");
			Map(m => m.N14).Name("N 14 Years");
			Map(m => m.N15).Name("N 15 Years");

		}
	}
}
