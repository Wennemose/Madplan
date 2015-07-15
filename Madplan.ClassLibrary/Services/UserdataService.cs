using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Madplan.ClassLibrary.Services
{
    public class UserdataService : IUserdataService
    {
        public UserdataService()
        {
        }

        public int SetUserData(Userdata userdata)
        {
			int result = -1;
			using (FoodplanEntities context = new FoodplanEntities())
			{
				Userdata original = context.Userdata.FirstOrDefault(u => u.UserId == userdata.UserId);

				if (original != null)
				{
					original.Age = userdata.Age;
					original.Height = userdata.Height;
					original.Weight = userdata.Weight;
				}
				else
				{
					context.Userdata.Add(userdata);
				}

				
				result = context.SaveChanges();
			}

			return result;
        }

        public Userdata GetUserData(Guid id)
        {
			Userdata result = null;
			using (FoodplanEntities context = new FoodplanEntities())
			{
				result = context.Userdata.Include("aspnet_Users").FirstOrDefault(u => u.UserId == id);
			}

			return result;
        }


    }
}
