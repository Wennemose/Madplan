using Madplan.ClassLibrary.Models.UserData;
using System;
using System.ComponentModel.DataAnnotations; 
namespace Madplan.WebSite.Models
{ 
	public class UserDataModel
	{
		public Guid Id {get; set;}
		[Required]
		public int Weight {get; set;}
		[Required]
		public int Height {get; set;}
		[Required]
		public int Age {get; set;}


        public UserData ToUserData()
        {

            UserData userdata = new UserData();

            userdata.Height = this.Height;
            userdata.Weight = this.Weight;
            userdata.Age = this.Age;
            userdata.Id = this.Id;

            return userdata;
        }
        
    }
}