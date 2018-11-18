using System.Web.Mvc;

namespace CP.WebApp.App_Code
{
	public class AuthWebController : BaseWebController
	{
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (!User.Identity.IsAuthenticated)
				Response.Redirect($"~/Login/Login?ReturnPage={Request.Url.PathAndQuery}");
			else
				base.OnActionExecuting(filterContext);
		}
	}
}