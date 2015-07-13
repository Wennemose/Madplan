using System.ComponentModel.DataAnnotations; 
namespace Madplan.WebSite.Models
{ 
	public class UserDataModel
	{
		public int Id {get; set;}
		[Required]
		public string Weight {get; set;}
		[Required]
		public string Height {get; set;}
		[Required]
		public string Age {get; set;}
	}
}