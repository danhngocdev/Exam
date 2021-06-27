using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.CustomHelper
{
    public static class CustomHelper
    {
        //public static MvcHtmlString TagLink(this HtmlHelper helper, string textLink, string tagName, string[] htmlAttributes)
        //{
        //    TagBuilder tb = new TagBuilder("a");
        //    tb.SetInnerText(textLink);
        //    tb.AddCssClass(string.Join(" ", htmlAttributes));
        //    tagName = Uri.EscapeDataString(tagName.Trim());
        //    tb.Attributes.Add("href", $"/Tag/{tagName}");
        //    return new MvcHtmlString(tb.ToString());
        //}
        public static IHtmlString CategoryLink(this HtmlHelper helper, string cateName)
        {
            TagBuilder tb = new TagBuilder("a");
            tb.Attributes.Add("href", $"/Category/{cateName}");
            tb.AddCssClass("label-default");
            tb.Attributes.Add("style", "font-family: Arial;");

            return new MvcHtmlString(tb.ToString());
        }
        public static IHtmlString TagLink( string tagName,string url)
        {
            //string LableStr = $"<label style=\"background-color:gray;color:yellow;font-size:24px\">{tagName}</label>";
            var urlSlug = string.Format("Tag/{0}", url);
            string LableStr = $"<div> <a style=\" color:red\" href=\"{urlSlug}\">{tagName}</a></div>";
            return new HtmlString(LableStr);
            //TagBuilder tagA = new TagBuilder("a");
            //foreach (string item in listItems) {

            //    tagA.Attributes.Add("href", $"/Tag/{tagName}");
            //    tagA.AddCssClass("label-default");
            //    tagA.Attributes.Add("style", "font-family: Arial;");
            //    TagBuilder tagSpan = new TagBuilder("span");
            //    TagBuilder tagSmall = new TagBuilder("small");
            //    tagSmall.SetInnerText(item);
            //    tagA.InnerHtml += tagSpan.ToString();

            //}
            //return new MvcHtmlString(tagA.ToString());
        }
    }
}