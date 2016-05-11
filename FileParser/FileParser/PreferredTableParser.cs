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

       public string InputFile { get; set; }
       public ParseStatus Status { get; set; }
       public CountryConfig CountryConfigVariable { get; set; }

	    public PreferredTableParser(string inputFile, CountryConfig configVar)
	    {
	        InputFile = inputFile;
	        CountryConfigVariable = configVar;
	    }
       public TobaccoData Parse()
		{
           try
           {
                string startSearchCriteria = "Analysis Variable" + " " + CountryConfigVariable.CSmoker;
                string endSearchCriteria = "n ";


                int startIndex = 0;
                int endIndex = 0;

                var allInputData = File.ReadAllLines(InputFile);
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
                decimal tryParseOutDecimal;
                int tryParseOutInt;
                var rtnTobaccoData = new TobaccoData
                {

                    Country = CountryConfigVariable.Country,
                    Year = CountryConfigVariable.Year,
                    PercentTotal = System.Decimal.TryParse(percentData[0], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    PercentMale = System.Decimal.TryParse(percentData[1], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    PercentFemale = System.Decimal.TryParse(percentData[2], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    Percent13 = System.Decimal.TryParse(percentData[3], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    Percent14 = System.Decimal.TryParse(percentData[4], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    Percent15 = System.Decimal.TryParse(percentData[5], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,

                    LowerNintyFivePercentTotal = System.Decimal.TryParse(lower95Data[0], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    LowerNintyFivePercentMale = System.Decimal.TryParse(lower95Data[1], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    LowerNintyFivePercentFemale = System.Decimal.TryParse(lower95Data[2], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    LowerNintyFivePercent13 = System.Decimal.TryParse(lower95Data[3], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    LowerNintyFivePercent14 = System.Decimal.TryParse(lower95Data[4], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    LowerNintyFivePercent15 = System.Decimal.TryParse(lower95Data[5], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,

                    UpperNintyFivePercentTotal = System.Decimal.TryParse(upper95Data[0], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    UpperNintyFivePercentMale = System.Decimal.TryParse(upper95Data[1], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    UpperNintyFivePercentFemale = System.Decimal.TryParse(upper95Data[2], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    UpperNintyFivePercent13 = System.Decimal.TryParse(upper95Data[3], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    UpperNintyFivePercent14 = System.Decimal.TryParse(upper95Data[4], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,
                    UpperNintyFivePercent15 = System.Decimal.TryParse(upper95Data[5], out tryParseOutDecimal) ? (decimal?)tryParseOutDecimal : null,

                    TotalN = System.Int32.TryParse(nData[0], out tryParseOutInt) ? (int?)tryParseOutInt : null,
                    NMale = System.Int32.TryParse(nData[1], out tryParseOutInt) ? (int?)tryParseOutInt : null,
                    NFemale = System.Int32.TryParse(nData[2], out tryParseOutInt) ? (int?)tryParseOutInt : null,
                    N13 = System.Int32.TryParse(nData[3], out tryParseOutInt) ? (int?)tryParseOutInt : null,
                    N14 = System.Int32.TryParse(nData[4], out tryParseOutInt) ? (int?)tryParseOutInt : null,
                    N15 = System.Int32.TryParse(nData[5], out tryParseOutInt) ? (int?)tryParseOutInt : null,

                };
                if (!rtnTobaccoData.PercentTotal.HasValue || !rtnTobaccoData.PercentMale.HasValue ||
                    !rtnTobaccoData.PercentFemale.HasValue || !rtnTobaccoData.Percent13.HasValue ||
                    !rtnTobaccoData.Percent14.HasValue || !rtnTobaccoData.Percent15.HasValue ||

                    !rtnTobaccoData.LowerNintyFivePercentTotal.HasValue || !rtnTobaccoData.LowerNintyFivePercentMale.HasValue ||
                    !rtnTobaccoData.LowerNintyFivePercentFemale.HasValue || !rtnTobaccoData.LowerNintyFivePercent13.HasValue ||
                    !rtnTobaccoData.LowerNintyFivePercent14.HasValue || !rtnTobaccoData.LowerNintyFivePercent15.HasValue ||

                    !rtnTobaccoData.UpperNintyFivePercentTotal.HasValue || !rtnTobaccoData.UpperNintyFivePercentMale.HasValue ||
                    !rtnTobaccoData.UpperNintyFivePercentFemale.HasValue || !rtnTobaccoData.UpperNintyFivePercent13.HasValue ||
                    !rtnTobaccoData.UpperNintyFivePercent14.HasValue || !rtnTobaccoData.UpperNintyFivePercent15.HasValue ||

                    !rtnTobaccoData.TotalN.HasValue || !rtnTobaccoData.NMale.HasValue ||
                    !rtnTobaccoData.NFemale.HasValue || !rtnTobaccoData.N13.HasValue ||
                    !rtnTobaccoData.N14.HasValue || !rtnTobaccoData.N15.HasValue)
                    Status = ParseStatus.SuccessWithNulls;
                else
                    Status = ParseStatus.Sucess;

                return rtnTobaccoData;
            }
           catch (Exception)
           {
                Status = ParseStatus.Error;
                return new TobaccoData();
           }

		}
	}

}