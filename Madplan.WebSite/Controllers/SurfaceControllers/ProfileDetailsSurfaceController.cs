using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Umbraco.Web.Mvc;
using Madplan.WebSite.Models;
using System.Web.Security;


namespace Madplan.WebSite.Controllers.SurfaceControllers
{ 
    public class ProfileDetailsSurfaceController : SurfaceController
    {

		MembershipProvider SqlMembershipProvider
		{
			get { return Membership.Providers["SqlProvider"]; }
		}

		//Method for rendering partial view with @Html.Action("RenderProfileDetails","ProfileDetailsSurface");
		[ChildActionOnly]
        public ActionResult RenderProfileDetails()
		{
			return PartialView("ProfileDetails", new ProfileDetailsModel());
		}

		//endpoint for posting data to a surface controller action
	    [HttpPost]
        public ActionResult HandleProfileDetails(ProfileDetailsModel model)
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

		[HttpPost]
		public ActionResult Login(ProfileDetailsModel model)
		{
			MembershipUser user = null;
			bool loginresult = SqlMembershipProvider.ValidateUser(model.Name, model.Password);

			if (loginresult)
			{
				user = SqlMembershipProvider.GetUser(model.Name, true);
				FormsAuthentication.SetAuthCookie(user.UserName, model.Persistent);
			}

			var result = new { Result = loginresult, User = user };
			
			return Json(result);
		}

		[HttpPost]
		public ActionResult CreateUser(ProfileDetailsModel model)
		{ 
			MembershipCreateStatus status = new MembershipCreateStatus();
			SqlMembershipProvider.CreateUser(model.Name, model.Password, model.Email, "A", "B", true, Guid.NewGuid(), out status);

			var result = new { Status = status, Name = model.Name };
			return Json(result);
		}
	}
}