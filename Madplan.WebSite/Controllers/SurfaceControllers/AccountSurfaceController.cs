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
    public class AccountSurfaceController : SurfaceController
    {
		MembershipProvider SqlMembershipProvider
		{
			get { return Membership.Providers["SqlProvider"]; }
		}

		//Method for rendering partial view with @Html.Action("RenderAccount","AccountSurface");
		[ChildActionOnly]
        public ActionResult RenderAccount()
		{
			return PartialView("Account", new AccountModel());
		}

		[HttpPost]
		public ActionResult Login(AccountModel model)
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
		public ActionResult Create(AccountModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			MembershipCreateStatus status = new MembershipCreateStatus();
			SqlMembershipProvider.CreateUser(model.Name, model.Password, model.Email, "A", "B", true, Guid.NewGuid(), out status);

			if (status == MembershipCreateStatus.Success)
			{
				FormsAuthentication.SetAuthCookie(model.Name, false);
			}

			var result = new { Status = status.ToString(), Name = model.Name };
			return Json(result);
		}

		[HttpPost]
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();

			return Redirect("/");
		}
		
	}
}