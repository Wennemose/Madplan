using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madplan.ClassLibrary.Services
{
	public interface IFoodProductService
	{
		List<FoodProduct> GetAllFoodProducts();
		FoodProduct GetFoodProduct(int id);
		int AddFoodProduct(FoodProduct foodProduct);
		int DeleteFoodProduct(FoodProduct foodProduct);
		int UpdateFoodProduct(FoodProduct foodProduct);
		bool ReadFvdbFile(string path);
	}
}
