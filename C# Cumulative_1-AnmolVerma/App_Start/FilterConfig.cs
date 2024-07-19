using System.Web;
using System.Web.Mvc;

namespace C__Cumulative_1_AnmolVerma
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
