using System.Web.Mvc;

namespace isvb.dev.Areas.DashboardAPI
{
    public class DashboardAPIAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DashboardAPI";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DashboardAPI_default",
                "DashboardAPI/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}