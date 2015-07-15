using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Umbraco.Web.Mvc;
using Madplan.WebSite.Models;


using Madplan.WebSite.Extensions;
using Madplan.ClassLibrary.Services;
using System.Configuration;
using Madplan.ClassLibrary;
using System.Web.Security;
namespace Madplan.WebSite.Controllers.SurfaceControllers
{
	public class UserDataSurfaceController : SurfaceController
	{
		private IUserdataService _userdataService;



		public UserDataSurfaceController()
		{
			_userdataService = new UserdataService();
		}

		//Method for rendering partial view with @Html.Action("RenderUserData","UserDataSurface");
		public ActionResult RenderUserData()
		{
			UserDataModel model = new UserDataModel();

			Guid id = ((RolePrincipal)User).UserKey();

			Userdata userdata = _userdataService.GetUserData(id);

			if (userdata != null)
			{
				model.Age = userdata.Age;
				model.Height = userdata.Height;
				model.Weight = userdata.Weight;
				model.UserId = id;
			}

			return PartialView("UserData", model);
		}


		[HttpPost]
		public ActionResult SetUserData(UserDataModel model)
		{
			IUserdataService userdataservice = new UserdataService();

			Userdata data = model.ToUserData();
			data.UserId = ((RolePrincipal)User).UserKey();

			// Set userid
			int result = userdataservice.SetUserData(data);

			if (result == 1)
			{
				return Json(model);
			}

			return Json(result);


		}

	}
}