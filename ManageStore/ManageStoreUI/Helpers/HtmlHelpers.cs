using Microsoft.AspNetCore.Mvc.Rendering;
using static System.String;

namespace ManageStoreUI.Helpers
{
    public static class HtmlHelpers
    {

        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {
            if (IsNullOrEmpty(cssClass))
                cssClass = "active";

            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (IsNullOrEmpty(controller))
                controller = currentController;

            if (IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : Empty;
        }

        public static string PageClass(this IHtmlHelper htmlHelper)
        {
            var currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

    }
}
