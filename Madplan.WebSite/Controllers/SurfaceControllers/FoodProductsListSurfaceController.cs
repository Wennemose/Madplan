using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Umbraco.Web.Mvc;
using Madplan.WebSite.Models;
using Madplan.ClassLibrary.Models.FoodProduct;
using Madplan.ClassLibrary.Services;
using System.Configuration;

using Autofac;
using Autofac.Integration.Mvc;

namespace Madplan.WebSite.Controllers.SurfaceControllers
{ 
    public class FoodProductsListSurfaceController : SurfaceController
    {

		private IFoodProductService _foodProductService;
		private IRecipeService _recipeService;

		public FoodProductsListSurfaceController(IFoodProductService foodProductService, IRecipeService recipeService)
		{
			_foodProductService = foodProductService;
			_recipeService = recipeService;
		}
		
		public FoodProductsListSurfaceController()
		{
			_foodProductService = new FoodProductService(ConfigurationManager.ConnectionStrings["FoodDb"].ConnectionString);//DependencyResolver.Current.GetService(typeof(IFoodProductService)) as IFoodProductService;
		}
		
		//Method for rendering partial view with @Html.Action("RenderFoodProductsList","FoodProductsListSurface");
		[ChildActionOnly]
        public ActionResult RenderFoodProductsList()
		{
			List<FoodProduct> products = _foodProductService.GetAllFoodProducts();

			return PartialView("FoodProductsList", new FoodProductsListModel(products));
		}

		//endpoint for posting data to a surface controller action
	    [HttpPost]
		public ActionResult SearchProducts(FoodProductsListModel model)
        {
			//model not valid, do not save, but return current umbraco page
			if (!ModelState.IsValid)
			{
				//Perhaps you might want to add a custom message to the TempData or ViewBag
				//which will be available on the View when it renders (since we're not 
				//redirecting)          
				return CurrentUmbracoPage();
			}

			List<FoodProduct> products = _foodProductService.GetAllFoodProducts().Where(p => p.Names["da-DK"].Contains(model.Query)).ToList();
			model.FoodProducts = products;

			return Json(model);
			//return PartialView("FoodProductsList", new FoodProductsListModel(products));

			//if validation passes perform whatever logic
			//In this sample we keep it empty, but try setting a breakpoint to see what is posted here

			//Perhaps you might want to store some data in TempData which will be available 
			//in the View after the redirect below. An example might be to show a custom 'submit
			//successful' message on the View, for example:
			//TempData.Add("CustomMessage", "Your form was successfully submitted at " + DateTime.Now)

			//redirect to current page to clear the form
			//return RedirectToCurrentUmbracoPage();

			//Or redirect to specific page
			//return RedirectToUmbracoPage(12345)
        }
	}
}