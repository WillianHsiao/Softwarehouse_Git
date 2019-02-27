using Common.StringDefine;
using System.Web;

namespace Helper
{
    public static class SiteHelper
    {
        public static bool IsLogin()
        {
            return HttpContext.Current.Request.IsAuthenticated && HttpContext.Current.Session[StringDefine.KEY_CURRENT_USER] != null;
        }

        public static string ProjectTitle
        {
            get
            {
                return "Softwarehouse";
            }
        }
    }
}
