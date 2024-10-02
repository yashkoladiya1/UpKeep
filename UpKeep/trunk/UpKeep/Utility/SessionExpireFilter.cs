using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UpKeep.Utility
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                if (SessionDetails.UserSession == null)
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.HttpContext.Response.End();
                }
            }
            else
            {
                if (SessionDetails.UserSession == null)
                {
                    filterContext.Result = new RedirectResult("~/Home/Login");
                    return;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    if (SessionFacade.UserSession == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        var routeData = ((MvcHandler)httpContext.Handler).RequestContext.RouteData;
        //        var routeControl = (string)routeData.Values["controller"];
        //        var routeAction = (string)routeData.Values["action"];

        //        if (routeControl.Equals("Window") || routeControl.Equals("SpecialCheck") || routeControl.Equals("Intake") || routeControl.Equals("Assortment") || routeControl.Equals("WeightCheck"))
        //        {
        //            if (SessionFacade.UserSession.ROLE_ID == (int)UserRole.CLIENT)
        //                return false;
        //            else
        //                return true;
        //        }
        //        else if (routeControl.Equals("Batch") || routeControl.Equals("LabUser") || routeAction.Equals("Client_configuration"))
        //        {
        //            if (SessionFacade.UserSession.ROLE_ID == (int)UserRole.LAB_USER)
        //                return false;
        //            else
        //                return true;
        //        }
        //        else if (routeControl.Equals("LabAdmin") || routeControl.Equals("SystemAdmin"))
        //        {
        //            if (SessionFacade.UserSession.ROLE_ID == (int)UserRole.SUPER_ADMIN || SessionFacade.UserSession.ROLE_ID == (int)UserRole.LAB_ADMIN)
        //                return true;
        //            else
        //                return false;
        //        }
        //        else if (routeControl.Equals("Invoice"))
        //        {
        //            if (SessionFacade.UserSession.ROLE_ID == (int)UserRole.LAB_ADMIN || SessionFacade.UserSession.ROLE_ID == (int)UserRole.LAB_USER)
        //                return true;
        //            else
        //                return false;
        //        }
        //        else
        //            return true;
        //    }
        //}

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (SessionDetails.UserSession == null)
            {
                return false;
            }
            else
            {
                if (httpContext.Request.IsAjaxRequest())
                {
                    return true;
                }
                else
                {
                    var routeData = ((MvcHandler)httpContext.Handler).RequestContext.RouteData;
                    var routeControl = (string)routeData.Values["controller"];
                    var routeAction = (string)routeData.Values["action"];

                    //if (routeAction.ToLower().Equals("dashboard") || routeAction.ToLower().Equals("blogdetails") | routeAction.ToLower().Equals("changeuserpassword"))
                    //    return true;
                    //else if (routeAction.ToLower().Equals("daily_price_specific") || routeAction.ToLower().Equals("downloadvariantup") || routeAction.ToLower().Equals("downloadrapafile5") || routeAction.ToLower().Equals("downloadrapafile6") || routeAction.ToLower().Equals("downloadfile") || routeAction.ToLower().Equals("fileuploaded") || routeAction.ToLower().Equals("downloadrapafile") || routeAction.ToLower().Equals("downloadrapafile3") || routeAction.ToLower().Equals("downloadrapafile2") || routeAction.ToLower().Equals("downloadrapafile4") || routeAction.ToLower().Equals("downloadmixpricefile"))
                    //    return true;
                    //else
                    return true;// FormPermissionHelper.CheckFormPermission(routeAction, routeControl);
                }
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (SessionDetails.UserSession == null)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
            else
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "error", action = "Unauthorised" }));
        }
    }
}