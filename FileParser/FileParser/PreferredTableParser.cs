using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileParser.Models;

namespace FileParser
{
	public class PreferredTableParser
	{

		public static TobaccoData Parse(string inputFile, CountryConfig configVar)
		{
			string startSearchCriteria = "Analysis Variable" + " " + configVar.CSmoker;
			string endSearchCriteria = "n ";


			int startIndex = 0;
			int endIndex = 0;

			var allInputData = File.ReadAllLines(inputFile);
			foreach (var lineItem in allInputData)
			{
				if (lineItem.TrimStart().Contains(startSearchCriteria))
				{
					startIndex = Array.IndexOf(allInputData, lineItem);
				}
				if (lineItem.TrimStart().StartsWith(endSearchCriteria))
				{
					endIndex = Array.IndexOf(allInputData, lineItem);
				}

				if (startIndex > 0 && endIndex > 0 && endIndex > startIndex)
					break;
			}

			var allDataSubset = allInputData.Skip(startIndex).Take(endIndex - startIndex + 1).ToArray();
			foreach (var lineItem in allDataSubset)
			{
				if (lineItem.TrimStart().Contains("%"))
				{
					startIndex = Array.IndexOf(allDataSubset, lineItem);
					break;
				}
			}
			var linesWorthProcessing = allDataSubset.Skip(startIndex).ToArray();
			var percentData = linesWorthProcessing[0].Trim().Substring(10).Replace("     ", "|").Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			var lower95Data = linesWorthProcessing[3].Trim().Substring(10).Replace("     ", "|").Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			var upper95Data = linesWorthProcessing[6].Trim().Substring(10).Replace("     ", "|").Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			var nData = linesWorthProcessing[8].Trim().Substring(10).Replace("    ", "|").Replace(",", "").Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			return new TobaccoData
			{
				Country = configVar.Country,
				Year = configVar.Year,
				PercentTotal = Convert.ToDecimal(percentData[0]),
				PercentMale = Convert.ToDecimal(percentData[1]),
				PercentFemale = Convert.ToDecimal(percentData[2]),
				Percent13 = Convert.ToDecimal(percentData[3]),
				Percent14 = Convert.ToDecimal(percentData[4]),
				Percent15 = Convert.ToDecimal(percentData[5]),

				LowerNintyFivePercentTotal = Convert.ToDecimal(lower95Data[0]),
				LowerNintyFivePercentMale = Convert.ToDecimal(lower95Data[1]),
				LowerNintyFivePercentFemale = Convert.ToDecimal(lower95Data[2]),
				LowerNintyFivePercent13 = Convert.ToDecimal(lower95Data[3]),
				LowerNintyFivePercent14 = Convert.ToDecimal(lower95Data[4]),
				LowerNintyFivePercent15 = Convert.ToDecimal(lower95Data[5]),

				UpperNintyFivePercentTotal = Convert.ToDecimal(upper95Data[0]),
				UpperNintyFivePercentMale = Convert.ToDecimal(upper95Data[1]),
				UpperNintyFivePercentFemale = Convert.ToDecimal(upper95Data[2]),
				UpperNintyFivePercent13 = Convert.ToDecimal(upper95Data[3]),
				UpperNintyFivePercent14 = Convert.ToDecimal(upper95Data[4]),
				UpperNintyFivePercent15 = Convert.ToDecimal(upper95Data[5]),

				TotalN = Convert.ToInt32(nData[0]),
				NMale = Convert.ToInt32(nData[1]),
				NFemale = Convert.ToInt32(nData[2]),
				N13 = Convert.ToInt32(nData[3]),
				N14 = Convert.ToInt32(nData[4]),
				N15 = Convert.ToInt32(nData[5])

			};
		}
	}

}