using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Madplan.ClassLibrary;
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

		public string Query {get; set;}
		
		public List<FoodProduct> FoodProducts {get; set;}
	}
}