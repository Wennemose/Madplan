using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Umbraco.Web.Mvc;
using Madplan.WebSite.Models;


namespace Madplan.WebSite.Controllers.SurfaceControllers
{ 
    public class ProfileToolsSurfaceController : SurfaceController
    {
		//Method for rendering partial view with @Html.Action("RenderProfileTools","ProfileToolsSurface");
		[ChildActionOnly]
        public ActionResult RenderProfileTools(){
			return PartialView("ProfileTools", new ProfileToolsModel());
		}

		//endpoint for posting data to a surface controller action
	    [HttpPost]
        public ActionResult HandleProfileTools(ProfileToolsModel model)
        {
			//model not valid, do not save, but return current umbraco page
			if (!ModelState.IsValid)
			{
				//Perhaps you might want to add a custom message to the TempData or ViewBag
				//which will be available on the View when it renders (since we're not 
				//redirecting)          
				return CurrentUmbracoPage();
			}


			//if validation passes perform whatever logic
			//In this sample we keep it empty, but try setting a breakpoint to see what is posted here

			//Perhaps you might want to store some data in TempData which will be available 
			//in the View after the redirect below. An example might be to show a custom 'submit
			//successful' message on the View, for example:
			//TempData.Add("CustomMessage", "Your form was successfully submitted at " + DateTime.Now)

			//redirect to current page to clear the form
			return RedirectToCurrentUmbracoPage();

			//Or redirect to specific page
			//return RedirectToUmbracoPage(12345)
        }
	}
}