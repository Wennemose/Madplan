using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madplan.ClassLibrary.Models.Recipe;

namespace Madplan.ClassLibrary.Services
{
	public class RecipeService : IRecipeService
	{
		public List<Recipe> GetAllRecipes()
		{
			List<Recipe> result = new List<Recipe>();

			// TODO: Load all recipes into result

			return result;
		}

		public bool AddRecipes(Recipe recipe)
		{
			bool result = false;

			// TODO: Add recipe to SQL table

			return result;
		}
	}
}
