namespace Razor.App.HtmlHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string imageUrl, string alt = null, int? width = null, int? height = null)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);
            if (alt != null)
            {
                builder.MergeAttribute("alt", alt);
            }

            if (width != null)
            {
                builder.MergeAttribute("width", width.ToString());
            }

            if (height != null)
            {
                builder.MergeAttribute("height", height.ToString());
            }

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString YouTube(this HtmlHelper helper, string videoId, int? width = null, int? height = null)
        {
            TagBuilder builder = new TagBuilder("iframe");
            builder.MergeAttribute("width", width != null ? width.ToString() : "560");
            builder.MergeAttribute("height", height != null ? height.ToString() : "315");
            builder.MergeAttribute("src", $"https://www.youtube.com/embed/{videoId}");
            builder.MergeAttribute("frameborder", "0");
            builder.MergeAttribute("allowfullscreen", "");

            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString Table(this HtmlHelper helper, IEnumerable<object> collection, params string[] cssClasses)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<table #class>");
            bool hasHeaders = false;
            foreach (var item in collection)
            {
                PropertyInfo[] properties = item.GetType().GetProperties();
                if (!hasHeaders)
                {
                    builder.AppendLine("<tr>");
                    foreach (PropertyInfo propertyInfo in properties)
                    {
                        builder.AppendLine($"<th>{propertyInfo.Name}</th>");
                    }

                    builder.AppendLine("</tr>");
                    hasHeaders = true;
                }

                builder.AppendLine("<tr>");
                foreach (PropertyInfo propertyInfo in properties)
                {
                    builder.AppendLine($"<td>{propertyInfo.GetValue(item)}</td>");
                }

                builder.AppendLine("</tr>");

            }

            builder.AppendLine("</table>");

            if (cssClasses.Any())
            {
                StringBuilder classBuilder = new StringBuilder();
                classBuilder.Append("class=\"table ");
                foreach (string cssClass in cssClasses)
                {
                    if (cssClass == "table-condensed")
                    {
                        classBuilder = classBuilder.Replace("table", string.Empty);
                    }

                    classBuilder.Append(cssClass + " ");
                }

                classBuilder.Append('"');
                builder = builder.Replace("#class", classBuilder.ToString());
            }
            else
            {
                builder = builder.Replace("#class", string.Empty);
            }

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}