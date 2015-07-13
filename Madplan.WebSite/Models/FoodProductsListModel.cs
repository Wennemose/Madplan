using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Madplan.ClassLibrary.Models.FoodProduct; 
namespace Madplan.WebSite.Models
{ 
	public class FoodProductsListModel
	{
		public FoodProductsListModel()
		{

		}

		public FoodProductsListModel(List<FoodProduct> foodproducts)
		{
			FoodProducts = foodproducts;
		}

		[Required]
		public string Query {get; set;}
		
		public List<FoodProduct> FoodProducts {get; set;}
	}
}