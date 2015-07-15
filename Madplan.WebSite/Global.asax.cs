using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Madplan.ClassLibrary.Services;
using Madplan.WebSite.Controllers.SurfaceControllers;
using Umbraco.Web;

namespace Madplan.WebSite
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class MadplanApplication : Umbraco.Web.UmbracoApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

		protected override void OnApplicationStarted(object sender, EventArgs e)
		{
			base.OnApplicationStarted(sender, e);

			var builder = new ContainerBuilder();

			// register controllers
			builder.RegisterType<AccountSurfaceController>().SingleInstance();
			builder.RegisterType<FoodProductsListSurfaceController>().SingleInstance();
			builder.RegisterType<UserDataSurfaceController>().SingleInstance();
			
			// register services
			builder.RegisterType<FoodProductService>().As<IFoodProductService>();
			builder.RegisterType<UserdataService>().As<IUserdataService>();

			IContainer container = builder.Build();

			AutofacDependencyResolver resolver = new AutofacDependencyResolver(container);
			//GlobalConfiguration.Configuration.DependencyResolver = resolver;
			DependencyResolver.SetResolver(resolver);

		}
	}
}