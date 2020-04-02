using Microsoft.AspNetCore.Razor.TagHelpers;
using MyProjectShopApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.TagHelpers
{

    [HtmlTargetElement("div", Attributes = "pages")]
    public class PageLinkTagHelper : TagHelper
    {

        public Pages pages { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("<ul class='pagination'>");

            for (int i = 1; i <= pages.TotalPage(); i++)
            {
                stringBuilder.AppendFormat("<li class='page-item {0}'>", i == pages.WhoPage ? "active" : "");
                if (string.IsNullOrEmpty(pages.ActiveCategory))
                {
                    stringBuilder.AppendFormat("<a class='page-link' href='/products?page={0}'>{0}</a>", i);
                }
                else
                {
                    stringBuilder.AppendFormat("<a class='page-link' href='/products/{0}?page={1}'>{1}</a>", pages.ActiveCategory, i);
                }
                stringBuilder.Append("</li>");
            }

            output.Content.SetHtmlContent(stringBuilder.ToString());

            base.Process(context, output);
        }
    }
}
