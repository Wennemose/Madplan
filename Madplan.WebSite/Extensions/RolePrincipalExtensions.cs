using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Madplan.WebSite.Extensions
{
	public static class RolePrincipalExtensions
	{

		public static Guid UserKey(this RolePrincipal principal)
		{ 
			MembershipProvider membershipProvider = Membership.Providers["SqlProvider"];
			MembershipUser user = membershipProvider.GetUser(principal.Identity.Name, false);
			return new Guid(user.ProviderUserKey.ToString());
		}
	}
}