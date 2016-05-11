using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Models
{
	public class TobaccoData
	{
		public string Country { get; set; }
		public string Year { get; set; }
		public decimal? PercentTotal { get; set; }
		public decimal? LowerNintyFivePercentTotal { get; set; }
		public decimal? UpperNintyFivePercentTotal { get; set; }
		public int? TotalN { get; set; }

		public decimal? PercentMale { get; set; }
		public decimal? LowerNintyFivePercentMale { get; set; }
		public decimal? UpperNintyFivePercentMale { get; set; }
		public int? NMale { get; set; }

		public decimal? PercentFemale { get; set; }
		public decimal? LowerNintyFivePercentFemale { get; set; }
		public decimal? UpperNintyFivePercentFemale { get; set; }
		public int? NFemale { get; set; }

		public decimal? Percent13 { get; set; }
		public decimal? LowerNintyFivePercent13 { get; set; }
		public decimal? UpperNintyFivePercent13 { get; set; }
		public int? N13 { get; set; }

		public decimal? Percent14 { get; set; }
		public decimal? LowerNintyFivePercent14 { get; set; }
		public decimal? UpperNintyFivePercent14 { get; set; }
		public int? N14 { get; set; }

		public decimal? Percent15 { get; set; }
		public decimal? LowerNintyFivePercent15 { get; set; }
		public decimal? UpperNintyFivePercent15 { get; set; }
		public int? N15 { get; set; }
	}
}
