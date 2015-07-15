using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madplan.ClassLibrary.Services
{
	public interface IRecipeService
	{
		List<Recipe> GetAllRecipes();
		bool AddRecipes(Recipe recipe);
	}
}
