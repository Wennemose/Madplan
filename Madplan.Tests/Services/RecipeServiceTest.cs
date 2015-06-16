using System;
using System.Collections.Generic;
using Madplan.ClassLibrary.Models.Recipe;
using Madplan.ClassLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Madplan.Tests.Services
{
	[TestClass]
	public class RecipeServiceTest
	{
		[TestMethod]
		public void TestAddRecipe()
		{
			// SETUP
			RecipeService recipeService = new RecipeService();
			Recipe recipe = new Recipe();
			recipe.Name = "Rødgrød med fløde";
			recipe.Calories = 1000000;

			// TEST
			bool result = recipeService.AddRecipes(recipe);

			List<Recipe> allRecipes = recipeService.GetAllRecipes();

			// ASSERTS
			Assert.IsTrue(result);
			Assert.IsTrue(allRecipes.Contains(recipe));
			
		}
	}
}
