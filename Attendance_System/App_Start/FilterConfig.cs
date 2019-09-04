using System.Web;
using System.Web.Mvc;

namespace Attendance_System
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //All views global have to be authorized
            filters.Add(new AuthorizeAttribute());
        }
    }
}
