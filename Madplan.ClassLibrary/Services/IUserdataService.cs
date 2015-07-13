using Madplan.ClassLibrary.Models.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madplan.ClassLibrary.Services
{
    public interface IUserdataService

    {

        UserData GetUserData(Guid ID);

        bool SetUserData(UserData data);


    }
}
