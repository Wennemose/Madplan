using System.ComponentModel.DataAnnotations; 
namespace Madplan.WebSite.Models
{ 
	public class AccountModel
	{
		[MaxLength(50)]
		[Required]
		public string Name {get; set;}

		[Required]
		public string Email {get; set;}

		[MinLength(8)]
		[Required]
		public string Password {get; set;}

		[Compare("Password")]
		public string ConfirmPassword { get; set; }

		public bool Persistent {get; set;}
	}
}