using Common.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Helper.Attributes
{
    public class FrontEndAuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            #region 原生 OnAuthorization 的應用
            base.OnAuthorization(filterContext);

            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            // allowList內的action發生時，直接回應，不用再檢查RoleID的處理
            List<string> allowList = new List<string> { "Login", "Error" };
            if (filterContext.Result is HttpUnauthorizedResult || (controllerName == "Authorize" && allowList.Contains(actionName)) || (string.Equals(controllerName, "Home", StringComparison.OrdinalIgnoreCase) && string.Equals(actionName, "Index", StringComparison.OrdinalIgnoreCase)))
            {
                if (HttpContext.Current.Session[FrontEndMemberHelper.KEY_CURRENT_USER] == null)
                {
                    HttpContext.Current.Session.RemoveAll();

                    FormsAuthentication.SignOut();

                    RedirectTo(filterContext);

                    return;
                }
                return;
            }
            #endregion

            #region 自訂 RoleID 對應 Menus 的檢查
            if (HttpContext.Current.Session[FrontEndMemberHelper.KEY_CURRENT_USER] == null)
            {
                // 理論上這裡不該會發生
                RedirectTo(filterContext);
                return;
            }

            string sessionVal = HttpContext.Current.Session[FrontEndMemberHelper.KEY_CURRENT_USER].ToString();
            List<string> valContiner = sessionVal.Split('|').ToList();
            bool isNeedRedirect = false;
            if (valContiner.Count != 2)
            {
                // Session異常
                filterContext.HttpContext.Session.Remove(FrontEndMemberHelper.KEY_CURRENT_USER);
                RedirectTo(filterContext);
                return;
            }
            if (isNeedRedirect)
            {
                // 可以走到這步表示已經登入過，但沒有可用的群組或Menu，讓他到一頁空白(歡迎頁)的地方
                RedirectTo(filterContext, "Home", "Index");
                return;
            }
            #endregion
        }

        private static void RedirectTo(AuthorizationContext filterContext, string controller = "Authorize", string action = "Login")
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                AjaxResult r = new AjaxResult(false, "None Login", null);
                filterContext.Result = new JsonResult
                {
                    Data = r,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller,
                    action
                }));
            }
        }
    }
}
