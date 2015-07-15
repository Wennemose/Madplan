using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Madplan.ClassLibrary.Services
{
	public class FoodProductService : IFoodProductService
	{
		public FoodProductService()
		{
		}

		public List<FoodProduct> GetAllFoodProducts()
		{
			List<FoodProduct> result = null;
			using (FoodplanEntities context = new FoodplanEntities())
			{
				result = context.FoodProduct.Include("Recipes").ToList();
			}

			return result;
		}

		public FoodProduct GetFoodProduct(int id)
		{
			FoodProduct result = null;
			using (FoodplanEntities context = new FoodplanEntities())
			{
				result = context.FoodProduct.Include("Recipes").Where(p => p.Id == id).FirstOrDefault();
			}
			return result;
		}

		public int AddFoodProduct(FoodProduct foodProduct)
		{
			int result = -1;
			using (FoodplanEntities context = new FoodplanEntities())
			{
				context.FoodProduct.Add(foodProduct);
				result = context.SaveChanges();
			}

			return result;
		}

		public int DeleteFoodProduct(FoodProduct foodProduct)
		{
			int result = -1;
			using (FoodplanEntities context = new FoodplanEntities())
			{
				context.FoodProduct.Remove(foodProduct);
				result = context.SaveChanges();
			}

			return result;
		}

		public int UpdateFoodProduct(FoodProduct foodProduct)
		{
			int result = -1;
			using (FoodplanEntities context = new FoodplanEntities())
			{
				FoodProduct original = context.FoodProduct.FirstOrDefault(p => p.Id == foodProduct.Id);

				original.Calories = foodProduct.Calories;
				original.Carbonhydrate = foodProduct.Carbonhydrate;
				original.Fat = foodProduct.Fat;
				original.Name = foodProduct.Name;
				original.Protein = foodProduct.Protein;

				result = context.SaveChanges();
			}

			return result;
		}


		public bool ReadFvdbFile(string path)
		{
			bool result = true;

			try
			{
				using (XmlReader reader = XmlReader.Create(path))
				{
					reader.MoveToContent();
					XElement foodElement = null;

					while (reader.Read())
					{
						// Process all food nodes
						if (reader.NodeType == XmlNodeType.Element && reader.Name == "Food")
						{
							foodElement = XElement.ReadFrom(reader) as XElement;

							// Add food element
							if (foodElement != null)
							{
								FoodProduct product = new FoodProduct();

								CultureInfo ci = new CultureInfo("en-US");

								product.Calories = Convert.ToDecimal(GetFoodComponent(foodElement, "ENERC"),ci);
								product.Protein = Convert.ToDecimal(GetFoodComponent(foodElement, "PROT"),ci);
								product.Fat = Convert.ToDecimal(GetFoodComponent(foodElement, "FAT"),ci);
								product.Carbonhydrate = Convert.ToDecimal(GetFoodComponent(foodElement, "CHO"),ci);

								string daDK = foodElement.Descendants("FoodName").Where(fn => fn.Attribute("language").Value == "da").First().Value;
								string enUS = foodElement.Descendants("FoodName").Where(fn => fn.Attribute("language").Value == "en").First().Value;

								product.Name = daDK;
								//product.Names.Add("en-US", enUS);

								AddFoodProduct(product);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				result = false;
			}

			return result;
		}

		private string GetFoodComponent(XElement foodElement, string componentname)
		{
			XElement component = foodElement.Descendants("ComponentIdentifier").Where(c => c.Attribute("system").Value == "ecompid" && c.Value == componentname).First();
			string componentValue = component.Parent.Parent.Element("Values").Element("Value").Element("SelectedValue").Value;

			return componentValue;
		}
	}
}
