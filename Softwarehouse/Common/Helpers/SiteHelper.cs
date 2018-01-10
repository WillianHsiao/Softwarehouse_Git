﻿using System.Web;

namespace Common.Helpers
{
    public static class SiteHelper
    {
        public static bool IsLogin()
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                return true;
            }
            else
            {
                return false;
            }
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
