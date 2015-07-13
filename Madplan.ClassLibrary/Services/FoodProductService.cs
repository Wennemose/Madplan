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
using Madplan.ClassLibrary.Models.FoodProduct;

namespace Madplan.ClassLibrary.Services
{
	public class FoodProductService : IFoodProductService
	{

		private string _connectionString;

		public FoodProductService(string connectionString)
		{
			_connectionString = connectionString;
		}

		public FoodProductService()
		{
		}

		public List<FoodProduct> GetAllFoodProducts()
		{
			List<FoodProduct> result = new List<FoodProduct>();

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					using (SqlCommand command = connection.CreateCommand())
					{
						command.CommandType = CommandType.StoredProcedure;
						command.CommandText = "GetAllFoodProducts";

						connection.Open();

						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								FoodProduct product = new FoodProduct();
								product.Calories = Convert.ToDecimal(reader["Calories"]);
								product.Carbonhydrate = Convert.ToDecimal(reader["Carbonhydrate"]);
								product.Fat = Convert.ToDecimal(reader["Fat"]);
								product.Id = Convert.ToInt32(reader["Id"]);
								product.Names["da-DK"] = Convert.ToString(reader["da-DK"]);
								product.Names["en-US"] = Convert.ToString(reader["en-US"]);
								product.Protein = Convert.ToDecimal(reader["Protein"]);

								result.Add(product);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw;
			}

			return result;
			
		}

		public List<FoodProduct> GetFoodProduct(int id)
		{
			throw new NotImplementedException();
		}

		public int AddFoodProduct(FoodProduct foodProduct)
		{
			int result = -1;

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					using (SqlCommand command = connection.CreateCommand())
					{
						string danish = foodProduct.Names["da-DK"];
						command.CommandText = "AddFoodProduct";
						command.Parameters.AddWithValue("@daDK", foodProduct.Names["da-DK"]);
						command.Parameters.AddWithValue("@enUS", foodProduct.Names["en-US"]);
						command.Parameters.AddWithValue("@protein", foodProduct.Protein);
						command.Parameters.AddWithValue("@fat", foodProduct.Fat);
						command.Parameters.AddWithValue("@carbonhydrate", foodProduct.Carbonhydrate);
						command.Parameters.AddWithValue("@calories", foodProduct.Calories);

						command.CommandType = CommandType.StoredProcedure;
						connection.Open();
						result = (int)command.ExecuteScalar();
					}
				}
			}
			catch (Exception ex)
			{
				
				throw;
			}
		

			return result;
		}

		public bool DeleteFoodProduct(int id)
		{
			throw new NotImplementedException();
		}

		public bool UpdateFoodProduct(FoodProduct foodProduct)
		{
			throw new NotImplementedException();
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

								product.Names.Add("da-DK", daDK);
								product.Names.Add("en-US", enUS);

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
