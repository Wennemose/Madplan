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

		[Required]
		public string Password { get; set; }

		public bool Persistent { get; set; }
	}
}