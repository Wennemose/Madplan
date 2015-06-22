using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Madplan.ClassLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Madplan.Tests.Services
{
	[TestClass]
	public class FoodProductServiceTest
	{
		[TestMethod]
		public void TestReadFvdbFile()
		{ 
			// SETUP
			FoodProductService foodProductService = new FoodProductService("Data Source=.;Initial Catalog=Foodplan;Integrated Security=True");
			
			// TEST
			bool result = foodProductService.ReadFvdbFile(@"..\..\..\Dependencies\fvdb\DKfdtp701.xml");

			// ASSERTS
			Assert.IsTrue(result);

		}
	}
}
