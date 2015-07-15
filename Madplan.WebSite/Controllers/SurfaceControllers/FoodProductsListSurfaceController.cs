using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Umbraco.Web.Mvc;
using Madplan.WebSite.Models;
using Madplan.ClassLibrary;
using Madplan.ClassLibrary.Services;
using System.Configuration;

using Autofac;
using Autofac.Integration.Mvc;

namespace Madplan.WebSite.Controllers.SurfaceControllers
{ 
    public class FoodProductsListSurfaceController : SurfaceController
    {

		private IFoodProductService _foodProductService;
/*
		public FoodProductsListSurfaceController(FoodProductService foodProductService)
		{
			_foodProductService = foodProductService;
		}
		*/
		public FoodProductsListSurfaceController()
		{
			_foodProductService = new FoodProductService();//DependencyResolver.Current.GetService(typeof(IFoodProductService)) as IFoodProductService;
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
			List<FoodProduct> products = _foodProductService.GetAllFoodProducts();
			if (!ModelState.IsValid)
			{ 
				return CurrentUmbracoPage();
			}
			if(!string.IsNullOrEmpty(model.Query))
			{
				products = _foodProductService.GetAllFoodProducts().Where(p => p.Name.ToLower().Contains(model.Query.ToLower())).ToList();
			}
			
			model.FoodProducts = products;

			return Json(model);
        }
	}
}