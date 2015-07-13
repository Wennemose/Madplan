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

			builder.Register(c => UmbracoContext.Current).AsSelf();

			builder.RegisterControllers(typeof(MadplanApplication).Assembly);
			builder.RegisterControllers(Assembly.GetExecutingAssembly());


			// register services
			builder.RegisterType<FoodProductService>().As<IFoodProductService>();

			IContainer container = builder.Build();

			AutofacDependencyResolver resolver = new AutofacDependencyResolver(container);
			//GlobalConfiguration.Configuration.DependencyResolver = resolver;
			DependencyResolver.SetResolver(resolver);

		}
	}
}