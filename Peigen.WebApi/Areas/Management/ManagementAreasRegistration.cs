using System.Web.Mvc;

namespace Peigen.WebApi
{
    public class ManagementAreasRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return AreaNames.Management;
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Management_default",
                "Management/{controller}/{action}/{id}", 
                new { action = "Index", id = UrlParameter.Optional }
                );
        }


    }
}