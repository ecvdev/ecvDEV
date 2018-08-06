using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ecvLib.Core.HtmlHelpers
{
    public static class UIHelpers
    {

        public static MvcHtmlString readonlyControl(this MvcHtmlString htmlString, Func<bool> expression)
        {
            if (expression.Invoke())
            {
                var html = htmlString.ToString();
                const string _readonly = "\"readonly\"";
                html = html.Insert(html.IndexOf("/>",
                  StringComparison.Ordinal), " readonly= " + _readonly);
                return new MvcHtmlString(html);

            }
            return htmlString;
        }

        public static MvcHtmlString disableControl(this MvcHtmlString htmlString, Func<bool> expression)
        {
            if (expression.Invoke())
            {
                var html = htmlString.ToString();
                const string _disabled = "\"disabled\"";
                html = html.Insert(html.IndexOf(">",
                  StringComparison.Ordinal), " disabled= " + _disabled);
                return new MvcHtmlString(html);

            }
            return htmlString;
        }

    }// End of -- public static class UIHelpers
}
