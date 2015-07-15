using Madplan.ClassLibrary;
using System;
using System.ComponentModel.DataAnnotations; 
namespace Madplan.WebSite.Models
{ 
	public class UserDataModel
	{
		[Required]
		public Nullable<int> Weight { get; set; }
		[Required]
		public Nullable<int> Height { get; set; }
		[Required]
		public Nullable<int> Age { get; set; }

		public Guid UserId { get; set; }

        public Userdata ToUserData()
        {
            Userdata userdata = new Userdata();
            userdata.Height = this.Height;
            userdata.Weight = this.Weight;
            userdata.Age = this.Age;
			//userdata.UserId = this.UserId;
            return userdata;
        }
        
    }
}