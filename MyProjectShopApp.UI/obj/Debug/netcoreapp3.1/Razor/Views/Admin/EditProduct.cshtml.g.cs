#pragma checksum "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\Admin\EditProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b4c8f2ca6034f3cc6ad5562fcd38101fdb00b06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_EditProduct), @"mvc.1.0.view", @"/Views/Admin/EditProduct.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\_ViewImports.cshtml"
using MyProjectShopApp.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\_ViewImports.cshtml"
using MyProjectShopApp.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\_ViewImports.cshtml"
using MyProjectShopApp.Entities.ORM.Entity.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b4c8f2ca6034f3cc6ad5562fcd38101fdb00b06", @"/Views/Admin/EditProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f614b33e094a02c2855e4cecb4504f3c326863b", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_EditProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyProjectShopApp.UI.Models.DTO.ProductDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\Admin\EditProduct.cshtml"
  
    ViewData["Title"] = "EditProduct";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"container\">\r\n\r\n        <h1>Edit Product</h1>\r\n\r\n");
#nullable restore
#line 10 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\Admin\EditProduct.cshtml"
         using (Html.BeginForm("EditProduct", "Admin", FormMethod.Post,new {enctype ="multipart/form-data"}))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <input type=\"hidden\" name=\"ProductID\"");
            BeginWriteAttribute("value", " value=\"", 336, "\"", 353, 1);
#nullable restore
#line 13 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 344, Model.ID, 344, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                <label for=\"ProductName\">Product Name</label>\r\n                <input type=\"text\" name=\"ProductName\"");
            BeginWriteAttribute("value", " value=\"", 515, "\"", 541, 1);
#nullable restore
#line 17 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 523, Model.ProductName, 523, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\">\r\n\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                <label for=\"ProductDescription\">ProductDescription</label>\r\n                <textarea class=\"form-control\" name=\"ProductDescription\">");
#nullable restore
#line 23 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\Admin\EditProduct.cshtml"
                                                                    Write(Model.ProductDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                <label for=\"ImgURL\">ImgURL</label>\r\n                <input hidden=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 967, "\"", 988, 1);
#nullable restore
#line 29 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 975, Model.ImgURL, 975, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"ImgURL\"/>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3b4c8f2ca6034f3cc6ad5562fcd38101fdb00b066753", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1033, "~/IMG/", 1033, 6, true);
#nullable restore
#line 30 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\Admin\EditProduct.cshtml"
AddHtmlAttributeValue("", 1039, Model.ImgURL, 1039, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <input type=\"file\" name=\"file\" />\r\n\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                <label for=\"Price\">Price</label>\r\n                <input type=\"text\" name=\"Price\"");
            BeginWriteAttribute("value", " value=\"", 1279, "\"", 1299, 1);
#nullable restore
#line 37 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\Admin\EditProduct.cshtml"
WriteAttributeValue("", 1287, Model.Price, 1287, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\">\r\n\r\n            </div>\r\n");
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-success\">Save Product</button>\r\n");
#nullable restore
#line 42 "C:\Users\LENOVO\Desktop\Bitirme Projesi\MyProjectShopApp\MyProjectShopApp.UI\Views\Admin\EditProduct.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n    </div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyProjectShopApp.UI.Models.DTO.ProductDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591