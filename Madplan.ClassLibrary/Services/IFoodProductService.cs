using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madplan.ClassLibrary.Models.FoodProduct;

namespace Madplan.ClassLibrary.Services
{
	interface IFoodProductService
	{
		List<FoodProduct> GetAllFoodProducts();
		List<FoodProduct> GetFoodProduct(int id);
		int AddFoodProduct(FoodProduct foodProduct);
		bool DeleteFoodProduct(int id);
		bool UpdateFoodProduct(FoodProduct foodProduct);
		bool ReadFvdbFile(string path);
	}
}
