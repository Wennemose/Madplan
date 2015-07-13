using System.ComponentModel.DataAnnotations; 
namespace Madplan.WebSite.Models
{ 
	public class ProfileDetailsModel
	{
		[MaxLength(50)]
		[Required]
		public string Name {get; set;}

		[Required]
		public string Email { get; set; }

		public int Id {get; set;}
		
		public double Weight {get; set;}
		
		public double Height {get; set;}
		
		public int Age {get; set;}

		public string Password { get; set; }
	}
}