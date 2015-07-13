using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madplan.ClassLibrary.Models.FoodProduct
{
	public class FoodProduct
	{
		public int Id { get; set; }
		public Dictionary<string, string> Names { get; set; }
		public decimal Protein { get; set; }
		public decimal Carbonhydrate { get; set; }
		public decimal Fat { get; set; }
		public decimal Calories { get; set; }

		public string Name
		{
			get
			{
				return Names["da-DK"];
			}
		}

		public FoodProduct()
		{
			Names = new Dictionary<string, string>();
		}
	}
}
